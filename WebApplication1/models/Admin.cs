using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string Role {  get; set; }
        public string password {  get; set; }
        

    }
}
