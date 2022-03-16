using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int MyProperty { get; set; }
    }
}
