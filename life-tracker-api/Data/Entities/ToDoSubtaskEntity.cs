namespace LifeTracker.Data.Entities
{
    public class ToDoSubtaskEntity
    {
        public int Id { get;  set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public int ToDoId { get; set; }
        public ToDoEntity ToDo { get; set; }
    }
}
