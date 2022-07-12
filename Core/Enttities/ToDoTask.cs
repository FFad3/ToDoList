using System.ComponentModel.DataAnnotations;

namespace Core.Enttities
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public string TaskName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        //Priorytet taska np.High/Low/Medium
        [Required]
        public int PriorytyId { get; set; }

        public Priority Priority { get; set; }
    }
}