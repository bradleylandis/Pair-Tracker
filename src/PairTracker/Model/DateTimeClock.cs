using System;

namespace PairTracker.Model
{
    public class DateTimeClock : Clock
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
