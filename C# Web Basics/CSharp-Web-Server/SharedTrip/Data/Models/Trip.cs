namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Trip
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        public DateTime DepartureTime { get; init; }

        public byte Seats { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; init; }

        public string ImagePath { get; init; }

        public ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();
    }
}
