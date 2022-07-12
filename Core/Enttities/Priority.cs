using System.ComponentModel.DataAnnotations;

namespace Core.Enttities
{
    public class Priority
    {
        public int Id { get; set; }

        [Required]
        public string PriorytyLevel { get; set; }
    }
}