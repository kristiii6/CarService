using System.Security.Policy;

namespace BeautyServices.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int? RoomID { get; set; }
        public Room? Room { get; set; }
    }
}
