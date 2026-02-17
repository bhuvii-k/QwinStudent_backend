using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.DTOs;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveController : ControllerBase
	{
	
		private readonly Qwincontext _context;

		public LeaveController(Qwincontext context)
		{
			_context = context;
		}

		// ✅ GET ALL LEAVES
		[HttpGet]
		public IActionResult GetLeaves()
		{
			var leaves = _context.LeaveRecords
				.Select(l => new LeaveDto
				{
					Id = l.Id,
					FromDate = l.FromDate,
					ToDate = l.ToDate,
					Reason = l.Reason,
					Status = l.Status,
					StudentId = l.StudentId
				})
				.ToList();

			return Ok(leaves);
		}

		// ✅ GET BY ID
		[HttpGet("{id}")]
		public IActionResult GetLeaveById(int id)
		{
			var leave = _context.LeaveRecords.Find(id);

			if (leave == null)
				return NotFound();

			var leaveDto = new LeaveDto
			{
				Id = leave.Id,
				FromDate = leave.FromDate,
				ToDate = leave.ToDate,
				Reason = leave.Reason,
				Status = leave.Status,
				StudentId = leave.StudentId
			};

			return Ok(leaveDto);
		}

		// ✅ CREATE LEAVE
		[HttpPost]
		public IActionResult CreateLeave(CreateLeaveDto dto)
		{
			// Check if student exists
			var student = _context.Students.Find(dto.StudentId);
			if (student == null)
				return BadRequest("Student not found");

			// Optional: Validate date
			if (dto.ToDate < dto.FromDate)
				return BadRequest("ToDate cannot be before FromDate");

			var leave = new Leave
			{
				FromDate = dto.FromDate,
				ToDate = dto.ToDate,
				Reason = dto.Reason,
				StudentId = dto.StudentId,
				Status = "Pending" // Default status
			};

			_context.LeaveRecords.Add(leave);
			_context.SaveChanges();

			return Ok("Leave Created Successfully");
		}

		// ✅ UPDATE STATUS (Approve / Reject)
		[HttpPut("{id}/status")]
		public IActionResult UpdateStatus(int id, string status)
		{
			var leave = _context.LeaveRecords.Find(id);

			if (leave == null)
				return NotFound();

			leave.Status = status;
			_context.SaveChanges();

			return Ok("Status Updated");
		}

		// ✅ DELETE
		[HttpDelete("{id}")]
		public IActionResult DeleteLeave(int id)
		{
			var leave = _context.LeaveRecords.Find(id);

			if (leave == null)
				return NotFound();

			_context.LeaveRecords.Remove(leave);
			_context.SaveChanges();

			return Ok("Leave Deleted Successfully");
		}
	}
}
