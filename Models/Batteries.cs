namespace MvcMovie.Models
{
    public class Battery
    {
        public long Id { get; set; }
        public string? battery_type { get; set; }
        public string? Status { get; set; }
        public long building_id { get; set; }   

    }
}