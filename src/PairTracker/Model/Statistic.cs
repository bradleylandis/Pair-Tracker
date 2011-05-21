using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class Statistic
    {
        public Statistic(int percentage, TimeSpan totalTime)
        {
            this.Percentage = percentage;
            this.TotalTime = totalTime;
        }

        public TimeSpan TotalTime { get; set; }
        public int Percentage { get; set; }
    }
}
