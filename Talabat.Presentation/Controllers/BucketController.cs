using Imagekit.Sdk;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly ImagekitClient _imageKitClient;
        public BucketController(ImagekitClient client)
        {
            _imageKitClient = client;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();

                if (formCollection == null)
                {
                    // Log: Unable to read form data
                    return BadRequest("Unable to read form data");
                }

                var file = formCollection.Files.FirstOrDefault();

                if (file == null || file.Length == 0)
                {
                    // Log: No file or empty file uploaded
                    return BadRequest("No file or empty file uploaded");
                }

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                // Convert IFormFile to byte[]
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    FileCreateRequest request = new FileCreateRequest
                    {
                        file = fileBytes,
                        fileName = fileName,
                    };

                    Result resp = _imageKitClient.Upload(request);

                    // Log: File successfully uploaded
                    string jsonResponse = JsonConvert.SerializeObject(new { message = "Image uploaded", result = resp.name });
                    return Ok(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                // Log: Exception occurred during file upload
                return StatusCode(500, $"Internal server error: {ex}");
            }



        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string filePath)
        {
            try
            {
                string imageURL = _imageKitClient.Url(new Transformation()).Path(filePath).Generate();
                return StatusCode(200, imageURL);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
