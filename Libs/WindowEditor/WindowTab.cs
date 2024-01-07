using UnityEngine;

namespace Lancy
{
    abstract public class WindowTab
    {
        public string Title { get; protected set; }
        public abstract void Show();

        protected void SetLabel(string text, int height = 60)
        {
            GUILayout.Label(text, GUILayout.Height(height));
        }
    }
}