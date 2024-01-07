using UnityEngine;

namespace Lancy
{
    public class BranchTab : WindowTab
    {
        int lastBranch = 0;
        string branchName = "";
        bool selectNewBranch = false;

        public BranchTab()
        {
            this.Title = "Branches";
        }

        public override void Show()
        {
            if (Git.Instance().Branches == null)
            {
                return;
            }

            ShowBranches();
            CreateBranch();
        }

        private void ShowBranches()
        {
            GUILayout.Space(20);
            GUILayout.Label("Branches Select");
            GUILayout.Space(20);

            Git.Instance().CurrentBranch = GUILayout.SelectionGrid(
                Git.Instance().CurrentBranch, 
                Git.Instance().Branches, 
                1,
                GUILayout.Height(30 * Git.Instance().Branches.Length)
            );
            
            if (lastBranch != Git.Instance().CurrentBranch)
            {
                Git.Instance().SelectBranch(Git.Instance().CurrentBranch);
                lastBranch = Git.Instance().CurrentBranch;
            }
        }

        private void CreateBranch()
        {
            GUILayout.Space(20);
            GUILayout.Label("Branch Create");
            GUILayout.Space(20);

            branchName = GUILayout.TextField(branchName, GUILayout.Height(20));
            GUILayout.Space(20);
            selectNewBranch = GUILayout.Toggle(selectNewBranch, "Select");

            GUILayout.Space(20);
            if (GUILayout.Button("Create Branch", GUILayout.Height(40)))
            {
                Git.Instance().CreateBranch(branchName, selectNewBranch);
                selectNewBranch = false;
                branchName = "";
            }
        }
    }
}