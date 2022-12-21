using System;
using System.Collections.Generic;

namespace Todo.Tray;

internal class TodoManager
{
    private List<string> _todoItems = new List<string>();
    
    public void AddTodoItem(string input)
    {
        // TODO: sanitise input
        _todoItems.Add(input);
        // TODO: add save function to serailise and push it into file 
    }
    
    public string[] GetTodoItems()
    {
        return _todoItems.ToArray();
    }

    private void SaveFile()
    {
        throw new NotImplementedException();
    }
    
    public void LoadFile()
    {
        // call repository to grab file
        throw new NotImplementedException();
    }
}