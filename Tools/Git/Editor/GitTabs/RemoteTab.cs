using System.Collections.Generic;
using UnityEngine;

namespace Lancy
{
    public class RemoteTab : WindowTab
    {
        private int updateIndex = 0;
        private string remoteName;
        private string remotePath;
        private string clonePath = string.Empty;
        private string[] remotes = new string[] { "none" }; 

        public RemoteTab()
        {
            this.Title = "Remote";
        }

        public override void Show()
        {
            if (Git.Instance().Branches == null)
            {
                return;
            }

            CreateRemote();
            UpdateRemote();
            CloneRepository();
        }

        public void UpdateRemote()
        {
            SetLabel("Update Remote", 60);
            updateIndex = GUILayout.SelectionGrid(updateIndex, remotes, 1);

            GUILayout.Space(20);
            bool isPush = GUILayout.Button("git push", GUILayout.Height(50));

            GUILayout.Space(20);
            bool isPull = GUILayout.Button("git pull", GUILayout.Height(50));
            
            if (isPull)
            {
                Git.Instance().Push();
            }

            if (isPull)
            {
                Git.Instance().Pull();
            }
        }

        public void CreateRemote()
        {
            SetLabel("Create Remote", 60);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Name", GUILayout.Width(100));
            remoteName = GUILayout.TextField(remoteName);
            GUILayout.EndHorizontal();

            GUILayout.Space(20);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Url", GUILayout.Width(100));
            remotePath = GUILayout.TextField(remotePath);
            GUILayout.EndHorizontal();

            GUILayout.Space(20);
            bool button = GUILayout.Button("Create Remote", GUILayout.Height(50));

            GUILayout.Space(20);
            if (button)
            {
                if (remotePath == string.Empty || remoteName == string.Empty)
                {
                    Debug.LogError("Empty remote name or remote path");
                }
                else
                {
                    Git.Instance().CreateRemote(remoteName, remotePath);
                    remoteName = string.Empty;
                    remotePath = string.Empty;
                }
            }
        }

        public void CloneRepository()
        {
            SetLabel("Repository Clone", 60);
            clonePath = GUILayout.TextField(clonePath);
            GUILayout.Space(20);
            bool button = GUILayout.Button("Clone", GUILayout.Height(50));

            if (button)
            {
                Git.Instance().Clone(clonePath);
            }
        }
    }
}