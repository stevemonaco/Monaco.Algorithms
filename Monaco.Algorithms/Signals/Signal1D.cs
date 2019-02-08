using System.Numerics;

namespace Monaco.Algorithms.Signals
{
    public class Signal1D
    {
        public Signal1D(double[] xData, Complex[] yData, double samplingRate, double timeLength)
        {
            XData = xData;
            YData = yData;
            SamplingRate = samplingRate;
            TimeLength = timeLength;
        }

        public double[] XData { get; private set; }
        public Complex[] YData { get; private set; }
        public double SamplingRate { get; private set; }
        public double TimeLength { get; private set; }
    }
}
