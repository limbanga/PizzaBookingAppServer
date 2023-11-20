using Microsoft.AspNetCore.Http;

namespace PizzaBookingShared.Helpers
{
    public static class Uploader
    {
        public const string ROOT_DIR = @"D:/self_study/c_sharp/PizzaBookingAppServer/PizzaBookingAppClient/wwwroot/upload/";
        public async static Task<string> UploadTo(IFormFile file, string directoryName ,string? newName = null)
        {
            if (string.IsNullOrEmpty(newName))
            {
                newName = Guid.NewGuid().ToString();
            }
            newName += Path.GetExtension(file.FileName);

            string storageDir = Path.Combine(ROOT_DIR, directoryName);

            if (!Directory.Exists(storageDir))
            {
                Directory.CreateDirectory(storageDir);
            }

            string storagePath = Path.Combine(storageDir, newName);

            using (var stream = new FileStream(storagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newName;
        }
    }
}
