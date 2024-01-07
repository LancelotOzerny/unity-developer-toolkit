using Codice.Client.BaseCommands.Import;
using Codice.Client.Common.GameUI;
using UnityEditor;
using UnityEngine;

namespace Lancy
{
    public class CommitTab : WindowTab
    {
        private string commitMessage;
        private string lastCommitMessage;
        private bool isAmend;
        bool startCommit;

        public CommitTab()
        {
            this.Title = "Commits";
        }

        public override void Show()
        {
            Indexing();
            Commit();
        }

        Vector2 commitesView = new Vector2();
        private void Commit()
        {
            SetLabel("Commites");
            GUILayout.Label("Commit Area", GUILayout.Height(50));
            commitMessage = GUILayout.TextArea(commitMessage, GUILayout.Height(100));

            SetLabel("Commites");
            commitesView = GUILayout.BeginScrollView(commitesView, GUILayout.Height(200));
            GUILayout.Label(Git.Instance().GetCommites());
            GUILayout.EndScrollView();

            isAmend = GUILayout.Toggle(isAmend, "Amend", GUILayout.Height(50));
            startCommit = GUILayout.Button("Commit", GUILayout.Height(50));

            CommitActions();
        }

        private void CommitActions()
        {
            if (isAmend && commitMessage == "")
            {
                commitMessage = lastCommitMessage;
            }

            if (startCommit)
            {
                Git.Instance().Commit(commitMessage, isAmend);

                lastCommitMessage = commitMessage;
                isAmend = false;
                commitMessage = "";
                startCommit = false;
            }
        }

        private void Indexing()
        {
            GUILayout.Label("Indexing Area", GUILayout.Height(50));
            bool indexAll = GUILayout.Button("Add All Files", GUILayout.Height(50));

            if (indexAll)
            {
                Git.Instance().IndexAll();
            }
        }
    }
}