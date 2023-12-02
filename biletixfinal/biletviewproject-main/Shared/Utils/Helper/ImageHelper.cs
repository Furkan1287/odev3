using Microsoft.AspNetCore.Http;

namespace Shared.Utils.Helper
{
    public static class ImageHelper
    {
        public static string ImageToBase64(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0) return null;

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png"};

            var extension = Path.GetExtension(imageFile.FileName);
            if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase)) return null;
            using var stream = new MemoryStream();
            imageFile.CopyTo(stream);

            string base64String = Convert.ToBase64String(stream.ToArray());
            return $"data:image/{extension.Substring(1)};base64,{base64String}";
        }
    }
}
