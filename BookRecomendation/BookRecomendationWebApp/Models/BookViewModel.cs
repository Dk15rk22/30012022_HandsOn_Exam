using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRecomendationWebApp.Models
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookViewModel
    {
        [DisplayName("Book Isbn")]
        [Required(ErrorMessage = "Please Enter the Book Isbn")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Book Isbn can have only Digits")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please Enter Minimum 5 Digits")]
        public int book_isbn { get; set; }

        [DisplayName("Book Title")]
        [Required(ErrorMessage = "Please Enter the Book title")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Product Name can have only English Alphabets")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Please Enter Minimum 7 English Alphabets")]

        public string title { get; set; }

        [DisplayName("Book Review")]
        [Required(ErrorMessage = "Please Enter the Book Review")]
        [RegularExpression(@"^[A-Z\sa-z0-9]+$", ErrorMessage = "Book Review can have only English Alphabets or Digits")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Please Enter Minimum 15 English Alphabets or Digits")]

        public string review { get; set; }

        [DisplayName("Author Id")]
        [Required(ErrorMessage = "Please Enter the Author Id")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Author Id can have only Digits")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please Enter Minimum 5 Digits")]

        public string author_id { get; set; }

}
}