using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using Monaco.Algorithms.Extensions;

namespace Monaco.Algorithms.ImageScaling
{
    /// <summary>
    /// Rescales an image using bicubic interpolation
    /// Implementation based upon https://theailearner.com/tag/bicubic-interpolation/ and
    /// OpenCV https://github.com/opencv/opencv/blob/master/modules/imgproc/src/resize.cpp
    /// </summary>
    public class BicubicImageScaler
    {
        private double[] coefficientWeightsX = new double[4];
        private double[] coefficientWeightsY = new double[4];
        private Rgba32[] lineBufferY = new Rgba32[4];

        /// <summary>
        /// Rescales an image to the specified size
        /// </summary>
        /// <returns>The rescaled image</returns>
        public Image<Rgba32> Rescale(Image<Rgba32> source, int scaledWidth, int scaledHeight)
        {
            if (source is null)
                throw new NullReferenceException($"Input image {nameof(source)} is null");

            if (source.Width < 1 || source.Height < 1)
                throw new ArgumentException($"Input image dimensions ({source.Width}, {source.Height}) must be positive and non-negative.");

            if (scaledWidth < 1 || scaledHeight < 1)
                throw new ArgumentException($"Image rescale dimensions ({scaledWidth}, {scaledHeight}) must be positive and non-negative.");

            var dest = new Image<Rgba32>(scaledWidth, scaledHeight);

            var scaledStepX = (source.Width - 1.0d) / scaledWidth;
            var scaledStepY = (source.Height - 1.0d) / scaledHeight;

            var scaledX = 0d;
            var scaledY = 0d;

            var neighbors = new Rgba32[4][] {
                new Rgba32[4], new Rgba32[4], new Rgba32[4], new Rgba32[4]
            };

            for (int y = 0; y < dest.Height; y++, scaledY += scaledStepY)
            {
                var row = dest.GetPixelRowSpan(y);
                for (int x = 0; x < dest.Width; x++, scaledX += scaledStepX)
                {
                    var x1 = (int)scaledX;
                    var y1 = (int)scaledY;

                    for (int i = -1; i <= 2; i++)
                        for (int j = -1; j <= 2; j++)
                            neighbors[j + 1][i + 1] = GetClampedPixel(source, x1 + i, y1 + j);

                    row[x] = BicubicInterpolate(neighbors, scaledX - x1, scaledY - y1);
                }

                scaledX = 0;
            }

            return dest;
        }

        public Image<Rgba32> Rescale(Image<Rgba32> source, double scale) =>
            Rescale(source, (int)Math.Floor(source.Width * scale), (int)Math.Floor(source.Height * scale));

        /// <summary>
        /// Returns a pixel color from coordinates. If the coordinates are outside of the image, then the retrieved coordinate
        /// is clamped to the edge of the bitmap
        /// </summary>
        private Rgba32 GetClampedPixel(Image<Rgba32> image, int x, int y) =>
            image[x.Clamp(0, image.Width - 1), y.Clamp(0, image.Height - 1)];

        private Rgba32 BicubicInterpolate(Rgba32[][] neighbors, double weightX, double weightY)
        {
            MakeCubicCoefficients(coefficientWeightsX, weightX);
            MakeCubicCoefficients(coefficientWeightsY, weightY);

            lineBufferY[0] = CubicInterpolate(neighbors[0], coefficientWeightsX);
            lineBufferY[1] = CubicInterpolate(neighbors[1], coefficientWeightsX);
            lineBufferY[2] = CubicInterpolate(neighbors[2], coefficientWeightsX);
            lineBufferY[3] = CubicInterpolate(neighbors[3], coefficientWeightsX);

            return CubicInterpolate(lineBufferY, coefficientWeightsY);
        }

        private Rgba32 CubicInterpolate(Rgba32[] line, double[] weights)
        {
            var r = CubicInterpolate(line, weights, x => x.R);
            var g = CubicInterpolate(line, weights, x => x.G);
            var b = CubicInterpolate(line, weights, x => x.B);
            var a = CubicInterpolate(line, weights, x => x.A);

            return new Rgba32(r, g, b, a);
        }

        private byte CubicInterpolate(Rgba32[] line, double[] weights, Func<Rgba32, double> selector)
        {
            var interpolation = weights[0] * selector(line[0]) + weights[1] * selector(line[1]) +
                weights[2] * selector(line[2]) + weights[3] * selector(line[3]);

            return (byte) interpolation.Clamp(0, 255);
        }

        private void MakeCubicCoefficients(double[] buffer, double weight)
        {
            const double A = -0.75d;

            buffer[0] = ((A * (weight + 1) - 5 * A) * (weight + 1) + 8 * A) * (weight + 1) - 4 * A;
            buffer[1] = ((A + 2) * weight - (A + 3)) * weight * weight + 1;
            buffer[2] = ((A + 2) * (1 - weight) - (A + 3)) * (1 - weight) * (1 - weight) + 1;
            buffer[3] = 1 - buffer[0] - buffer[1] - buffer[2];
        }
    }
}
