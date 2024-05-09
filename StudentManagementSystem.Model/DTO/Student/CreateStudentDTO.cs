using StudentManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model.DTO.Student
{
    class CreateStudentDTO
    {
        public string RegistrationNumber { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        //Navigation Component

    }
}
