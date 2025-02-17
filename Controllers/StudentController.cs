using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IServices;
using DotNetCRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent_Services _studentServices;

        public StudentController(IStudent_Services services)
        {
            _studentServices = services;
        }

        [HttpPost]
        public async Task<ActionResult<Student_ResponseDTO>> AddStudent(Student_RequestDTO student)
        {
            var createdStudent = await _studentServices.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student_ResponseDTO>> GetStudentById(int id)
        {
            var student = await _studentServices.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Student_ResponseDTO>>> GetAllStudents()
        {
            var students = await _studentServices.GetAllStudents();
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student_ResponseDTO>> UpdateStudent(int id, Student_RequestDTO student)
        {
            var updatedStudent = await _studentServices.UpdateStudent(id, student);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var result = await _studentServices.DeleteStudent(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
