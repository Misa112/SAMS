using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAMS.Interfaces;
using SAMS.Models;
using SAMS.Services;

namespace SAMS.Pages.Leasings
{
    public class GetLeasingsModel : PageModel
    {
        private ILeasingService leasingService;
        public IEnumerable<Leasing> Leasings { get; set; }

        public GetLeasingsModel(ILeasingService service)
        {
            leasingService = service;
        }

        public void OnGet()
        {
            Leasings = leasingService.GetAllLeasings();
        }
    }
}
