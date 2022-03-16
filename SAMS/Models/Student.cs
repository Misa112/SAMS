using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models
{
    public class Student
    {
        public int Student_No { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public bool Has_Room { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
