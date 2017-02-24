using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    interface IBookRepository
    {
        Book GetOneBook(long id);
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book newBook);

    }
}
