using games_r_us_source.Components;
using games_r_us_source.Data;
using groceries_webshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders; //Needed to display images from temp folder

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

            // Static files config for displaying images
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider("D:\\Temp\\Storage"),
                RequestPath = "/Storage"
            });

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
