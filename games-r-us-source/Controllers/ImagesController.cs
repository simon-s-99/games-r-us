using Microsoft.AspNetCore.Mvc;

[Route("images")]
[ApiController]
public class ImageController : Controller
{
    [HttpGet("{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        // Combine the base path "C:\\Temp" with the file name to get the full file path
        var filePath = Path.Combine("C:\\Temp", fileName);

        // Using System.IO namespace to handle files
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        // Open the file for reading
        var image = System.IO.File.OpenRead(filePath);
        var contentType = GetContentType(filePath);

        return File(image, contentType);
    }

    // This method gets the content type (MIME type) for a given file path
    // MIME types is used to specify the type of data being sent over the internet(HTTP)
    private string GetContentType(string path)
    {
        var types = GetMimeTypes();

        // Get the file extension and convert it to lowercase
        var ext = Path.GetExtension(path).ToLowerInvariant();

        // If the extension is not found, return "application/octet-stream",
        // which is a default MIME type for binary data when the specific type is unknown.
        return types.ContainsKey(ext) ? types[ext] : "application/octet-stream";
    }

    // This method returns a dictionary of common file extensions and their MIME types
    // (the image types we allow when users uploads an image) + "application/octet-stream"
    private Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
        {
            { ".png", "image/png" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".gif", "image/img" },
            { ".img", "application/octet-stream" }
        };
    }
}
