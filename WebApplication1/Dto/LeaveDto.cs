namespace WebApplication1.DTOs
{
	public class LeaveDto
	{
		public int Id { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Reason { get; set; }
		public string Status { get; set; }
		public int StudentId { get; set; }
	}
}
