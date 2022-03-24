using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAMS.Interfaces;
using SAMS.Models;

namespace SAMS.Pages.Students
{
    public class GetWaitingListModel : PageModel
    {
        private IStudentService studentService;
        public IEnumerable<Student> Students { get; set; }

        public int MyProperty { get; set; }

        public GetWaitingListModel(IStudentService service)
        {
            studentService = service;
        }

        public void OnGet()
        {
            Students = studentService.GetWaitingList();
        }
    }
}
