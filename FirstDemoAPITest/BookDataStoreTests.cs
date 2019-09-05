using Xunit;
using FirstDemoAPI;
using FirstDemoAPI.Model;
using System.Collections.Generic;

namespace FirstDemoAPITest
{
    public class BookDataStoreTests
    {
        [Fact]
        public void Empty_Data_Store_test()
        {
            var bookList = BookDataStore.Get();
            Assert.Empty(bookList);
        }

        [Fact]
        public void Add_Book_Test()
        {        
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            BookDataStore.Post(book);
            var bookList = BookDataStore.Get();
            Assert.Single(bookList);
        }

        [Fact]
        public void Update_Book_Test()
        {   
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "GovindSanap" };
            BookDataStore.Post(book);
            Book newBook = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            BookDataStore.Put(1, newBook);
            var updatedBook = BookDataStore.Get(1);
            Assert.Equal(newBook.Author, updatedBook.Author);
        }

        [Fact]
        public void Update_Book_Which_Is_Not_Present_Test()
        {   
            Book newBook = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            Assert.Throws<BookNotFoundException>(() => BookDataStore.Put(1, newBook));
        }

        [Fact]
        public void Delete_Book_Test()
        {   
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "Govind Sanap" };
            BookDataStore.Post(book);

            BookDataStore.Delete(1);
            var bookList = BookDataStore.Get();

            Assert.Empty(bookList);
        }

        [Fact]
        public void Delete_Book_Which_Is_Not_Present_Test()
        {   
            Assert.Throws<BookNotFoundException>(() => BookDataStore.Delete(1));
        }
    }
}
