using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Wod.Services.Claudinary.Contracts;

namespace Wod.Services.Claudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
        public async Task<string> UploadAsync(IFormFile file, string fileName)
        {
            byte[] destinationImage;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            destinationImage = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(destinationImage);
            
            fileName = fileName.Replace("&", "And");
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, destinationStream),
                PublicId = fileName,
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            return result.Uri.AbsoluteUri;
        }
    }
}
