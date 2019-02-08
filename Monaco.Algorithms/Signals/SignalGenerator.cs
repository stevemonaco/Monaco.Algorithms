using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Monaco.Algorithms.Signals
{
    public static class SignalGenerator
    {
        /// <summary>
        /// Generates a discrete sine wave
        /// </summary>
        /// <param name="duration">Time duration in seconds</param>
        /// <param name="frequency">The frequency in Hertz</param>
        /// <param name="amplitude">The signal amplitude</param>
        /// <param name="phaseShift">The phase shift in radians</param>
        /// <param name="samplingRate">The sampling rate in Hertz</param>
        /// <returns></returns>
        public static Signal1D Generate1DSineWave(double duration, double frequency, double amplitude, double phaseShift, double samplingRate)
        {
            double timestep = 1 / samplingRate;
            int numsamples = (int)Math.Ceiling(duration * samplingRate);
            Complex[] ydata = new Complex[numsamples];
            double[] xdata = new double[numsamples];

            for (int i = 0; i < numsamples; i++)
            {
                xdata[i] = timestep * i;
                ydata[i] = amplitude * Math.Sin(6.283185307179586476925286766559 * xdata[i] * frequency + phaseShift);
            }

            return new Signal1D(xdata, ydata, samplingRate, duration);
        }
    }
}
