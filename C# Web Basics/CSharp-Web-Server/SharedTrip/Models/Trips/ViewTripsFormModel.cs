namespace SharedTrip.Models.Trips
{

    public class ViewTripsFormModel
    {
        public string Id { get; init; }
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public string DepartureTime { get; set; }
        public string ImagePath { get; init; }
        public byte Seats { get; init; }
        public string Description { get; init; }
    }
}
