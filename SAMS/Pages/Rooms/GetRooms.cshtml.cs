using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAMS.Interfaces;
using SAMS.Models;

namespace SAMS.Pages.Rooms
{
    public class GetRoomsModel : PageModel
    {
        private IRoomService roomService;
        public IEnumerable<Room> Rooms { get; set; }

        public GetRoomsModel(IRoomService service)
        {
            roomService = service;
        }

        public void OnGet()
        {
            Rooms = roomService.GetAllRooms();
        }
    }
}
