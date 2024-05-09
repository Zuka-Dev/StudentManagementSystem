using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Model.DTO;
using StudentManagementSystem.Model.Models;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext _context;

        public StudentRepository(StudentManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudent(CreateStudentDTO studentRequest)
        {
            try {
                var student = studentRequest.ToStudent();
                student.RegistrationNumber = GenerateRegNumber.GetRegNumber(student.DateofAdmission);
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            _context.Students.Remove(student);
            _context.SaveChangesAsync();
        }

        public async Task<StudentResponseDTO> GetStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            var studentDTO = student.ToStudentDTO();
            return studentDTO;
        }

        public async Task<List<StudentResponseDTO>> GetStudentByDept(int deptId)
        {
            var students = await _context.Students.Where(s => s.DepartmentId == deptId).Select(s => s.ToStudentDTO()).ToListAsync();
            return students;
        }

        public async Task<List<StudentResponseDTO>> GetStudents()
        {
            var students = await _context.Students.Select(s => s.ToStudentDTO()).ToListAsync();
            return students;
        }

        public async Task<StudentResponseDTO> UpdateStudent(int id, UpdateStudentDto studentToChange)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            student.FirstName = studentToChange.FirstName;
            student.LastName = studentToChange.LastName;
            student.MiddleName = studentToChange.MiddleName;
           await _context.SaveChangesAsync();
            return student.ToStudentDTO(); 
        }
    }
}
