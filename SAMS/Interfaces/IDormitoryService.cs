using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Interfaces
{
    public interface IDormitoryService
    {
        List<Dormitory> GetAllDormitories();
    }
}
