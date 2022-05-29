using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public string Location { get; set; }

        public string OpenHours { get; set; }

        public List<Library_Books> Library_Books { get; set; }

    }
}
