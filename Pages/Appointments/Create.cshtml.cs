using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarService.Data;
using CarService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.Pages.Appointments
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
            var serviceList = _context.Service
                .Select(x => new SelectListItem
                {
                    Value = x.ServiceId.ToString(),
                    Text = $"{x.Name} - {x.Price:C}"  // Display both name and price, adjust as needed
                }).ToList();
            ViewData["ServiceId"] = new SelectList(serviceList, "Value", "Text");


            var clientList = _context.Client
            .Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.FullName // Adjust property based on your Client class
            }).ToList();

            ViewData["ClientID"] = new SelectList(clientList, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Appointment == null || Appointment == null)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
