using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationLR7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
           
            var contentInFile = $"My name: {firstName} and surname: {lastName}";
            var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), $"{fileName}.txt");
            await System.IO.File.WriteAllTextAsync(pathToFile, contentInFile, Encoding.UTF8);

            return PhysicalFile(pathToFile, "text/plain", $"{fileName}.txt");
        }
    }
}
