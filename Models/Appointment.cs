using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiceID { get; set; }
        public Service? Service { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
