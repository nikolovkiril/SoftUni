﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
}
    /*• Id – Integer, Primary Key
    • FirstName – text with max length 20 (required) 
    • LastName – text with max length 20 (required) 
    • Age – Integer(required)
    • NetWorth – decimal (required)
    • PerformerSongs – collection of type SongPerformer*/