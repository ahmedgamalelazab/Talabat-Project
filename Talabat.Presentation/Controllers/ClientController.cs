using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service.Contracts;
using Shared.DataTransfierObject;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.ActionFilters;

namespace Talabat.Presentation.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    { 
        private readonly IServiceManager _service;
        public IHostingEnvironment _hostingEnvironment;
        private readonly RepositoryContext _context;

        public ClientController(
            IServiceManager service, 
            IHostingEnvironment hostingEnvironment,
            RepositoryContext context 
            )
        {
            _service=service;
            _hostingEnvironment=hostingEnvironment;
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients([FromQuery] CLientParameter cLientParameter)
        {
            var pagedResult = await _service.Client.GetAllClient(cLientParameter, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok( pagedResult.clients);
        }

        [HttpGet("address/{address}")]
        public IActionResult GetClientByAddress(string address)
        {
            var clients = _service.Client.GetAllClientByAddress(address);
            return Ok(clients);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var types = _context.Set<ClientType>().ToList();
            return Ok(types);
        }

        [HttpGet("{clientId:int}")]
        public async Task<IActionResult> GetClientAsync(int clientId)
        {
            var client = await _service.Client.GetClientAsync(clientId, trackChages: false);
            /* string fileName = "ClientPic_" + client.ClientId + ".png";
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "ClientPics", fileName);
            client.PhotoPath = System.IO.File.ReadAllText(path);*/
            return Ok(client);
        }

        [HttpPost/*,DisableRequestSizeLimit*/]
       /* [ServiceFilter(typeof(ValidationFilterAttribute))]*/
        public async Task<IActionResult> CreateClient([FromForm] ClientForCreatingDto clientForCreating, Client clientEntity)
        {
            /*clientForCreating.PhotoPath = await SaveImage(clientEntity.Photo);*/
            var client = await _service.Client.CreateClientAsync(clientForCreating);
            return CreatedAtRoute("clientById", new { clientId = client.Id }, client);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _service.Client.DeleteClientAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientForUpdateDto updateDto)
        {
           
            await _service.Client.UpdateClientAsync(id, updateDto, trackChanges: false);
            return NoContent();
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                .Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName+DateTime.Now.ToString("yymmssfff") +
                Path.GetExtension(imageFile.FileName);
            
            var imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }


    }
}
