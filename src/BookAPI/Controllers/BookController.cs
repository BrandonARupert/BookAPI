using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookAPI.Models; 
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
       private static  IBookRepository books  = new BookRepository() ; 
   
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return new ObjectResult(  books.GetAllBooks() ) ; 
        }
        [HttpPost]
        public void AddABook([FromBody] Book newBook )
        {
            books.AddBook( newBook); 
        }
        [HttpGet("{id}")]
        public IActionResult GetOneBook( long id)
        {
            return new ObjectResult(books.GetOneBook(id)); 
        }        
    }
}
