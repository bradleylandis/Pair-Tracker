using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class PairingSessionImpl : PairingSession
    {
        internal PairingSessionState CurrentState { get; set; }

        public PairingSessionImpl(IntervalFactory intervalFactory)
        {
            this.intervalFactory = intervalFactory;
            this.Programmer1 = Programmer.Neither;
            this.Programmer2 = Programmer.Neither;

            intervals = new List<Interval>();
            this.IntervalTimeout = new TimeSpan(0, 0, 10);
            this.CurrentState = new UnstartedPairingSession(this);
        }

        public bool IsRunning
        {
            get { return CurrentState is RunningPairingSession; }
        }

        private readonly IntervalFactory intervalFactory;

        public Programmer Programmer1 { get; set; }
        public Programmer Programmer2 { get; set; }

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

        public IList<Interval> intervals;
        public IEnumerable<Interval> Intervals { get { return intervals; } }
        public TimeSpan IntervalTimeout { get; private set; }
        public Interval CurrentInterval { get; private set; }

        public void Start(Programmer programmer1, Programmer programmer2)
        {
            CurrentState.Start(programmer1, programmer2);            
        }

        public void Pause()
        {
            CurrentState.Pause();
        }

        public void Resume()
        {
            CurrentState.Resume();
        }

        public void Stop() {
            CurrentState.Stop();
        }

        public void SwitchController(Programmer programmer)
        {
            CurrentState.SwitchController(programmer);
        }

        internal void StartNewInterval(Programmer programmer)
        {
            CurrentInterval = intervalFactory.Create();
            CurrentInterval.Start(programmer);
        }

        internal void StopCurrentInterval()
        {
            CurrentInterval.Stop();
            intervals.Add(CurrentInterval);
            CurrentInterval = null;
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
