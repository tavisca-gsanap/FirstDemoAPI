using FirstDemoAPI.Model;
using System;
using System.Linq;

namespace FirstDemoAPI
{
    public class BookValidator
    {
        public static string Check(Book book)
        {
            if (book.Id < 0)
                return "Invalid Id, Id should be a positive number.";
            if (book.Price < 0)
                return "Invalid Price, Price cannot be negative.";
            if (!book.Name.All(Char.IsLetter) || !book.Category.All(Char.IsLetter) || !book.Author.All(Char.IsLetter))
                return "Invalid, should contain alphabets only.";
            return $"Success, Book with id : {book.Id} has been Updated";
        }
    }
}