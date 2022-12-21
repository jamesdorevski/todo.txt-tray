using System;
using System.Runtime.InteropServices;

namespace Todo.Tray;

public static class WinApi
{
    public const int HWND_BROADCAST = 0xffff;
    public const int SW_SHOWNORMAL = 1;
    
    [DllImport("user32", CharSet = CharSet.Unicode)]
    public static extern int RegisterWindowMessage(string message);

    public static int RegisterWindowMessage(string format, params object[] args)
    {
        string message = String.Format(format, args);
        return RegisterWindowMessage(message);
    }

    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    
    [DllImport("user32")]
    public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
 
    [DllImport("user32")]
    public static extern bool SetForegroundWindow(IntPtr hwnd);

    public static void ShowToFront(IntPtr window)
    {
        ShowWindow(window, SW_SHOWNORMAL);
        SetForegroundWindow(window);
    }
}