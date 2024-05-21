using games_r_us_source.Data;
using Microsoft.AspNetCore.Components.Forms;

namespace games_r_us_source.Components.Helpers
{
    public static class ListingHelper
    {
        public static Data.Listing GetListingFromListingID(int listingID, ApplicationDbContext context)
        {
            Data.Listing listing = context.Listings.Where(l => l.ID == listingID).FirstOrDefault();
            return listing;
        }

        // Method to handle images
        public static async Task<(string base64Image, string currentImagePath)> LoadFilesAsync(InputFileChangeEventArgs e, string currentImagePath, long maxFileSize)
        {
            var imageFile = e.File;
            string newImagePath = null;
            string newBase64Image = null;

            if (imageFile != null && imageFile.Size > 0)
            {
                MemoryStream ms = new MemoryStream();
                try
                {
                    // Create the existence of a temporary storage directory for images
                    string tempFolderPath = Path.Combine("C:\\Temp", "temp_images");
                    Directory.CreateDirectory(tempFolderPath);


                    // Delete previous image if the user changes image before submitting
                    if (!string.IsNullOrEmpty(currentImagePath))
                    {
                        var previousFilePath = Path.Combine(tempFolderPath, currentImagePath);
                        if (File.Exists(previousFilePath))
                        {
                            File.Delete(previousFilePath); // Delete the image if it isn't used for a listing
                        }
                    }

                    await imageFile.OpenReadStream(maxFileSize).CopyToAsync(ms);
                    byte[] buffer = ms.ToArray();
                    newBase64Image = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";

                    string fileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(imageFile.Name));
                    string fullPath = Path.Combine(tempFolderPath, fileName);
                    await File.WriteAllBytesAsync(fullPath, buffer); // Save in temporary directory

                    newImagePath = fileName;
                }
                catch (Exception ex)
                {
                    newBase64Image = null;
                    currentImagePath = null;
                }

            }

            return (newBase64Image, newImagePath);
        }

    }
}
