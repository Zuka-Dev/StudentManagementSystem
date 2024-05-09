using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model.DTO
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

    }
}
