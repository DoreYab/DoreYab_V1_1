using DY.Application.Contract.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;

namespace DY.Application.ImplimentServise
{
    public class FilseService(IWebHostEnvironment env) : IfileService // Fix: Correctly define the class without using constructor-like syntax
    {
        private readonly IWebHostEnvironment _env = env;

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("فایل نامعتبر است.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("/", folderName, uniqueFileName).Replace("\\", "/");
        }

        public async Task<string> SaveThumbnailAsync(IFormFile file, string folderName, int width = 300, int height = 200)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("فایل نامعتبر است.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"thumb_{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var image = System.Drawing.Image.FromStream(file.OpenReadStream()))
            using (var thumb = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(thumb))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, width, height);
                graphics.DrawImage(image, 0, 0, width, height);
                thumb.Save(filePath, ImageFormat.Jpeg);
            }

            return Path.Combine("/", folderName, uniqueFileName).Replace("\\", "/");
        }

        public void DeleteFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            var fullPath = Path.Combine(_env.WebRootPath, filePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
