using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Todo.Tray.Application.Interfaces;
using Todo.Tray.Domain;

namespace Todo.Tray.Infrastructure
{
    internal class TextFileRepository : IFileRepository
    {
        TodoItemSerializer _serializer = new TodoItemSerializer();
        string _todoFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "todo.txt");
        
        public void Save(IReadOnlyCollection<TodoItem> items)
        {
            string[] serialisedItems = items
                .Select(_serializer.Serialize)
                .ToArray();
            
            File.WriteAllLines(_todoFilePath, serialisedItems);
        }

        public IEnumerable<TodoItem> GetItems()
        {
            using FileStream fs = new FileStream(_todoFilePath, FileMode.OpenOrCreate);
            using StreamReader sr = new StreamReader(fs);

            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return _serializer.Deserialize(line);
            }
        }
    }
}