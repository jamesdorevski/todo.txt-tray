using System.ComponentModel;

namespace Todo.Tray;

public class CustomApplicationContext : ApplicationContext
{ 
    NotifyIcon _notifyIcon;
    IContainer _components;

    public CustomApplicationContext()
    {
        InitialiseContext();
        
        // work setup goes here
        
    }
    
    void InitialiseContext()
    {
        _components = new System.ComponentModel.Container();
        _notifyIcon = new NotifyIcon(_components)
        {
            ContextMenuStrip = new ContextMenuStrip(),
            Icon = new Icon(Path.Combine("Assets", "text-file.ico")),
            Text = "Hello World!",
            Visible = true
        };

        _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
        _notifyIcon.DoubleClick += notifyIcon_DoubleClick;
    }

    void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
        e.Cancel = false;
        
        // work goes here 
    }

    void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
        // TODO: work 
    }

    void exitItem_Click(object sender, EventArgs e)
    {
        ExitThread();
    }
}