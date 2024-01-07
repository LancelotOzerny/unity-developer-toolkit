using UnityEditor;

namespace Lancy
{
    public class WConsole : EditorWindow
    {
        [MenuItem("Lancy/Console")]
        public static new void Show()
        {
            System.Diagnostics.Process.Start("cmd.exe");
        }

        public static void Run(string command)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/C" + command);
            System.Threading.Thread.Sleep(150);
        }
    }
}