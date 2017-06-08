using System;
using System.IO;
using System.Text;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;
using Duality.Editor.AssetManagement;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Importers
{
    public class TmxImporter : IAssetImporter
    {
        public static readonly string SourceFileExtPrimary = ".tmx";

        public string Id
        {
            get { return "TmxImporter"; }
        }

        public string Name
        {
            get { return "Tmx Importer"; }
        }

        public int Priority
        {
            get { return 0; }
        }

        private string inputBaseDir;

        public void PrepareImport(IAssetImportEnvironment env)
        {
            foreach (var input in env.HandleAllInput(this.AcceptsInput))
            {
                inputBaseDir = Path.GetDirectoryName(input.Path);
                env.AddOutput<TiledMap>(input.AssetName, input.Path);
            }
        }

        public void Import(IAssetImportEnvironment env)
        {
            foreach (var input in env.Input)
            {
                var targetRef = env.GetOutput<TiledMap>(input.AssetName);

                if (targetRef.IsAvailable)
                {
                    var target = targetRef.Res;
                    if (!String.IsNullOrWhiteSpace(input.Path))
                    {
                        using (var sr = new StreamReader(input.Path))
                        {
                            Log.Editor.Write("[DualityTiled] Importing tilemap...");
                            var rawData = sr.ReadToEnd();
                        }
                    }

                    env.AddOutput(targetRef, input.Path);
                }
            }
        }

        public void PrepareExport(IAssetExportEnvironment env)
        {
            if (env.Input is TiledMap)
                env.AddOutputPath(env.Input.Name + SourceFileExtPrimary);
        }

        public void Export(IAssetExportEnvironment env)
        {
            var input = env.Input as TiledMap;
            if (input != null)
            {
                var outputPath = env.AddOutputPath(input.Name + SourceFileExtPrimary);

                if (!string.IsNullOrWhiteSpace(outputPath))
                {
                    using (var sw = new StreamWriter(outputPath, false, Encoding.UTF8))
                    {
                        sw.Write(input);
                    }
                }
            }
        }

        private bool AcceptsInput(AssetImportInput input)
        {
            var inputFileExt = Path.GetExtension(input.Path);
            return SourceFileExtPrimary.Equals(inputFileExt, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}