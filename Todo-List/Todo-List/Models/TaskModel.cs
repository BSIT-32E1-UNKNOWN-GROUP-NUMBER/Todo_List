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

        // Foreign key for User
        public int UserId { get; set; }

        // Navigation property
        public User? User { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        // Navigation property
        public ICollection<TaskModel>? Tasks { get; set; }
    }
}