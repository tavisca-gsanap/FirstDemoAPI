using FirstDemoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoAPI
{
    public class BookDataStore
    {
        public static List<Book> BookList = new List<Book>();
        public static List<Book> Get()
        {
            return BookList;
        }
        public static Book Get(int id)
        {
            Book book = BookList.Find((b) => b.Id == id);
            if (book == null)
                throw new BookNotFoundException();
            return BookList.Find((b) => b.Id == id);
        }
        public static Book Post(Book book)
        {
            BookList.Add(book);
            return book;
        }
        public static Book Put(int id,Book updatedBook)
        {
            Book book = BookList.Find((b) => b.Id == id);
            if (book == null)
                throw new BookNotFoundException();
            book.CopyPropertiesFrom(updatedBook);
            return book;
        }
        public static void Delete(int id)
        {
            Book book = BookList.Find((b) => b.Id == id);
            if (book == null)
                throw new BookNotFoundException();
            BookList.Remove(book);
        }
    }
}
