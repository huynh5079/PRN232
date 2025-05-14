using APIExamplePRN232.Data.Entities;
using APIExamplePRN232.Data.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIExamplePRN232.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _repository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repository.Add(student);
            _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.StudentID) return BadRequest();

            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            _repository.Update(student);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return NotFound();

            _repository.Delete(id);
            _repository.Save();
            return NoContent();
        }
    }

}
