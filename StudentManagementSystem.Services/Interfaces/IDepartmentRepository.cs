using StudentManagementSystem.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Interfaces
{
    public interface IDepartmentRepository
    {
        List<DepartmentDTO> GetDepatments();

        DepartmentDTO GetDepartment(int id);

      //  DepartmentDTO AddDepartment 
    }
}
