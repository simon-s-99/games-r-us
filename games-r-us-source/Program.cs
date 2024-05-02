using games_r_us_source.Components;
using games_r_us_source.Data;
using games_r_us_source.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace games_r_us_source
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // add db
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // below services (& chained calls) sets up our user authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Google";
            }).AddCookie(options =>
            {
                // When a user logs in to Google for the first time,
                // create a local account for that user in our database.
                options.Events.OnValidatePrincipal += async context =>
                {
                    var serviceProvider = context.HttpContext.RequestServices;
                    using var db = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

                    string subject = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                    string issuer = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Issuer;
                    string name = context.Principal.FindFirst(ClaimTypes.Name).Value;

                    var account = db.Accounts
                        .FirstOrDefault(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);

                    if (account == null)
                    {
                        account = new Account
                        {
                            OpenIDIssuer = issuer,
                            OpenIDSubject = subject,
                            Name = name
                        };
                        db.Accounts.Add(account);
                    }
                    else
                    {
                        // If the account already exists, just update the name in case it has changed.
                        account.Name = name;
                    }

                    await db.SaveChangesAsync();
                };
            }).AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            });
            
            // this is needed so that we can place our 
            // <CascadingAuthenticationState> tag on root level
            builder.Services.AddCascadingAuthenticationState();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var database = services.GetRequiredService<AppDbContext>();
                SampleData.Create(database);
            }

            app.Run();
        }
    }
}
