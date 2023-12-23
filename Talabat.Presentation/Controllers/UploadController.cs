using Microsoft.AspNetCore.Mvc;
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
    public class UploadController : ControllerBase
    {
       [HttpPost, DisableRequestSizeLimit]
       public async Task<IActionResult> Upload()
       {
            try
            {
                var formCollectoin = await Request.ReadFormAsync();
                var file = formCollectoin.Files.First();
                var folderName = Path.Combine("Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbpath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbpath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
       }
    }
}
