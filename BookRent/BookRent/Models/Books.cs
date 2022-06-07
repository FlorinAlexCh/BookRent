using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        public string BkImage { get; set; }

        [Display(Name ="Nume")]
        public string BkName { get; set; }

        public string BKShortDescription { get; set; }

        public string BkDescription { get; set; }    

        public string BkPrice { get; set; }

        public BkCategory BkCategory { get; set; }

        public int BkReleaseYear { get; set; }
        
        public int Quantity { get; set; }

        public string BkPageNumber { get; set; }

        public BkLanguage BkLanguage { get; set; }

        public string BkCoverType { get; set; }

        public int LibraryID { get; set; }
        [ForeignKey("LibraryID")]

        public Library Library { get; set; }

        public int PublisherID { get; set; }
        [ForeignKey("PublisherID")]

        public Publisher Publisher { get; set; }

        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author Author { get; set; }
    }
}
