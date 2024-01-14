using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;

namespace CarService.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public IndexModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            if (_context.Appointment != null)
            {
                Appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a=>a.Service)
                .ToListAsync();
            }
        }
    }
}
