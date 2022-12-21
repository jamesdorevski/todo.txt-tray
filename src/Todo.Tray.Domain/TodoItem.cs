using System;

namespace Todo.Tray.Domain
{
    public class TodoItem
    {
        public bool IsComplete { get; set; }
        public char? Priority { get; set; }
        public DateTime? CreationDate = DateTime.Now;
        public DateTime? CompletionDate { get; set; }
        public string Text { get; set; }
    }
}