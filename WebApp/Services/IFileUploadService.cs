using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IFileUploadService
    {
        Task<string> LocalStorage(IFormFile file, string fileName, string folderDestination);
    }
}
