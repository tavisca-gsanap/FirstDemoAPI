using FirstDemoAPI.Model;
using System;
using System.Linq;

namespace FirstDemoAPI
{
    public class BookValidator
    {
        public static BookResponse Check(BookResponse bookResponse,Book book)
        {
            if (book.Id < 0)
                bookResponse._errorList.Add(new Error(400,
                    "Invalid Id, Id should be a positive number."));
            if (book.Price < 0)
                bookResponse._errorList.Add(new Error(400,
                    "Invalid Price, Price cannot be negative."));
            if (!book.Name.All(Char.IsLetter))
                bookResponse._errorList.Add(new Error(400,
                    "Invalid Name, should contain alphabets only."));
            if(!book.Category.All(Char.IsLetter))
                bookResponse._errorList.Add(new Error(400,
                    "Invalid Category, should contain alphabets only."));
            if (!book.Author.All(Char.IsLetter))
                bookResponse._errorList.Add(new Error(400,
                    "Invalid Author, should contain alphabets only."));
            return bookResponse;
        }
    }
}