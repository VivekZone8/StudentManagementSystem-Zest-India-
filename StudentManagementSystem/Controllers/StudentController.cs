using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Interface;
using StudentManagementSystem.Models;

namespace StudentManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]  
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _studentInterface;

        public StudentController(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface;
        }

        // Add New Student
        [HttpPost("AddNewStudent")]
        public async Task<IActionResult> AddNewStudent(CreateStudentRequest request)
        {
            var res = await _studentInterface.CreateNewStudent(request);
            return Ok(res);
        }

        // Get all students
        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var res = await _studentInterface.AllStudent(); 
            return Ok(res);
        }

        // Update student
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentRequest request)
        {
            var res = await _studentInterface.UpdateStudent(request);
            return Ok(res);
        }

        // Delete student
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var res = await _studentInterface.DeleteStudent(id);
            return Ok(res);
        }
    }
}