using System.Collections.Generic;
using PairTracker.Model;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestSession : PairingSessionImpl
    {
        public TestSession(Programmer programmer1, Programmer programmer2, IList<Interval> intervals)
            : base(null)
        {
            this.Programmer1 = programmer1;
            this.Programmer2 = programmer2;

            this.intervals = intervals;
        }
    }
}
