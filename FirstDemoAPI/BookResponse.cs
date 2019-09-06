using FirstDemoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoAPI
{
    public class BookResponse
    {
        public List<Error> _errorList = new List<Error>();
        public Book Response { get; set; }
    }
}
