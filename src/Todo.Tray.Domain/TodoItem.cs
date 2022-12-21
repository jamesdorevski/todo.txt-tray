using System;

namespace Todo.Tray.Domain
{
    public class TodoItem
    {
        private bool IsComplete { get; set; }
        private char Priority { get; set; }
        private DateTime CreationDate = DateTime.Now;
        private DateTime? CompletionDate { get; set; }
        private string Text { get; set; }
    }
}