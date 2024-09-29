using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Adress
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string?  Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        //configure one to one by EntityFrameWork using class and ID c:
        [Required]
        public string AppUserId { get; set; } //foreign key
        public AppUser Appuser { get; set; }
    }
}