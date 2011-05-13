using PairTracker.Model;
using System;
using System.Collections.Generic;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestSession : PairingSession
    {
        public TestSession(Programmer programmer1, Programmer programmer2, IList<Interval> intervals) : base(null)
        {
            this.Programmer1 = programmer1;
            this.Programmer2 = programmer2;

            this.intervals = intervals;
        }
    }
}
