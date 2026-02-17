namespace WebApplication1.models
{
	public class Leave
	{
		public int Id { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Reason { get; set; }

		public string Status { get; set; }

		// Foreign Key
		public int StudentId { get; set; }

		// Navigation Property
		public Student Student { get; set; }

	}

}
