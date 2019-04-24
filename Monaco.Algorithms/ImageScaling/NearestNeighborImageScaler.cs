using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;

namespace Monaco.Algorithms.ImageScaling
{
    public class NearestNeighborImageScaler
    {
        /// <summary>
        /// Rescales an image to the specified size
        /// </summary>
        /// <returns>The rescaled image</returns>
        public Image<Rgba32> Rescale(Image<Rgba32> source, int scaledWidth, int scaledHeight)
        {
            if (scaledWidth < 1 || scaledHeight < 1)
                throw new ArgumentException($"Input image dimensions ({scaledWidth}, {scaledHeight}) must be positive and non-negative.");

            var dest = new Image<Rgba32>(scaledWidth, scaledHeight);

            var xRatio = (source.Width - 1.0d) / scaledWidth;
            var yRatio = (source.Height - 1.0d) / scaledHeight;

            double scaledX = 0;
            double scaledY = 0;

            for(int y = 0; y < dest.Height; y++, scaledY += yRatio)
            {
                var row = dest.GetPixelRowSpan(y);
                for(int x = 0; x < dest.Width; x++, scaledX += xRatio)
                    row[x] = source[(int) scaledX, (int) scaledY];

                scaledX = 0;
            }

            return dest;
        }

        public Image<Rgba32> Rescale(Image<Rgba32> source, double scale) =>
            Rescale(source, (int) Math.Floor(source.Width * scale), (int) Math.Floor(source.Height * scale));
    }
}
