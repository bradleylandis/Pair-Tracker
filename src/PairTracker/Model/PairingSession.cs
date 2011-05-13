using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class PairingSession : IPairingSession
    {
        public PairingSession(IntervalFactory intervalFactory)
        {
            this.intervalFactory = intervalFactory;
            this.Programmer1 = Programmer.Neither;
            this.Programmer2 = Programmer.Neither;

            intervals = new List<Interval>();
            this.IntervalTimeout = new TimeSpan(0, 0, 10);
        }

        private readonly IntervalFactory intervalFactory;

        public Programmer Programmer1 { get; protected set; }
        public Programmer Programmer2 { get; protected set; }

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
        //TODO: Change this to "state" to handle paused
        public bool IsRunning { get; private set; }
        public Interval CurrentInterval { get; private set; }

        public void Start(Programmer programmer1, Programmer programmer2)
        {
            IsRunning = true;
            intervals.Clear();
            this.Programmer1 = programmer1;
            this.Programmer2 = programmer2;

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
            if (IsRunning)
            {
                IsRunning = false;
                StopCurrentInterval();
            }
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
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("Programmer 1: {0} Programmer 2: {1} Length: {2} Number of Intervals {3}", Programmer1, Programmer2, Length, Intervals.Count()));

            foreach (var interval in Intervals)
                stringBuilder.AppendLine(interval.ToString());

            return stringBuilder.ToString();
        }
    }
}
