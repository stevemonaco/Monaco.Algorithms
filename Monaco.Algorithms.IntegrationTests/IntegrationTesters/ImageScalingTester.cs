using AlgorithmIntegrationTests.IntegrationTesters;
using Monaco.Algorithms.ImageScaling;
using Monaco.Algorithms.IntegrationTests.DataSetLoaders;
using Monaco.Algorithms.IntegrationTests.Models;
using NUnit.Framework;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Monaco.Algorithms.IntegrationTests.IntegrationTesters
{
    [TestFixture]
    class ImageScalingTester : IIntegrationTester
    {
        private IList<ImageModel> models;

        [OneTimeSetUp]
        public void Setup()
        {
            var loader = new ImageSetLoader();
            models = loader.Load();

            Directory.CreateDirectory("Output");
            foreach(var model in models)
                model.Image.Save($@"Output\{model.Name}.png");
        }

        public void RunTestByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RunTests()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void NearestNeighborTest()
        {
            var scaler = new NearestNeighborImageScaler();
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach(var model in models)
            {
                var result1_5x = scaler.Rescale(model.Image, 1.5);
                var result2x = scaler.Rescale(model.Image, 2.0);
                var result3x = scaler.Rescale(model.Image, 3.0);
                var result4x = scaler.Rescale(model.Image, 8.0);

                result1_5x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-nearest-1.5x.png", FileMode.Create));
                result2x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-nearest-2x.png", FileMode.Create));
                result3x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-nearest-3x.png", FileMode.Create));
                result4x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-nearest-8x.png", FileMode.Create));
            }
        }

        [Test]
        public void BilinearInterpolationTest()
        {
            var scaler = new BilinearImageScaler();
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach (var model in models)
            {
                var result1_5x = scaler.Rescale(model.Image, 1.5);
                var result2x = scaler.Rescale(model.Image, 2.0);
                var result3x = scaler.Rescale(model.Image, 3.0);
                var result4x = scaler.Rescale(model.Image, 8.0);

                result1_5x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bilinear-1.5x.png", FileMode.Create));
                result2x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bilinear-2x.png", FileMode.Create));
                result3x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bilinear-3x.png", FileMode.Create));
                result4x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bilinear-8x.png", FileMode.Create));
            }
        }

        [Test]
        public void BicubicInterpolationTest()
        {
            var scaler = new BicubicImageScaler();
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach (var model in models)
            {
                var result1_5x = scaler.Rescale(model.Image, 1.5);
                var result2x = scaler.Rescale(model.Image, 2.0);
                var result3x = scaler.Rescale(model.Image, 3.0);
                var result4x = scaler.Rescale(model.Image, 8.0);

                result1_5x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bicubic-1.5x.png", FileMode.Create));
                result2x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bicubic-2x.png", FileMode.Create));
                result3x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bicubic-3x.png", FileMode.Create));
                result4x.SaveAsPng<Rgba32>(new FileStream($@"Output\{model.Name}-bicubic-8x.png", FileMode.Create));
            }
        }
    }
}
