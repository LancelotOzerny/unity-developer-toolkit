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
                    "Сброс изменений",
                    "Вы действительно хотите сбрость текущие GIT изменения?", 
                    "Да", 
                    "Нет")
                    )
                {
                    Git.Instance().IndexAll();
                    Git.Instance().Reset();
                }
            }
        }
    }
}