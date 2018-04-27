using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
namespace Assets.Script.Editor
{

    /// <summary>
    /// 自动动画切分
    /// Text文件
    /// firstFrame lastFrame loop?not name
    /// 0-50 loop forward 
    /// 100-190 die
    /// </summary>
    class FbxAnimListPostprocessor : AssetPostprocessor
    {
        public void OnPreprocessModel()
        {
            if (Path.GetExtension(assetPath).ToLower() == ".fbx")
            {
                try
                {
                    ModelImporter modelImporter = assetImporter as ModelImporter;
                    modelImporter.materialName = ModelImporterMaterialName.BasedOnMaterialName;
                }
                catch
                {

                }
            }
        }

        void ParseAnimFile(string sAnimList, ref System.Collections.ArrayList List)
        {
            Regex regexString = new Regex(" *(?<firstFrame>[0-9]+) *- *(?<lastFrame>[0-9]+) *(?<loop>(loop|noloop| )) *(?<name>[^\r^\n]*[^\r^\n^ ])",
                RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            Match match = regexString.Match(sAnimList, 0);
            while (match.Success)
            {
                ModelImporterClipAnimation clip = new ModelImporterClipAnimation();

                if (match.Groups["firstFrame"].Success)
                {
                    clip.firstFrame = System.Convert.ToInt32(match.Groups["firstFrame"].Value, 10);
                }
                if (match.Groups["lastFrame"].Success)
                {
                    clip.lastFrame = System.Convert.ToInt32(match.Groups["lastFrame"].Value, 10);
                }
                if (match.Groups["loop"].Success)
                {
                    clip.loop = match.Groups["loop"].Value == "loop";
                }
                if (match.Groups["name"].Success)
                {
                    clip.name = match.Groups["name"].Value;
                }

                List.Add(clip);

                match = regexString.Match(sAnimList, match.Index + match.Length);
            }
        }

    }
}
