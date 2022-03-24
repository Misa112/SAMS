using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();

        StudentInfo GetStudentInfo(int id);

        List<Student> GetWaitingList();
    }
}
