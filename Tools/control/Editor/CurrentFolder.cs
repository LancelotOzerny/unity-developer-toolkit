using Lancy;
using UnityEditor;
using UnityEngine;
using System.Diagnostics;

public class CurrentFolder : MonoBehaviour
{
    [MenuItem("Lancy/Current Folder")]
    public static new void Show()
    {
        Process.Start("explorer.exe", ".");
    }
}
