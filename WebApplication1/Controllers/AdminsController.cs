using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminsController : ControllerBase
	{
		private readonly Qwincontext _context;

		public AdminsController(Qwincontext context)
		{
			_context = context;
		}

		// GET: api/Admins
		[HttpGet]
		public IActionResult GetAdmins()
		{
			var admins = _context.AdminDetails.ToList();
			return Ok(admins);
		}

		// GET: api/Admins/5
		[HttpGet("{id}")]
		public IActionResult GetAdmin(int id)
		{
			var admin = _context.AdminDetails.Find(id);

			if (admin == null)
				return NotFound();

			return Ok(admin);
		}

		// POST: api/Admins
		[HttpPost]
		public IActionResult CreateAdmin(Admin admin)
		{
			_context.AdminDetails.Add(admin);
			_context.SaveChanges();

			return Ok(admin);
		}

		// PUT: api/Admins/5
		[HttpPut("{id}")]
		public IActionResult UpdateAdmin(int id, Admin admin)
		{
			if (id != admin.Id)
				return BadRequest();

			_context.Entry(admin).State = EntityState.Modified;
			_context.SaveChanges();

			return Ok(admin);
		}

		// DELETE: api/Admins/5
		[HttpDelete("{id}")]
		public IActionResult DeleteAdmin(int id)
		{
			var admin = _context.AdminDetails.Find(id);

			if (admin == null)
				return NotFound();

			_context.AdminDetails.Remove(admin);
			_context.SaveChanges();

			return Ok("Deleted Successfully");
		}
	}
}
