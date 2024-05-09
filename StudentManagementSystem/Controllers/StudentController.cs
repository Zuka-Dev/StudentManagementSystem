using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Model.DTO;
using StudentManagementSystem.Services.Helpers;
using StudentManagementSystem.Services.Interfaces;
using StudentManagementSystem.Services.Repositories;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            if (students == null) return NotFound();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("/Department/{id}")]
        public async Task<IActionResult> GetStudentByDept([FromRoute] int id)
        {
            var students = await _studentRepository.GetStudentByDept(id);
            if (students == null) return NotFound();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDTO studentDTO)
        {
            var obj = await _studentRepository.AddStudent(studentDTO);
            return CreatedAtAction(nameof(GetStudent), new { id = obj.Id }, obj.ToStudentDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            await _studentRepository.DeleteStudent(id);
            return Ok(new Dictionary<string,string>()
            {
                {"message","Successfully Deleted" }
            });
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int id , [FromBody] UpdateStudentDto student)
        {
            var updatedStudent =await _studentRepository.UpdateStudent(id, student);
            return Ok(updatedStudent);
            
        }
    }
}
