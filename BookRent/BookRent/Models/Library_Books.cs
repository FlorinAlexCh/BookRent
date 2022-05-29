using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class Library_Books
    {
         public int BooksId { get; set; }
        public Books Books { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
