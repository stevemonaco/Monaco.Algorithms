using System;
using System.Collections.Generic;
using System.Numerics;

namespace Monaco.Algorithms.Signals
{
    public class FourierTransform
    {
        /// <summary>
        /// Performs a Discrete Fourier Tranform on the input data.
        /// This is a reference algorithm. Please use a Fast Fourier Transform for production.
        /// </summary>
        /// <param name="inputSignal"></param>
        /// <param name="inverseTransform"></param>
        /// <returns></returns>
        public static Signal1D DFT(Signal1D inputSignal, bool inverseTransform)
        {
            if (inputSignal.XData.Length != inputSignal.YData.Length)
                return null;

            double direction = 1.0;
            if (inverseTransform)
                direction = -1.0;

            int length = inputSignal.XData.Length;

            Complex[] yout = new Complex[inputSignal.YData.Length];
            double[] xout = new double[inputSignal.XData.Length];

            // W = e^2i*pi/N
            Complex W = new Complex(Math.Cos(direction * 6.283185307179586476925286766559 / (double)length), Math.Sin(direction * 2.0 * Math.PI / (double)length));

            for (int k = 0; k < length; k++)
            {
                for (int n = 0; n < length; n++)
                {
                    yout[k] += (Complex.Pow(W, k * n) * inputSignal.YData[n]);
                }

                if (inverseTransform)
                {
                    yout[k] /= length;
                    xout[k] = k / inputSignal.SamplingRate;
                }
                else
                    xout[k] = k;
            }

            return new Signal1D(xout, yout, inputSignal.SamplingRate, 0);
        }

        /// <summary>
        /// Transforms a fourier-transformed signal into a frequency magnitude spectrum
        /// </summary>
        /// <param name="fourierSignal"></param>
        /// <returns></returns>
        public static Signal1D MagnitudeTransform(Signal1D fourierSignal)
        {
            if (fourierSignal.SamplingRate <= 0)
                return null;

            int length = fourierSignal.XData.Length;

            double[] xout = new double[length / 2]; // Frequency
            Complex[] yout = new Complex[length / 2]; // Magnitude

            for (int i = 0; i < xout.Length; i++)
            {
                xout[i] = i * fourierSignal.SamplingRate / (double)fourierSignal.XData.Length;
                yout[i] = fourierSignal.YData[i].Magnitude;
            }

            return new Signal1D(xout, yout, fourierSignal.SamplingRate, fourierSignal.TimeLength);
        }
    }
}
