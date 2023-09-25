using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string ToDoTitle { get; set; }
        public string? ToDoDescription { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public bool IsComplete { get; set; } = false;
        public string CompletionStatus { get; set; } = IsCompleteStatus.InComplete.ToString();
    }

    public enum IsCompleteStatus
    {
        [Display(Name = "Not Complete")]
        InComplete = 1,
        [Display(Name = "Complete")]
        Complete
    }
}
