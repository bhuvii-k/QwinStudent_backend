namespace WebApplication1.models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int Age { get; set; }
		public string Email { get; set; }
		public int Phone { get; set; }

		public string GuardianName { get; set; }

		public string GuardianContact { get; set; }

		public string Address { get; set; }
		public string Place { get; set; }
		public string Education { get; set; }
		public int Yeargap { get; set; }
		public string Password { get; set; }




		public ICollection<Leave> LeaveRecords { get; set; }
	}

}
