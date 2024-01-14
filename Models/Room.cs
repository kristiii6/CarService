namespace CarService.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
