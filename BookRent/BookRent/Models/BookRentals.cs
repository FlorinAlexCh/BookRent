using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class BookRentals : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var model = (BookRentals)validationContext.ObjectInstance;
            var rentalEnd = Convert.ToDateTime(model.RentalEnd);
            var rentalStart = Convert.ToDateTime(model.RentalStart);

            if (rentalEnd < rentalStart)
            {
                yield return new ValidationResult
                    ("Data de returnare trebuie sa fie mai recenta decat cea de imprumut, schimba data si incearca din nou");
            }
            else if (rentalEnd > rentalStart.AddDays(7))
            {
                yield return new ValidationResult
                    ("Durata de imprumut nu poate fi mai mare de 7 zile, asigura-te ca durata e mai mica de 7 zile si incearca din nou");
            }

            if(rentalStart < DateTime.Today)
            {
                yield return new ValidationResult
                 ("Data de imprumut nu poate fi in trecut, schimba data si incearca din nou");
            }
        }
    }
}
