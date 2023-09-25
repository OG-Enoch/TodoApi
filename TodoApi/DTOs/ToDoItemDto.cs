using TodoApi.Models;

namespace TodoApi.DTOs
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string ToDoTitle { get; set; }
        public string? ToDoDescription { get; set; }
        public string CompletionStatus { get; set; } = IsCompleteStatus.InComplete.ToString();

    }
}
