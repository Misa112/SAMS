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
    public class GetStudentInfoModel : PageModel
    {
        private IStudentService studentService;
        public StudentInfo Student { get; set; }

        public GetStudentInfoModel(IStudentService service)
        {
            studentService = service;
        }

        public void OnGet(int id)
        {
            Student = studentService.GetStudentInfo(id);
        }
    }
}
