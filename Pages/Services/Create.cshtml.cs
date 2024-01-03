using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeautyServices.Data;
using BeautyServices.Models;
using System.Security.Policy;

namespace BeautyServices.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly BeautyServices.Data.BeautyServicesContext _context;

        public CreateModel(BeautyServices.Data.BeautyServicesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID",
"RoomName");
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Service == null || Service == null)
            {
                return Page();
            }

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
