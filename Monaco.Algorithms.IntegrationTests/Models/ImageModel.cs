using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.IntegrationTests.Models
{
    public class ImageModel
    {
        public Image<Rgba32> Image { get; set; }
        public string Name { get; set; }
    }
}
