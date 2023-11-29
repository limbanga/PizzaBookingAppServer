using Microsoft.AspNetCore.Http;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaBookingShared.Helpers
{
    public interface IUploader
    {
        Task<string> UploadTo(IFormFile file, string directoryName, string? newName = null);
    }
    public class Uploader : IUploader
    {
        private IWebHostEnvironment _hostEnvironment;
        public Uploader(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> UploadTo(IFormFile file, string directoryName, string? newName = null)
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;

            DirectoryInfo di = new DirectoryInfo(currentDirectory);
            for (int i = 0; i < 4; i++)
            {
                di = di.Parent!;
            }

            string ROOT_DIR = Path.Combine(di.FullName,
                                "PizzaBookingAppClient",
                                "wwwroot",
                                "upload");

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
