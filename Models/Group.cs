namespace CarService.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ServiceGroup>? ServiceGroups { get; set; }
    
}
}
