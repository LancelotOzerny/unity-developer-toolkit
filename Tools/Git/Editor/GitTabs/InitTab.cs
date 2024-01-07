using UnityEditor;
using UnityEngine;

namespace Lancy
{
    public class InitTab : WindowTab
    {
        private bool isExclude;
        private string excludeFile =
            "/[Ll]ibrary/" + "\n" +
            "/[Tt]emp/" + "\n" +
            "/[Oo]bj/" + "\n" +
            "/[Bb]uild/" + "\n" +
            "/[Bb]uilds/" + "\n" +
            "/[Ll]ogs/" + "\n" +
            "/[Uu]ser[Ss]ettings/" + "\n" +
            "/[Mm]emoryCaptures/" + "\n" +
            "!/[Aa]ssets/**/*.meta" + "\n" +
            "/[Aa]ssets/Plugins/Editor/JetBrains*" + "\n" +
            ".vs/" + "\n" +
            ".gradle/" + "\n" +
            "ExportedObj/" + "\n" +
            ".consulo/" + "\n" +
            "*.csproj" + "\n" +
            "*.unityproj" + "\n" +
            "*.sln" + "\n" +
            "*.suo" + "\n" +
            "*.tmp" + "\n" +
            "*.user" + "\n" +
            "*.userprefs" + "\n" +
            "*.pidb" + "\n" +
            "*.booproj" + "\n" +
            "*.svd" + "\n" +
            "*.pdb" + "\n" +
            "*.mdb" + "\n" +
            "*.meta" + "\n" +
            "*.opendb" + "\n" +
            "*.apk" + "\n" +
            "*.unitypackage" + "\n" +
            "*.VC.db" + "\n" +
            "*.pidb.meta" + "\n" +
            "*.pdb.meta" + "\n" +
            "*.mdb.meta" + "\n" +
            "sysinfo.txt" + "\n" +
            "/[Aa]ssets/[Aa]ddressable[Aa]ssets[Dd]ata/*/*.bin*" + "\n" +
            "/[Aa]ssets/[Ss]treamingAssets/aa.meta" + "\n" +
            "/[Aa]ssets/[Ss]treamingAssets/aa/*" + "\n" +
            "!*.dll" + "\n" +
            "!*.obj" + "\n" +
            "*.gitignore" + "\n";

        public InitTab()
        {
            this.Title = "Repository Init";
        }

        public override void Show()
        {
            InitArea();
        }
        
        public void InitArea()
        {
            GUILayout.Space(20);
            GUILayout.Label("Exclude initnial file");

            GUILayout.Space(20);
            isExclude = GUILayout.Toggle(isExclude, "Exclude initnial file");
            
            if (isExclude)
            {
                GUILayout.Space(20);
                EditorGUILayout.TextArea(excludeFile, GUILayout.MaxHeight(500));
            }
            bool pressed = GUILayout.Button("Initialize", GUILayout.Height(50));

            if (pressed)
            {
                Git.Instance().Init();
                if (isExclude)
                {
                    Git.Instance().RewriteIgnore(excludeFile);
                }
            }
        }
    }
}