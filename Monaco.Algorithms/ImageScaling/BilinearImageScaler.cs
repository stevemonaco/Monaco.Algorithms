using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;

namespace Monaco.Algorithms.ImageScaling
{
    /// <summary>
    /// Rescales an image using Bilinear Interpolation
    /// Bilinear Interpolation is a weighted color average (interpolation) of the desired location
    /// with respect to its surrounding 2x2 grid of pixel neighbors
    /// </summary>
    public class BilinearImageScaler
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

            for (int y = 0; y < dest.Height; y++, scaledY += yRatio)
            {
                var row = dest.GetPixelRowSpan(y);
                for (int x = 0; x < dest.Width; x++, scaledX += xRatio)
                {
                    var x1 = (int)scaledX;
                    var x2 = (int)(scaledX + 1);
                    var y1 = (int)scaledY;
                    var y2 = (int)(scaledY + 1);

                    var p11 = source[x1, y1];
                    var p21 = source[x2, y1];
                    var p12 = source[x1, y2];
                    var p22 = source[x2, y2];

                    var weightX = 1 - (scaledX - x1);
                    var weightY = 1 - (scaledY - y1);

                    row[x] = Blerp(p11, p21, p12, p22, weightX, weightY);
                }

                scaledX = 0;
            }

            return dest;
        }

        public Image<Rgba32> Rescale(Image<Rgba32> source, double scale) =>
            Rescale(source, (int)Math.Floor(source.Width * scale), (int)Math.Floor(source.Height * scale));

        private double Lerp(double a, double b, double weight)
        {
            var lerp = (a - b) * weight + b;
            return lerp;
        }

        private double Blerp(double c11, double c21, double c12, double c22, double weightX, double weightY) =>
            Lerp(Lerp(c11, c21, weightX), Lerp(c12, c22, weightX), weightY);

        private Rgba32 Blerp(Rgba32 p11, Rgba32 p21, Rgba32 p12, Rgba32 p22, double weightX, double weightY)
        {
            var r = (byte) Blerp(p11.R, p21.R, p12.R, p22.R, weightX, weightY);
            var g = (byte) Blerp(p11.G, p21.G, p12.G, p22.G, weightX, weightY);
            var b = (byte) Blerp(p11.B, p21.B, p12.B, p22.B, weightX, weightY);
            var a = (byte) Blerp(p11.A, p21.A, p12.A, p22.A, weightX, weightY);

            return new Rgba32(r, g, b, a);
        }
    }
}
