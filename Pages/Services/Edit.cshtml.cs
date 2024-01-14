using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarService.Pages.Services
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ServiceGroupsPageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public EditModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            Service = await _context.Service
                .Include(s => s.Room)
                .Include(s => s.ServiceGroups)
                .ThenInclude(s => s.Group)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ServiceId == id);

            //         var service =  await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
            if (Service == null)
            {
                return NotFound();
            }

            PopulateAssignedGroupData(_context, Service);


            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "RoomName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGroups)
        {
            if (id == null)
            {
                return NotFound();
            }

            //_context.Attach(Service).State = EntityState.Modified;

            var serviceToUpdate = await _context.Service
                .Include(i => i.Room)
                .Include(i => i.ServiceGroups)
                .ThenInclude(i => i.Group)
                .FirstOrDefaultAsync(s => s.ServiceId == id);
            if (serviceToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Service>(
                serviceToUpdate,
                "Service",
                i => i.Name, i => i.Price, i => i.RoomID))
            {
                UpdateServiceGroups(_context, selectedGroups, serviceToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }

            UpdateServiceGroups(_context, selectedGroups, serviceToUpdate);
            PopulateAssignedGroupData(_context, serviceToUpdate);
            return Page();
        }
    }
}
