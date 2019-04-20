using AlgorithmIntegrationTests.DataSetLoaders;
using Monaco.Algorithms.IntegrationTests.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;

namespace Monaco.Algorithms.IntegrationTests.DataSetLoaders
{
    public class ImageSetLoader : IDataSetLoader<ImageModel>
    {
        public IList<ImageModel> Load()
        {
            var list = new List<ImageModel>();

            list.Add(LoadModel(@"DataSets\Images\berry.png"));
            list.Add(LoadModel(@"DataSets\Images\figure.png"));
            list.Add(LoadModel(@"DataSets\Images\jellybeans.png"));

            return list;
        }

        public IList<ImageModel> LoadFromPath(string path)
        {
            throw new NotImplementedException();
        }

        public IList<ImageModel> LoadFromWeb(string path)
        {
            throw new NotImplementedException();
        }

        private ImageModel LoadModel(string path)
        {
            ImageModel model = new ImageModel
            {
                Name = Path.GetFileNameWithoutExtension(path),
                Image = Image.Load<Rgba32>(path)
            };

            return model;
        }
    }
}
