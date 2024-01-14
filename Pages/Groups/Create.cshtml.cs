using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarService.Data;
using CarService.Models;

namespace CarService.Pages.Groups
{
    public class CreateModel : PageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public CreateModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Group Group { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Group == null || Group == null)
            {
                return Page();
            }

            _context.Group.Add(Group);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
