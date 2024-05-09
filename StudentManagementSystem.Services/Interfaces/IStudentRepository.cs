using StudentManagementSystem.Model.DTO;
using StudentManagementSystem.Model.Models;
using StudentManagementSystem.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Interfaces
{
    public interface IStudentRepository
    {
        //Getting
        Task<List<StudentResponseDTO>> GetStudents();
        Task<StudentResponseDTO> GetStudent(int id);
        Task<List<StudentResponseDTO>> GetStudentByDept(int deptId);

        //Posting
        Task<Student> AddStudent(CreateStudentDTO student);

        //Update
        Task<StudentResponseDTO> UpdateStudent(int id, UpdateStudentDto student);

        //Delete
        Task DeleteStudent(int id);

    }
}
