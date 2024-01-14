namespace CarService.Models.ViewModels
{
    public class RoomIndexData
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
