using PairTracker.Model;
using System;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestInterval : Interval
    {
        public TestInterval(DateTime start, TimeSpan length, Programmer programmer) : base(null)
        {
            this.Programmer = programmer;
            this.StartTime = start;
            this.EndTime = start + length;
        }
    }
}
