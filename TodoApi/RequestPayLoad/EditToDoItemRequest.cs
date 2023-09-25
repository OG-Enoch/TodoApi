namespace TodoApi.RequestPayLoad
{
    public class EditToDoItemRequest
    {
        public string ToDoTitle { get; set; }
        public string? ToDoDescription { get; set; }
        public bool IsComplete { get; set; }
    }
}
