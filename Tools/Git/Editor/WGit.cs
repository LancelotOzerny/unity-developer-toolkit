using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Lancy
{
    public class WGit : EditorWindow
    {
        [MenuItem("Lancy/Git")]
        public static new void Show()
        {
            EditorWindow.GetWindow(typeof(WGit));
        }
    
        private List<WindowTab> tabs = new List<WindowTab>();
        private List<string> tabTitles = new List<string>();
        private int currentTabIndex = 0;

        private InitTab init = new InitTab();

        public WGit()
        {
            tabs.Add(new CommitTab());
            tabs.Add(new BranchTab());
            tabs.Add(new RemoteTab());
            tabs.Add(new ResetTab());

            foreach (WindowTab tab in tabs)
            {
                tabTitles.Add(tab.Title);
            }
        }

        private void OnGUI()
        {
            if (Git.Instance().Exist() == false)
            {
                GUILayout.Toolbar(1, new string[] { init.Title });
                init.Show();
                return;
            }

            currentTabIndex = GUILayout.Toolbar(currentTabIndex, tabTitles.ToArray());
            tabs[currentTabIndex].Show();
        }
    }
}