using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautyServices.Data;
using BeautyServices.Models;

namespace BeautyServices.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly BeautyServices.Data.BeautyServicesContext _context;

        public IndexModel(BeautyServices.Data.BeautyServicesContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Room != null)
            {
                Room = await _context.Room.ToListAsync();
            }
        }
    }
}
