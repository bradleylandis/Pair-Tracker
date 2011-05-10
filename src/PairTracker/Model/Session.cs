using System.Collections.Generic;
using System;
using System.Linq;

namespace PairTracker.Model
{
    public class Session
    {
        public Session(IntervalFactory intervalFactory)
        {
            this.intervalFactory = intervalFactory;
            this.programmer1 = Programmer.Neither;
            this.programmer2 = Programmer.Neither;

            intervals = new List<Interval>();
            this.IntervalTimeout = new TimeSpan(0, 0, 10);
        }

        private readonly IntervalFactory intervalFactory;

        protected Programmer programmer1;
        protected Programmer programmer2;

        public TimeSpan Length 
        { 
            get 
            { 
                TimeSpan length = new TimeSpan();
                foreach (var interval in Intervals)
                    length += interval.Length;

                return length;
            } 
        }

        protected IList<Interval> intervals;
        public IEnumerable<Interval> Intervals { get { return intervals; } }
        public TimeSpan IntervalTimeout { get; private set; }

        public Interval CurrentInterval { get; private set; }

        public void Start(Programmer programmer1, Programmer programmer2)
        {
            intervals.Clear();
            this.programmer1 = programmer1;
            this.programmer2 = programmer2;

            StartNewInterval(Programmer.Neither);
        }

        public void Pause()
        {
            StopCurrentInterval();
        }

        public void Resume()
        {
            StartNewInterval(Programmer.Neither);
        }

        public void Stop() {
            StopCurrentInterval();
        }

        private void StartNewInterval(Programmer programmer)
        {
            CurrentInterval = intervalFactory.Create();
            CurrentInterval.Start(programmer);
        }

        private void StopCurrentInterval()
        {
            CurrentInterval.Stop();
            intervals.Add(CurrentInterval);
            CurrentInterval = null;
        }

        public void SwitchController(Programmer programmer)
        {
            if (programmer != CurrentInterval.Programmer)
            {
                StopCurrentInterval();
                StartNewInterval(programmer);
            }
        }

        public override string ToString()
        {
            return string.Format("Programmer 1: {0} Programmer 2: {1} Length: {2} Number of Intervals {3}", programmer1, programmer2, Length, Intervals.Count());
        }
    }
}
