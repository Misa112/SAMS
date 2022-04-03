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
        private IStudentService studentService;
        public IEnumerable<Leasing> Leasings { get; set; }
        public Student Student { get; set; }

        public GetLeasingsModel(ILeasingService service, IStudentService studentservice)
        {
            leasingService = service;
            studentService = studentservice;
        }

        public void OnGet()
        {
            Leasings = leasingService.GetAllLeasings();
        }

        public void OnPost(int place_id)
        {
            Student = studentService.GetWaitingList().FirstOrDefault();
            leasingService.AddLeasing(Student.Student_No, place_id);
            Leasings = leasingService.GetAllLeasings();
        }
    }
}
