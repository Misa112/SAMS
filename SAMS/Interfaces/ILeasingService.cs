using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Interfaces
{
    public interface ILeasingService
    {
        List<Leasing> GetAllLeasings();

        void AddLeasing(int student_id, int place_id);
    }
}
