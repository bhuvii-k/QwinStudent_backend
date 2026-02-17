
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;
namespace WebApplication1.Context
{
    public class Qwincontext:DbContext
    {
        public Qwincontext(DbContextOptions<Qwincontext> option):base(option) { }

        public DbSet<Admin> AdminDetails { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Leave> LeaveRecords { get; set; }

	}
}
