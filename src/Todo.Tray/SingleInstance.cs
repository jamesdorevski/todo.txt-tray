using System.Reflection;
using System.Runtime.InteropServices;

namespace Todo.Tray;

public static class SingleInstance
{
    static string APPLICATION_GUID = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper();
    static Mutex _mutex;

    public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", APPLICATION_GUID);
    
    public static bool Start()
    {
        bool onlyInstance = false;
        string mutexName = String.Format("Local\\{0}", APPLICATION_GUID);

        _mutex = new Mutex(true, mutexName, out onlyInstance);
        return onlyInstance;
    }

    public static void ShowFirstInstance()
    {
        WinApi.PostMessage((IntPtr)WinApi.HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
    }

    public static void Stop()
    {
        _mutex.ReleaseMutex();
    }
}