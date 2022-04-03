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
    public class GetStudentsModel : PageModel
    {
        private IStudentService studentService;
        public IEnumerable<Student> Students { get; set; }

        public GetStudentsModel(IStudentService service)
        {
            studentService = service;
        }

        public void OnGet()
        {
            Students = studentService.GetAllStudents();
        }

        public void OnPost(int student_id)
        {
            studentService.DeleteStudent(student_id);
            Students = studentService.GetAllStudents();
        }
    }
}
