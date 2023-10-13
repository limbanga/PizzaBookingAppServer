using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaBookingAppServer.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [Route("/upload")]
        public async Task<string> UploadFile([FromForm(Name = "file")] IFormFile imageFile)
        {
            string rootPath = GetRootDirectory();

            string path = Path.Combine(rootPath, "PizzaBookingAppClient/wwwroot/upload");

            string newName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName); 

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var fileStream = new FileStream(Path.Combine(path, newName), FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return newName;
        }   

        //---------------------------------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------------------------------
        private string GetRootDirectory()
        {
            DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory())!;
            return directoryInfo!.FullName;
        }
    }
}
