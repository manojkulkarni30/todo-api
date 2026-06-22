using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int Category { get; set; }
        public int Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }

    enum Priotity
    {
        Low,
        Medium,
        High,
        Urgent
    }

    enum Category
    {
        General,
        Work,
        Personal,
        Finances,
        Health
    }
}