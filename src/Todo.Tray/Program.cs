using System;
using System.Windows.Forms;

namespace Todo.Tray;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        if (!SingleInstance.Start())
        {
            SingleInstance.ShowFirstInstance();
            return;
        }

        try
        {
            // ApplicationConfiguration.Initialize();
            ApplicationContext appContext = new CustomApplicationContext();
            Application.Run(appContext);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        
        SingleInstance.Stop();
    }
}