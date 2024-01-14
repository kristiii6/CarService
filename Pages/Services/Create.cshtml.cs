using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarService.Data;
using CarService.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace CarService.Pages.Services
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ServiceGroupsPageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public CreateModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID",
"RoomName");
            var service = new Service();
            service.ServiceGroups = new List<ServiceGroup>();
            PopulateAssignedGroupData(_context, service);
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedGroups)
        {
            var newService = new Service();
            if(selectedGroups != null)
            {
                newService.ServiceGroups = new List<ServiceGroup>();
                foreach (var gr in selectedGroups)
                {
                    var grToAdd = new ServiceGroup
                    {
                        GroupID = int.Parse(gr)

                    };
                    newService.ServiceGroups.Add(grToAdd);
                }
            }

            Service.ServiceGroups = newService.ServiceGroups;

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
