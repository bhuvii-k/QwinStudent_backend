namespace WebApplication1.DTOs
{
	public class CreateLeaveDto
	{
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Reason { get; set; }
		public int StudentId { get; set; }
	}
}
