using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAMS.Interfaces;
using SAMS.Models;

namespace SAMS.Pages.Apartments
{
    public class GetApartmentsModel : PageModel
    {
        private IApartmentService service;
        public IEnumerable<Apartment> Apartments { get; set; }

        public GetApartmentsModel(IApartmentService apartmentService)
        {
            service = apartmentService;
        }
        public void OnGet()
        {
            Apartments = service.GetAllApartments();
        }
    }
}
