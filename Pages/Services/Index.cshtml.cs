using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautyServices.Data;
using BeautyServices.Models;

namespace BeautyServices.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly BeautyServices.Data.BeautyServicesContext _context;

        public IndexModel(BeautyServices.Data.BeautyServicesContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Service != null)
            {
                Service = await _context.Service
                    .Include(s=>s.Room)
                    .ToListAsync();
            }
        }
    }
}
