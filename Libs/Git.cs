using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace Lancy
{
    public class Git
    {
        private static Git instance = null;
        
        public string[] Branches { get; protected set; }
        public int CurrentBranch = 0;

        string commites = "";
        public Git()
        {
            if (Exist() == false)
            {
                return;
            }

            SetBranches();
            SetCurrentBranch();
            SetCommites();
        }

        public static Git Instance()
        {
            if (instance == null)
            {
                instance = new Git();
            }

            return instance;
        }

        private void Run(string command)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/C" + command);
            System.Threading.Thread.Sleep(150);
        }

        public void Reset()
        {
            Run("git reset --hard");
        }

        public void Init()
        {
            Run("git init");
        }

        public void CreateRemote(string name, string path)
        {
            Run($"git remote add {name} {path}");
            System.Threading.Thread.Sleep(150);
        }

        public void RewriteIgnore(string exclude)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\.gitignore"))
            {
                sw.WriteLine(exclude);
            }
        }

        public string GetCommites()
        {
            return commites;
        }

        private string PrepareCommitMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return "";
            }

            message = message.Replace("\n", "\" -m \"");
            return $"-m \"{message}\"";
        }

        public void Commit(string message, bool amend = false)
        {
            string preparedMessage = PrepareCommitMessage(message);
            Run($"git commit {(amend ? "--amend" : "")} {preparedMessage}");

            if (commites == string.Empty)
            {
                SetBranches();
            }

            SetCommites();
        }
        private void SetCommites()
        {   
            if (Branches == null || Branches.Length == 0 || Branches[CurrentBranch] == string.Empty)
            {
                return;
            }

            commites = string.Empty;
            string dir = Directory.GetCurrentDirectory() + "\\.git\\logs\\refs\\heads\\" + Branches[CurrentBranch];
            if (File.Exists(dir))
            {
                string[] lines = File.ReadAllLines(dir);

                foreach(string line in lines)
                {
                    string[] splitedInitialCommit = line.Split("commit (initial):");
                    string[] splitedAmendCommit = line.Split("commit (amend):");
                    string[] splitedCommit = line.Split("commit:");
                    string commit = line;

                    if (splitedCommit.Length > 1)               commit = splitedCommit[1];
                    else if (splitedAmendCommit.Length > 1)     commit = splitedAmendCommit[1];
                    else if (splitedInitialCommit.Length > 1)   commit = splitedInitialCommit[1];

                    commites = commit + "\n" + commites;
                }
            }
        }
        private void SetBranches()      
        {
            string currentDir = Directory.GetCurrentDirectory() + "\\.git\\refs\\heads";
            Branches = Directory.GetFiles(currentDir);
            
            for (int i = 0; i <  this.Branches.Length; i++)
            {
                Branches[i] = Branches[i].Split('\\').Last();
            }
        }

        private void SetCurrentBranch()
        {
            string currentDir = Directory.GetCurrentDirectory() + "\\.git";
            
            using (StreamReader sr = new StreamReader(currentDir + "\\HEAD"))       
            {
                string branch = sr.ReadLine().Split('/').Last();
                
                for (int i = 0; i < Branches.Length; ++i)
                {
                    if (Branches[i] == branch)
                    {
                        CurrentBranch = i;
                        break;
                    }
                }
            }
        }

        public void CreateBranch(string branch, bool checkout = false)
        {
            Run($"git branch {(checkout ? "-c " : "")}  {branch}");
            Thread.Sleep(200);
            SetBranches();
            SetCurrentBranch();
        }

        public void SelectBranch(string branch)
        {
            Run($"git checkout {branch}");
        }

        public void SelectBranch(int branchIndex)
        {
            Run($"git checkout {Branches[branchIndex]}");
        }

        public void IndexAll()
        {
            Run("git add .");
        }

        public void Clone(string url)
        {
            Run($"git -C assets clone {url}");
        }

        public void Push(string remote = "", string branch = "")
        {
            Run($"git push {remote} {branch}");
        }

        public void Pull(string remote = "", string branch = "")
        {
            Run($"git pull {remote} {branch}");
        }

        public bool Exist()
        {
            string dir = Directory.GetCurrentDirectory() + "\\.git";
            if (Directory.Exists(dir))
            {
                return true;
            }

            return false;
        }
    }
}