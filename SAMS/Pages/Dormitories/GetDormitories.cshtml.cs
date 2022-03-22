using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAMS.Interfaces;
using SAMS.Models;

namespace SAMS.Pages.Dormitories
{
    public class GetDormitoriesModel : PageModel
    {
        private IDormitoryService service;

        public IEnumerable<Dormitory> Dormitories { get; set; }

        public GetDormitoriesModel(IDormitoryService dormitoryService)
        {
            service = dormitoryService;
        }
        public void OnGet()
        {
            Dormitories = service.GetAllDormitories();
        }
    }
}
