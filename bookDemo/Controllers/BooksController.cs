using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (book is null)
                return NotFound();

            return Ok(book);
        }
        
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                
                ApplicationContext.Books.Add(book);
                
                return StatusCode(201, book);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, 
            [FromBody] Book book)
        {
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            
            if(entity is null)
                return NotFound();
            
            if(id != book.Id)
                return BadRequest();

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return StatusCode(200, entity);
        }

        [HttpDelete]
        public IActionResult DeleteAllBook() 
        { 
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if(entity is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id: {id} could not found"
                });
            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }
    }
}
