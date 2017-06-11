using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ChristianGreiner.Duality.Plugins.DualityTiled.Parser;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;
using Duality.Editor.AssetManagement;
using Duality.Plugins.Tilemaps;
using Duality.Resources;
using Duality.Editor;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Importer
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
                    if (!String.IsNullOrWhiteSpace(input.Path))
                    {
                        using (var sr = new StreamReader(input.Path))
                        {
                            Log.Editor.Write("[DualityTiled] Importing tilemap...");
                            var data = sr.ReadToEnd();

                            var parser = new TmxParser();
                            parser.ParseMap(ref targetRef, inputBaseDir, data);

                            ImportTilesets(env, ref targetRef);
                        }
                    }

                    env.AddOutput(targetRef, input.Path);
                }
            }
        }

        private void ImportTilesets(IAssetImportEnvironment env, ref ContentRef<TiledMap> map)
        {
            if (map.Res.Tilesets.Count > 0)
            {
                if (map.Res.Tilesets?.Count > 1)
                    throw new NotImplementedException("Multiple tilesets are not supported yet.");

                var paths = new List<string>();

                foreach (var tileset in map.Res.Tilesets)
                {
                    if (!string.IsNullOrEmpty(tileset.Source))
                    {
                        var path = Path.GetFullPath(Path.Combine(inputBaseDir, tileset.Source));
                        paths.Add(path);
                    }
                }

                if (paths.Count > 0)
                {
                    AssetManager.ImportAssets(paths, env.TargetDirectory, inputBaseDir);

                    foreach (var tileset in map.Res.Tilesets)
                    {
                        foreach (var pixmap in ContentProvider.GetAvailableContent<Pixmap>().Where(p => !p.IsDefaultContent))
                        {
                            if (pixmap.Name.Equals(tileset.Name))
                            {
                                string targetPath = PathHelper.GetFreePath(pixmap.FullName, Resource.GetFileExtByType<Tileset>());

                                var texture = new Texture(pixmap);
                                texture.Save(targetPath);
                                var textureRef = new ContentRef<Texture>(texture);
                                textureRef.Res.Save(targetPath);

                                var tilesetRes = new Tileset();
                                tilesetRes.TileSize = map.Res.TileSize;
                                tilesetRes.RenderConfig.Add(new TilesetRenderInput()
                                {
                                    SourceData = pixmap,
                                    SourceTileSize = new Point2(tileset.TileSize.X, tileset.TileSize.Y),
                                    SourceTileSpacing = tileset.Spacing,
                                    TargetTileMargin = tileset.Margin
                                });
                                tilesetRes.Compile();
                                tilesetRes.Save(targetPath);

                                tileset.Tileset = tilesetRes;
                            }
                        }
                    }
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