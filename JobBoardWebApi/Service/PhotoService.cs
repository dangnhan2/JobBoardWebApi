using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;

namespace JobBoardWebApi.Service
{   
    public interface IPhotoService
    {
        Task<string> UploadImageAsync(IFormFile file, string[] allowedExtensions);
        Task<string> UploadDocumentAsync(IFormFile file, string[] allowedExtensions);
    }
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService() {
            var account = new Account(
               Environment.GetEnvironmentVariable("Cloudinary__CloudName"),
               Environment.GetEnvironmentVariable("Cloudinary__ApiKey"),
               Environment.GetEnvironmentVariable("Cloudinary__ApiSecret")
           );

            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }


        public async Task<string> UploadImageAsync(IFormFile file, string[] allowedExtensions)
        {
            if (file == null || file.Length <= 0)
                throw new ArgumentException("File is empty");

            var extension = Path.GetExtension(file.FileName).ToLower();

            using var stream = file.OpenReadStream();

            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Does not support this format");

                // Upload ảnh
               
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "Image",
                    Transformation = new Transformation().Crop("fill").Gravity("face").Width(500).Height(500)
                };

                var resultString = await _cloudinary.UploadAsync(uploadParams);

                if (resultString.Error != null)
                    throw new Exception(resultString.Error.Message);

                return resultString.SecureUrl.ToString();
        }

        public async Task<string> UploadDocumentAsync(IFormFile file, string[] allowedExtensions)
        {
            if (file == null || file.Length <= 0)
                throw new ArgumentException("File is empty");

            var extension = Path.GetExtension(file.FileName).ToLower();

            using var stream = file.OpenReadStream();

            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Does not support this format");

            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "Resume",
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.ToString();
        }
    }
}

            


           



            

