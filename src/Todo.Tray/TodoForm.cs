using System;
using System.Drawing;
using System.Windows.Forms;

namespace Todo.Tray;

internal class TodoForm : Form
{
    private TodoManager _todoManager;

    public TodoForm(TodoManager todoManager)
    {
        _todoManager = todoManager;
        InitializeComponent();
        RenderTodoItems();
    }

    private void RenderTodoItems()
    {
        todoItemTextBox.Text = String.Join(Environment.NewLine, _todoManager.GetTodoItems());
    }

// TODO: fix focus
    public void SetFocus()
    {
        inputTextBox.Focus();
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        _todoManager.AddTodoItem(inputTextBox.Text);
        inputTextBox.Clear();
        RenderTodoItems();
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.addButton = new System.Windows.Forms.Button();
        this.inputTextBox = new System.Windows.Forms.TextBox();
        this.todoItemTextBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // addButton
        // 
        this.addButton.Location = new System.Drawing.Point(197, 226);
        this.addButton.Name = "addButton";
        this.addButton.Size = new System.Drawing.Size(75, 23);
        this.addButton.TabIndex = 0;
        this.addButton.Text = "Add";
        this.addButton.UseVisualStyleBackColor = true;
        this.addButton.Click += new System.EventHandler(this.addButton_Click);
        // 
        // inputTextBox
        // 
        this.inputTextBox.Location = new System.Drawing.Point(12, 187);
        this.inputTextBox.Name = "inputTextBox";
        this.inputTextBox.Size = new System.Drawing.Size(260, 20);
        this.inputTextBox.TabIndex = 1;
        // 
        // todoItemTextBox
        // 
        this.todoItemTextBox.Location = new System.Drawing.Point(10, 12);
        this.todoItemTextBox.Multiline = true;
        this.todoItemTextBox.Name = "todoItemTextBox";
        this.todoItemTextBox.Size = new System.Drawing.Size(262, 158);
        this.todoItemTextBox.TabIndex = 2;
        // 
        // TodoForm
        // 
        this.ClientSize = new System.Drawing.Size(284, 261);
        this.ControlBox = false;
        this.Controls.Add(this.todoItemTextBox);
        this.Controls.Add(this.inputTextBox);
        this.Controls.Add(this.addButton);
        this.Name = "TodoForm";
        this.Deactivate += new System.EventHandler(this.TodoForm_Leave);
        this.Shown += new System.EventHandler(this.TodoForm_Shown);
        this.Leave += new System.EventHandler(this.TodoForm_Leave);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TextBox inputTextBox;
    private System.Windows.Forms.TextBox todoItemTextBox;

    private System.Windows.Forms.Button addButton;

    private void TodoForm_Leave(object sender, EventArgs e)
    {
        this.Close();
    }

    private void TodoForm_Shown(object sender, EventArgs e)
    {
        Rectangle workingArea = Screen.GetWorkingArea(this);
        this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
    }
}