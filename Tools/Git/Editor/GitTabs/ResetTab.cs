using UnityEditor;
using UnityEngine;

namespace Lancy
{
    public class ResetTab : WindowTab
    {
        public ResetTab()
        {
            this.Title = "Reset";
        }

        public override void Show()
        {
            SetLabel("Reset Tab");
            bool isReset = GUILayout.Button("Reset", GUILayout.Height(50));
            
            if (isReset)
            {
                if (EditorUtility.DisplayDialog(
                    "����� ���������",
                    "�� ������������� ������ ������� ������� GIT ���������?", 
                    "��", 
                    "���")
                    )
                {
                    Git.Instance().IndexAll();
                    Git.Instance().Reset();
                }
            }
        }
    }
}