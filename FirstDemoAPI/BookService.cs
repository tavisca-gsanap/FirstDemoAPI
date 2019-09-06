using FirstDemoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoAPI
{
    public interface IBookService
    {
        List<Book> Get();
        BookResponse Get(int id);
        BookResponse Post(Book book);
        BookResponse Put(int id, Book book);
        void Delete(int id);
        
    }
    public class BookService : IBookService
    {
        public List<Book> Get()
        {
            return BookDataStore.Get();
        }

        public BookResponse Get(int id)
        {
            BookResponse bookResponse = new BookResponse();
            try
            {
                Book book = BookDataStore.Get(id);
                bookResponse.Response = book;
            }
            catch (BookNotFoundException)
            {
                bookResponse._errorList.Add(new Error(404,
                    $"Book with given id : {id} Not Found"));
            }
            return bookResponse;
        }

        public BookResponse Post(Book book)
        {
            BookResponse bookResponse = BookValidator.Check(new BookResponse(), book);
            if (bookResponse._errorList.Count == 0)
                bookResponse.Response= BookDataStore.Post(book);
            return bookResponse;
        }

        public BookResponse Put(int id, Book book)
        {
            BookResponse bookResponse = BookValidator.Check(new BookResponse(), book);
            if (bookResponse._errorList.Count == 0)
                bookResponse.Response = BookDataStore.Put(id, book);
            return bookResponse;
        }
        public void Delete(int id)
        {
            BookDataStore.Delete(id);
        }
    }
}
