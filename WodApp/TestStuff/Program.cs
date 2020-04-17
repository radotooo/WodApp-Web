using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account { ApiKey = "384236325362822", ApiSecret = "9lbM_1dKosqL9w7m_FuysBJPMRs", Cloud = "radotooo" };
            Cloudinary _cloudinary = new Cloudinary(myAccount);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"c:\my_image.jpg")
            };

            var uploadResult = _cloudinary.Upload(uploadParams);
            var url = uploadResult.SecureUri.AbsoluteUri;
            Console.WriteLine(url);

        }



    }
}


