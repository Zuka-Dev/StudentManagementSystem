using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model.Models
{
     
    public class Student
    {
        [Required]
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public DateTime DateofAdmission { get; set; } = DateTime.Now;
        //Navigation Component

        public Department Department { get; set; }


    }
}
