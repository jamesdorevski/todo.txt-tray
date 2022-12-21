using System;
using System.Text;
using System.Text.RegularExpressions;
using Todo.Tray.Domain;

namespace Todo.Tray.Infrastructure
{
    internal class TodoItemSerializer
    {
        const char COMPLETE_FLAG = 'x';
        const string DATE_FORMAT = "yyyy-MM-dd";
        const string TODO_LINE_EXPRESSION = @"^((x) )?((\(\w\)) )?([\d]{4}-[\d]{2}-[\d]{2} )?([\d]{4}-[\d]{2}-[\d]{2} ?)(.*)$";
        
        public string Serialize(TodoItem input)
        {
            StringBuilder sb = new StringBuilder();

            if (input.IsComplete)
            {
                sb.Append(COMPLETE_FLAG);
                sb.Append(' ');
            }

            if (input.Priority != null)
            {
                sb.Append($"({input.Priority})");
                sb.Append(' ');
            }

            if (input.CompletionDate != null)
            {
                sb.Append(input.CompletionDate.Value.ToString(DATE_FORMAT));
                sb.Append(' ');
            }

            if (input.CompletionDate != null && input.CreationDate == null)
            {
                throw new FormatException("Cannot have a completion date without a creation date");
            }

            if (input.CreationDate != null)
            {
                sb.Append(input.CreationDate.Value.ToString(DATE_FORMAT));
                sb.Append(' ');
            }

            sb.Append(input.Text);
            
            // TODO: add project tag, context and key/value tag

            return sb.ToString();
        }

        public TodoItem Deserialize(string input)
        {
            string[] matches = Regex.Matches(input, TODO_LINE_EXPRESSION);
        }
    }
}