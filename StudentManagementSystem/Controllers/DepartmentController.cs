using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services.Interfaces;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var depts = _departmentRepository.GetDepatments();
            if (depts == null) return NotFound();
            return Ok(depts);
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartment([FromRoute] int id)
        {
            var dept = _departmentRepository.GetDepartment(id);
            if (dept == null) return NotFound();
            return Ok(dept);
        }
    }
}
