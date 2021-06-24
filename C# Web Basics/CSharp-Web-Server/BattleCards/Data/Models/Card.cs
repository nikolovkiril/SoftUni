namespace BattleCards.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Card
    {
        public int Id { get; init; } 

        [Required]
        [MaxLength(CardMaxLenght)]
        public string Name { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        public string Keyword { get; init; }

        [Required]
        public int Attack { get; init; }

        [Required]
        public int Health { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; init; }
        public ICollection<UserCard> UserCards { get; } = new List<UserCard>();
    }
}
