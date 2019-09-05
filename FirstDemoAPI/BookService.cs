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
        Book Get(int id);
        string Post(Book book);
        string Put(int id, Book book);
        void Delete(int id);
        
    }
    public class BookService : IBookService
    {
        public List<Book> Get()
        {
            return BookDataStore.Get();
        }

        public Book Get(int id)
        {
            Book book = BookDataStore.Get(id);
            return book;
        }

        public string Post(Book book)
        {
            string status = BookValidator.Check(book);
            BookDataStore.Post(book);
            return status;
        }

        public string Put(int id, Book book)
        {
            string status = BookValidator.Check(book);
            BookDataStore.Put(id, book);
            return status;
        }
        public void Delete(int id)
        {
            BookDataStore.Delete(id);
        }
    }
}
