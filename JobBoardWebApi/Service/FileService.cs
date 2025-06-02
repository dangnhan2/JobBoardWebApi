
namespace JobBoardWebApi.Service
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
           
            _webHostEnvironment = webHostEnvironment;
        }

        public void DeleteImage(string fileName, string directory)
        {
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, directory, fileName);

            if (!Path.Exists(fullPath)) {
                throw new FileNotFoundException($"File {fileName} does not exists");
            }

            File.Delete(fullPath);
        }

        

        public string UploadImage(IFormFile file, string directory, string[] allowedExtensions)
        {
 
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, directory);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            // create the unique file name
            var newFile = $"{Guid.NewGuid()}_{extension}";

            // create fullPath = path + newFileName
            var fullPath = Path.Combine(uploadPath, newFile);

            // create a filestream
            using var fileStream = new FileStream(fullPath, FileMode.Create);

            file.CopyTo(fileStream);

            return newFile;
        }

        
    }
}
