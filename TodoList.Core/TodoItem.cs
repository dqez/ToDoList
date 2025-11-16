namespace TodoList.Core
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime UpdatedDate { get; set; }= DateTime.Now;

    }
}
