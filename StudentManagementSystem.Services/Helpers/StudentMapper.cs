using StudentManagementSystem.Model.Models;
using StudentManagementSystem.Model.DTO;

namespace StudentManagementSystem.Services.Helpers
{
    public static class StudentMapper
    {
        public static StudentResponseDTO ToStudentDTO(this Student student)
        {
            return new StudentResponseDTO
            {
                Id = student.Id,
                RegistrationNumber = student.RegistrationNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                DepartmentId = student.DepartmentId

            };

        }
        public static Student ToStudent(this CreateStudentDTO student)
        {
            return new Student
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                DepartmentId = student.DepartmentId

            };
        }
        public static DepartmentDTO ToDeptDTO(this Department dept)
        {
            return new DepartmentDTO
            {
                Id = dept.Id,
                Name = dept.Name

            };
        }
    }
}
