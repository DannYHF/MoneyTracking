using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MoneyTracking.API.Services.Interfaces
{
    public interface IImageService
    {
        /// <summary>
        /// Write image to path.
        /// </summary>
        /// <returns>Image name.</returns>
        Task<string> WriteImage(IFormFile image);

        void DeleteImage(string imageName);
    }
}