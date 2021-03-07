using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Services.Interfaces;

namespace MoneyTracking.API.Services
{
    public class ImageService : IImageService
    {
        private readonly string _imagePath;

        public ImageService(string imagePath)
        {
            _imagePath = imagePath;
        }

        public async Task<string> WriteImage(IFormFile image)
        {
            string imgExtension = GetExtension(image);
            if (imgExtension == null)
                throw new UnsupportedImageTypeException();
            
            string imgName = Path.GetRandomFileName() + imgExtension;
            using (var stream = new FileStream(Path.Combine(_imagePath, imgName), FileMode.CreateNew))
                await image.CopyToAsync(stream);

            return imgName;
        }
        
        public void DeleteImage(string imageName)
        {
            string fullPath = Path.Combine(_imagePath, imageName);
            
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            else throw new  NotFoundException("Image");
        }
        

        private string GetExtension(IFormFile image)
        {
            Dictionary<List<string>,string> extensions = new Dictionary<List<string>,string>
            {
                {"89 50 4E 47".Split().ToList(), ".png"},
                {"FF D8 FF DB".Split().ToList(), ".jpg"},
                {"FF D8 FF E0".Split().ToList(), ".jpeg"}
            };
            
            var file = GetBytesFrom(image);
            List<string> fileHead = new List<string>();
            
            for (var i = 0; i < 4; i++)
                fileHead.Add(file[i].ToString("X2"));


            foreach (var extensionHead in extensions.Keys)
                if (!extensionHead.Except(fileHead).Any())
                    return extensions[extensionHead];

            return null;
        }
        private byte[] GetBytesFrom(IFormFile image)
        {
            byte[] imageData;
            if (image != null)
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                    imageData = binaryReader.ReadBytes((int)image.Length);
            else
                throw new NullReferenceException("Input object is null");
            
            return imageData;
        }
    }
}