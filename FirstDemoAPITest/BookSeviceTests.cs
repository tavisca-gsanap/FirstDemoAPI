using FirstDemoAPI;
using FirstDemoAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FirstDemoAPITest
{
    public class BookServiceTests
    {
        BookService _bookService = new BookService();
        [Fact]
        public void Empty_Data_Store_test()
        {
            var bookList = _bookService.Get();
            Assert.Empty(bookList);
        }

        [Fact]
        public void Add_Book_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            _bookService.Post(book);
            var bookList = _bookService.Get();
            Assert.Single(bookList);
        }

        [Fact]
        public void Add_Book_With_Negative_Id_Test()
        {
            Book book = new Book { Id = -1, Name = "WingsOfFire", Author = "APJKalam", Category = "BioGraphy", Price = 12 };
            string expected = "Invalid Id, Id should be a positive number.";
            Assert.Equal(expected, _bookService.Post(book).ErrorList[0].Message);
        }

        [Fact]
        public void Add_Book_With_Invalid_Price_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Price=-12,Category="BioGraphy" };
            string expected = "Invalid Price, Price cannot be negative.";
            Assert.Equal(expected, _bookService.Post(book).ErrorList[0].Message);
        }

        [Fact]
        public void Add_Book_With_Invalid_Name_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOf#Fire", Author = "APJKalam", Price = 12, Category = "BioGraphy" };
            string expected = "Invalid Name, should contain alphabets only.";
            Assert.Equal(expected, _bookService.Post(book).ErrorList[0].Message);
        }

        [Fact]
        public void Add_Book_With_Invalid_Category_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam", Price = 12, Category = "Bio 1Graphy" };
            string expected = "Invalid Category, should contain alphabets only.";
            Assert.Equal(expected, _bookService.Post(book).ErrorList[0].Message);
        }

        [Fact]
        public void Add_Book_With_Invalid_Author_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJ Kalam", Price = 12, Category = "BioGraphy" };
            string expected = "Invalid Author, should contain alphabets only.";
            Assert.Equal(expected, _bookService.Post(book).ErrorList[0].Message);
        }

        [Fact]
        public void Add_Book_With_Invalid_Price_And_Invalid_Author_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "APJ Kalam", Price = -12, Category = "BioGraphy" };
            string expected = "Invalid Price, Price cannot be negative."+ "Invalid Author, should contain alphabets only.";
            List<Error> errorList = _bookService.Post(book).ErrorList;
            Assert.Equal(expected, errorList[0].Message+errorList[1].Message);
        }

        [Fact]
        public void Update_Book_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "GovindSanap", Category = "BioGraphy", Price = 12 };
            _bookService.Post(book);
            Book newBook = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            _bookService.Put(1, newBook);
            var updatedBook = _bookService.Get(1).Response;
            Assert.Equal(newBook.Author, updatedBook.Author);
        }

        [Fact]
        public void Update_Book_Which_Is_Not_Present_Test()
        {
            Book newBook = new Book { Id = 1, Name = "WingsOfFire", Author = "APJKalam",Category="BioGraphy",Price=12 };
            string expected = $"Book with given id : {1} Not Found";
            Assert.Equal(expected, _bookService.Put(1, newBook).ErrorList[0].Message);
        }

        [Fact]
        public void Delete_Book_Test()
        {
            Book book = new Book { Id = 1, Name = "WingsOfFire", Author = "GovindSanap", Category = "BioGraphy", Price = 12 };
            _bookService.Post(book);

            _bookService.Delete(1);
            var bookList = _bookService.Get();

            Assert.Empty(bookList);
        }

        [Fact]
        public void Delete_Book_Which_Is_Not_Present_Test()
        {
            string expected = $"Book with given id : {1} Not Found";
            Assert.Equal(expected, _bookService.Delete(1).ErrorList[0].Message);
        }
    }
}
