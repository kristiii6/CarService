using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;

namespace CarService.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public DeleteModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Group Group { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }

            var group = await _context.Group.FirstOrDefaultAsync(m => m.ID == id);

            if (group == null)
            {
                return NotFound();
            }
            else 
            {
                Group = group;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }
            var group = await _context.Group.FindAsync(id);

            if (group != null)
            {
                Group = group;
                _context.Group.Remove(Group);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
