namespace CarService.Models
{
    public class ServiceData
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<ServiceGroup> ServiceGroups { get; set; }
    }

}