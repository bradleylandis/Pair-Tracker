using PairTracker.Model;
using System;
using System.Collections.Generic;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestSession : Session
    {
        public TestSession(Programmer programmer1, Programmer programmer2, IList<Interval> intervals) : base(null)
        {
            this.programmer1 = programmer1;
            this.programmer2 = programmer2;

            this.intervals = intervals;
        }
    }
}
