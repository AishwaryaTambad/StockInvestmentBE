using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Services;
using StockInvestment.Models;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly RepositoryStudent _repository;

        public StudentController(RepositoryStudent repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student= _repository.GetStudentById(id);
            if (student == null)
              return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student1 student)
        {
            if (student == null)
                return BadRequest();

            _repository.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student1 student)
        {
            if (id != student.Id)
                return BadRequest("Student ID mismatch");

            var existingStudent = _repository.GetStudentById(id);

            if (existingStudent == null)
                return NotFound("Student not found");


            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;



            _repository.UpdateStudent(existingStudent);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id, [FromBody] Student1 student) {
            if (id != student.Id)
                return BadRequest("Student ID mismatch");

            var existingStudent = _repository.GetStudentById(id);

            if (existingStudent == null)
                return NotFound("Student not found");

            _repository.DeleteStudent(id);

            return NoContent();
        }


    }
}
