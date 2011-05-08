using System;

namespace PairTracker.Model
{
    public class Interval
    {
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public Programmer Programmer { get; protected set; }
        public TimeSpan Length { get { return EndTime - StartTime; } }

        private readonly Clock clock;
        public Interval(Clock clock)
        {
            this.clock = clock;
        }

        public void Start(Programmer programmer)
        {
            this.Programmer = programmer;
            StartTime = clock.Now;
        }

        public void Stop()
        {
            EndTime = clock.Now;
        }

        public override string ToString()
        {
            return string.Format("Programmmer: {0} Length: {1} seconds Start Time: {2} End Time: {3}", Programmer.Name, Length.TotalSeconds, StartTime, EndTime);
        }
    }
}
