using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;
using CarService.Models.ViewModels;

namespace CarService.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly CarService.Data.CarServiceContext _context;

        public IndexModel(CarService.Data.CarServiceContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public RoomIndexData RoomIndexData { get; set; }
        public int RoomID { get; set; }
        public int ServiceId { get; set; }

        public async Task OnGetAsync(int? id, int? serviceID)
        {
            RoomIndexData = new RoomIndexData();
            RoomIndexData.Rooms = await _context.Room
                .Include(i=>i.Services)
                .OrderBy(i=>i.RoomName)
                .ToListAsync();

            if (id != null)
            {
                RoomID = id.Value;
                Room room = RoomIndexData.Rooms
                    .Where(i => i.ID == id.Value).Single();
                RoomIndexData.Services = room.Services;
            }


           /* if (_context.Room != null)
            {
                Room = await _context.Room.ToListAsync();
            }*/
        }
    }
}
