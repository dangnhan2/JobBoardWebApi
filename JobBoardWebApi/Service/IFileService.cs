namespace JobBoardWebApi.Service
{
    public interface IFileService
    {
        void DeleteImage(string fileName, string directory);
        string UploadImage(IFormFile file, string directory, string[] allowedExtensions);
    }
}
