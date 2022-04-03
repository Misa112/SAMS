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
    public class GetVacantsRoomInRangeModel : PageModel
    {
        private IRoomService roomService;
        public IEnumerable<Room> Rooms { get; set; }

        public GetVacantsRoomInRangeModel(IRoomService service)
        {
            roomService = service;
        }

        public void OnGet(int id, string type)
        {
            Rooms = roomService.GetRoomsInRange(id, type);
        }

    }
}
