using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.DTOs;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
	{
         
        private readonly Qwincontext _context;

		public StudentController(Qwincontext context)
		{
			_context = context;
		}

		//Get all
		[HttpGet]
		public IActionResult GetStudents()
		{
			var students = _context.Students
				.Select(s => new StudentDto
				{
					Id = s.Id,
					Name = s.Name,
					Age = s.Age,
					Email = s.Email,
					Phone = s.Phone,
					GuardianName = s.GuardianName,
					GuardianContact = s.GuardianContact,
					Address = s.Address,
					Place = s.Place,
					Education = s.Education,
					Yeargap = s.Yeargap
				})
				.ToList();

			return Ok(students);
		}

		// GET BY ID
		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id)
		{
			var student = _context.Students.Find(id);

			if (student == null)
				return NotFound();

			var studentDto = new StudentDto
			{
				Id = student.Id,
				Name = student.Name,
				Age = student.Age,
				Email = student.Email,
				Phone = student.Phone,
				GuardianName = student.GuardianName,
				GuardianContact = student.GuardianContact,
				Address = student.Address,
				Place = student.Place,
				Education = student.Education,
				Yeargap = student.Yeargap
			};

			return Ok(studentDto);
		}

		//Create student
		[HttpPost]
		public IActionResult CreateStudent(CreateStudentDto dto)
		{
			var student = new Student
			{
				Name = dto.Name,
				Age = dto.Age,
				Email = dto.Email,
				Phone = dto.Phone,
				GuardianName = dto.GuardianName,
				GuardianContact = dto.GuardianContact,
				Address = dto.Address,
				Place = dto.Place,
				Education = dto.Education,
				Yeargap = dto.Yeargap,
				Password = dto.Password
			};

			_context.Students.Add(student);
			_context.SaveChanges();

			return Ok(student);
		}

		// DELETE student
		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			var student = _context.Students.Find(id);

			if (student == null)
				return NotFound();

			_context.Students.Remove(student);
			_context.SaveChanges();

			return Ok("Deleted Successfully");
		}
	}
}

