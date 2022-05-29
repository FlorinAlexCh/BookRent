using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string ImgPublisher { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Books> Books { get; set; }
    }
}
