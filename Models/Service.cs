using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace CarService.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        
        public decimal Price { get; set; }

        public int? RoomID { get; set; }
        public Room? Room { get; set; }

        public int? AppointmentID { get; set; }
        [ForeignKey("AppointmentID")]
        public Appointment? Appointment { get; set; }

        public ICollection<ServiceGroup>? ServiceGroups
        {
            get; set;
        }
        }
}
