using System.Collections.Generic;
using BookLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_CRUD_API.Managers;

namespace Simple_CRUD_API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private BookManager _manager = new BookManager();
        
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _manager.AllBooks();
            
            if (!books.Equals(null))
            {
                return Ok(books);
            }
            
            return NoContent();
        }

        // GET api/<BooksController>/5
        [HttpGet("{isbn13}")]
        public ActionResult<Book> GetBook(string isbn13)
        {
            Book book = _manager.SpecificBook(isbn13);
            
            if (!book.Equals(null))
            {
                return Ok(book);
            }
            
            return NotFound();
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            Book newBook = _manager.NewBook(book);
            
            if (!newBook.Equals(null))
            {
                return Created(newBook.ISBN13.ToString(), newBook);
            }
            
            return Conflict();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{isbn13}")]
        public ActionResult<Book> EditBook(string isbn13, [FromBody] Book book)
        {
            Book updatedBook = _manager.UpdateBook(isbn13, book);
            if (!updatedBook.Equals(null))
            {
                return Ok(updatedBook);
                
            }
            
            return NotFound();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{isbn13}")]
        public ActionResult<Book> DeleteBook(string isbn13)
        {
            Book deletedBook = _manager.DeleteBook(isbn13);
            if (!deletedBook.Equals(null))
            {
                return Ok(deletedBook);
            }
            
            return NotFound();
        }
    }
}