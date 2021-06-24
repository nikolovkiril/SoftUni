﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
   public  class AuthorModel
    {
        [Required]
        [StringLength(30 , MinimumLength =3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{4})$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public AuthorBookModel[] Books { get; set; }
    }
}
//• FirstName - text with length[3, 30]. (required)
//• LastName - text with length[3, 30]. (required)
//• Email - text(required).Validate it! There is attribute for this job.
//• Phone - text.Consists only of three groups(separated by '-'), 
//the first two consist of three digits and the last one - of 4 digits. (required)
//• AuthorsBooks - collection of type AuthorBook

//  [RegularExpression("^(\\d{3}-\\d{3}-\\d{4})$")]
