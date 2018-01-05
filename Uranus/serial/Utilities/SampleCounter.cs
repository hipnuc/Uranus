using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Uranus.Utilities;

namespace Uranus.Utilities
{
    class SampleCounter
    {
        // using Accurate Timer

      //  private System.Windows.Forms.Timer timer;
        AccurateTimer aTimer;

        public int SamplesReceived { get; private set; }

        public int SampleRate { get; private set; }

        private int prevSamplesReceived;

        public SampleCounter()
        {
            // Initialise variables
            prevSamplesReceived = 0;
            SamplesReceived = 0;

            //// Setup timer
            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = 1000;
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Start();

            aTimer = new AccurateTimer(new Action(aTimerTick1), 1000); // In milliseconds. 10 = 1/100th second.
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

        private void aTimerTick1()
        {
            SampleRate = SamplesReceived - prevSamplesReceived;
            prevSamplesReceived = SamplesReceived;
        }

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    SampleRate = SamplesReceived - prevSamplesReceived;
        //    prevSamplesReceived = SamplesReceived;
        //}
    }
}


