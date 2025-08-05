using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace _Project.Develop.Editor
{
    public static class UnityLayerGenerator
    {
        private static string OutputPath
            => Path.Combine(Application.dataPath,
                "_Project/Develop/Runtime/Generated/UnityLayers.cs");
        
        [DidReloadScripts]
        [MenuItem("Tools/Generate UnityLayers Class")]
        public static void Generate()
        {
            var sb = new StringBuilder();

            sb.AppendLine("// Auto-generated. Do not edit manually.");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("");
            sb.AppendLine("namespace _Project.Develop.Runtime.Generated");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic static class UnityLayers");
            sb.AppendLine("\t{");

            var layerNames = new System.Collections.Generic.List<string>();

            for (int i = 0; i < 32; i++)
            {
                string name = LayerMask.LayerToName(i);
                if (!string.IsNullOrEmpty(name))
                {
                    string cleanName = SanitizeName(name);
                    sb.AppendLine($"\t\tpublic static readonly int Layer{cleanName} = LayerMask.NameToLayer(\"{name}\");");
                    layerNames.Add(cleanName);
                }
            }

            sb.AppendLine();

            foreach (string name in layerNames)
            {
                sb.AppendLine($"\t\tpublic static readonly int LayerMask{name} = 1 << Layer{name};");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static string SanitizeName(string name)
        {
            return name.Replace(" ", "").Replace("-", "").Replace(".", "");
        }
    }
}
