using System.Reflection;
using System.Runtime.InteropServices;

namespace Todo.Tray;

public static class SingleInstance
{
    static Mutex _mutex;
    public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
    
    public static bool Start()
    {
        bool onlyInstance = false;
        string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);

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