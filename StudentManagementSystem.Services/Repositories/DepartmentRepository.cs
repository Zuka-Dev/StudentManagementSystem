using StudentManagementSystem.Model.DTO;
using StudentManagementSystem.Services.Data;
using StudentManagementSystem.Services.Helpers;
using StudentManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentManagementDbContext _context;
        public DepartmentRepository(StudentManagementDbContext context)
        {
            _context = context;
        }
        //Getting Department based on the Id
        public DepartmentDTO GetDepartment(int id)
        {
            var dept = _context.Departments.FirstOrDefault(d => d.Id == id);
            var deptDto = dept.ToDeptDTO();
            return deptDto;
        }

        public List<DepartmentDTO> GetDepatments()
        {
            var deptList = _context.Departments.Select(d => d.ToDeptDTO()).ToList();
            return deptList;

        }
    }
}
