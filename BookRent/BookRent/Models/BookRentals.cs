using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class BookRentals
    {
        [Key]
        public int Id { get; set; }

        public DateTime RentalStart { get; set; }

        public DateTime RentalEnd { get; set; }
        
        public bool IsReturned { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Books Books { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }

    }
}
