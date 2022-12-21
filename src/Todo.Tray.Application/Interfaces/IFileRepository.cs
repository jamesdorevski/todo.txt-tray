using System;
using System.Collections.Generic;
using Todo.Tray.Domain;

namespace Todo.Tray.Application.Interfaces
{
    public interface IFileRepository
    {
        void Save(IReadOnlyCollection<TodoItem> item);
        IEnumerable<TodoItem> GetItems();
    }
}