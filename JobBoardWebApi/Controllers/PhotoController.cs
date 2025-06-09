using CloudinaryDotNet;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService) {
          _photoService = photoService;
        }

        [HttpPost("uploadImage")]  
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            try
            {
                var url = await _photoService.UploadImageAsync(file, allowedExtensions);
                return Ok(new
                {
                    msg = "Upload Image successful!",
                    statusCode = StatusCodes.Status200OK,
                    imageUrl = url
                });
            } catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            } catch (Exception ex) {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string[] allowedExtensions = { ".pdf", ".doc", ".docx" };

            try
            {
                var url = await _photoService.UploadDocumentAsync(file, allowedExtensions);
                return Ok(new
                {
                    msg = "Upload File successful!",
                    statusCode = StatusCodes.Status200OK,
                    imageUrl = url
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

    }
}
