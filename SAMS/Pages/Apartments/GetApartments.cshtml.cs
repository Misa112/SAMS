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
        private IApartmentService apartmentService;
        public IEnumerable<Apartment> Apartments { get; set; }

        public GetApartmentsModel(IApartmentService service)
        {
            apartmentService = service;
        }

        public void OnGet()
        {
            Apartments = apartmentService.GetAllApartments();
        }
    }
}
