namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserTrip
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
