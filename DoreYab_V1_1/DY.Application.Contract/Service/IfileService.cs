using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Contract.Service
{
    public interface IfileService
    {   
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        Task<string> SaveThumbnailAsync(IFormFile file, string folderName, int width = 300, int height = 200);
        void DeleteFile(string filePath);
    }
}
