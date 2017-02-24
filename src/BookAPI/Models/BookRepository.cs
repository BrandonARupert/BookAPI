using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models; 
namespace BookAPI.Models
{
   

    public class BookRepository : IBookRepository
    {
        Dictionary<long, Book> dummyDb;
        long lastId; //quick and dirty use in this reviewl ; when I read up and understand GUIDs in this case I would use that 
        //also if using database in- or out-memory, use attributes in that case 
        public BookRepository()
        {
            lastId = 0L; 
            //some books 
            dummyDb = new Dictionary<long, Book>()
            {
                { ( ++lastId) , new Book {  Id = lastId , Author = "Ray Bradbury", Title="Fahrenheit 451"   } } ,
                { ( ++lastId), new Book {  Id = lastId , Author = "Ray Bradbury" , Title = "The October Country"}},
                {(++lastId ), new Book{ Id = lastId, Author = "J.D. Salinger" , Title = "The Catcher in the Rye" } },
                {( ++lastId), new Book { Id = lastId , Author = "James Joyce" , Title = "A Portrait of the Artist as a Young Man"} } 


            }; 
        }
        //did not include all CRUD operations
        public void AddBook(Book newBook)
        {
            foreach (Book b in dummyDb.Values) if (b.Title.Equals(newBook.Title) && b.Author.Equals(newBook.Author)) return;
            newBook.Id = (++lastId);
            dummyDb.Add(lastId, newBook); 
                         
        }


        public IEnumerable<Book> GetAllBooks()
        {
            return dummyDb.Values; 
        }

        public Book GetOneBook(long id)
        {
            return ((dummyDb.ContainsKey(id) ? dummyDb[id] : null)); 
        }

    }
}
