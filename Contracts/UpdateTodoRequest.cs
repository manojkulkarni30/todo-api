using System.ComponentModel.DataAnnotations;

namespace TodoApi.Contracts
{
    public class UpdateTodoRequest
    {
        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool? IsCompleted { get; set; } = false;

        [Required]
        public int Category { get; set; }

        [Required]
        public int Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ReminderDate { get; set; }
    }
}