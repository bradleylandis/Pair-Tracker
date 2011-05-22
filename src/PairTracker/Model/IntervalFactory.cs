﻿namespace PairTracker.Model
{
    public class IntervalFactory
    {
        public IntervalFactory(Clock clock)
        {
            this.clock = clock;
        }

        private readonly Clock clock;

        public Interval Create()
        {
            return new Interval(clock);
        }
    }
}
