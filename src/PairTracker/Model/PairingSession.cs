using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public interface PairingSession : PairingSessionState
    {
        Interval CurrentInterval { get; }
        IEnumerable<Interval> Intervals { get; }
        TimeSpan IntervalTimeout { get; }
        TimeSpan Length { get; }
        bool IsRunning { get; }
    }
}
