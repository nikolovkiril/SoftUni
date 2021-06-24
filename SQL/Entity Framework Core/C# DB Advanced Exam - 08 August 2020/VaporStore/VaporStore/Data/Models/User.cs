using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.UserAgeMinValue)]
        [MaxLength(GlobalConstants.UserAgeMaxValue)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}
