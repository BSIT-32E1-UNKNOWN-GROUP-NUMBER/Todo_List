

namespace Todo_List.Models
{
        public class TaskModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime DueDate { get; set; }
        public string PriorityLevel { get; set; } = "Default"; 
        public bool CompletionStatus { get; set; } 
    }
}
