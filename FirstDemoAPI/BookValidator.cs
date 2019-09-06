using FirstDemoAPI.Model;
using System;
using System.Linq;

namespace FirstDemoAPI
{
    public class BookValidator
    {
        public static string Check(Book book)
        {
            string message = "";
            if (book.Id < 0)
                message += "Invalid Id, Id should be a positive number.";
            if (book.Price < 0)
                message += "Invalid Price, Price cannot be negative.";
            if (!book.Name.All(Char.IsLetter))
                message += "Invalid Name, should contain alphabets only.";
            if(!book.Category.All(Char.IsLetter))
                message += "Invalid Category, should contain alphabets only.";
            if (!book.Author.All(Char.IsLetter))
                message += "Invalid Author, should contain alphabets only.";
            if(message=="")
                return $"Success, Book with id : {book.Id} has been Updated";
            return message;
        }
    }
}