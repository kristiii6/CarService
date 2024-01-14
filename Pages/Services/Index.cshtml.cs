using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;

namespace CarService.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public IndexModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } 
        public ServiceData ServiceD {  get; set; }
        public int ServiceId {  get; set; }
        public int GroupID { get; set; }

        public string NameSort { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? groupID, string sortOrder, string searchString)
        {
            ServiceD = new ServiceData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Service> servicesQuery = _context.Service
                .Include(s => s.Room)
                .Include(s => s.ServiceGroups)
                .ThenInclude(s => s.Group)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                servicesQuery = servicesQuery.Where(s => s.Name.Contains(searchString));
            }

            ServiceD.Services = await servicesQuery
                .OrderBy(s => s.Name)
                .ToListAsync();

            if (id != null)
            {
                ServiceId = id.Value;
                Service service = ServiceD.Services.SingleOrDefault(i => i.ServiceId == id.Value);
                ServiceD.Groups = service?.ServiceGroups?.Select(s => s.Group);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ServiceD.Services = ServiceD.Services.OrderByDescending(s => s.Name).ToList();
                    break;
                default:
                    ServiceD.Services = ServiceD.Services.OrderBy(s => s.Name).ToList();
                    break;
            }
        }



        /* public async Task OnGetAsync(int? id, int? groupID, string sortOrder, string searchString)
         {
             ServiceD = new ServiceData();

             NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

             CurrentFilter = searchString;

             if (!String.IsNullOrEmpty(searchString))
             {
                 ServiceD.Services = ServiceD.Services.Where(s => s.Name.Contains(searchString));
             }

             ServiceD.Services = await _context.Service
                 .Include(s => s.Room)
                 .Include(s => s.ServiceGroups)
                 .ThenInclude(s => s.Group)
                 .AsNoTracking()
                 .OrderBy(s => s.Name)
                 .ToListAsync();


             if (id != null)
             {
                 ServiceId = id.Value;
                 Service service = ServiceD.Services
                     .Where(i => i.ServiceId == id.Value).Single();
                 ServiceD.Groups = service.ServiceGroups.Select(s => s.Group);
             }

             switch(sortOrder)
             {
                 case "name_desc":
                     ServiceD.Services = ServiceD.Services.OrderByDescending(s => s.Name);
                     break;
                 default:
                     ServiceD.Services = ServiceD.Services.OrderBy(s => s.Name);
                     break;
             }
         }*/
    }
}
