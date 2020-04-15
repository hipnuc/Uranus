using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Uranus.Utilities;

namespace Uranus.Utilities
{
    class SampleCounter
    {
        AccurateTimer aTimer;

        public int SamplesReceived { get; private set; }

        public int SampleRate { get; private set; }

        private int prevSamplesReceived;

        public SampleCounter()
        {
            // Initialise variables
            prevSamplesReceived = 0;
            SamplesReceived = 0;
            aTimer = new AccurateTimer(new Action(AccTimerTick1), 1000); // In milliseconds. 10 = 1/100th second.
        }

        public void Increment(int count)
        {
            SamplesReceived += count;
        }

        // Zeros packet counter.
        public void Reset()
        {
            prevSamplesReceived = 0;
            SamplesReceived = 0;
            SampleRate = 0;
        }

        private void AccTimerTick1()
        {
            SampleRate = SamplesReceived - prevSamplesReceived;
            prevSamplesReceived = SamplesReceived;
        }

    }
}


