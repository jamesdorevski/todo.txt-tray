namespace Todo.Tray;

internal static class ProgramInfo
{
    public static string AssemblyGuid
    {
        get
        {
            // TODO: determine how to get assembly guid
            // object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            // if (attributes.Length == 0) {
            //     return String.Empty;
            // }
            // return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;

            return "df1008f4-0e96-4066-959a-00f6d7b16e63";
        }
    }
}