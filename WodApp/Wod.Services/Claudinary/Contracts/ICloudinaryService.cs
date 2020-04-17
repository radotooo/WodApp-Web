using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wod.Services.Claudinary.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file, string fileName);
    }
}
