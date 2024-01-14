namespace CarService.Models
{
    public class ServiceGroup
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
