﻿using Entities.DataTransferObjects;
using Entities.RequesFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
   // [ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName="5mins")]
    //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 80)]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager; 
        }

        [Authorize]
        [HttpHead]
        [HttpGet(Name ="GetAllBooksAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        //[ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {    

            var linkParameters = new LinkParameters
            {
                BookParameters = bookParameters,
                HttpContext = HttpContext
            };

            var result = await _manager
                            .BookService
                            .GetAllBooksAsync(linkParameters, false);
            Response.Headers.Add("X-Pagination", 
                JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ? 
                Ok(result.linkResponse.LinkedEntities) : 
                Ok(result.linkResponse.ShapedEntities); //200
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);

            return Ok(book); //200
        }


        [Authorize]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllBooksWithDetailsAsync()
        {
            var books = await _manager.BookService.GetAllBooksWithDetailsAsync(false);

            return Ok(books); //200 
        }


        [Authorize(Roles= "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneBookAsync")]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateOneBookAsync(bookDto);
            return StatusCode(201, book); //201
        }


        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute), Order =1)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, 
            [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);

            return NoContent(); //204
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBooksAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent(); //204
        }

        [Authorize(Roles = "Editor, Admin")]
        [HttpPatch("{id:int}")]
        public async  Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if(bookPatch is null)
                return BadRequest(); //400

            var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate); //validate the updated book
         
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState); //422
          
            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);

            return NoContent(); //204
        }

        [Authorize]
        [HttpOptions]
        public IActionResult GetBooksOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
