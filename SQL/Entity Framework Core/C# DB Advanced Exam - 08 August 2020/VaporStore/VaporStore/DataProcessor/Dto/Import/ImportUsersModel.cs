using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(GlobalConstants.UserAgeMinValue , GlobalConstants.UserAgeMaxValue)]
        public int Age { get; set; }

        public ImportUserCardModel[] Cards { get; set; } 
    }
}
