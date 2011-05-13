using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public interface IPairingSession
    {
        void Start(Programmer programmer1, Programmer programmer2);
        void Stop();
        void SwitchController(Programmer programmer);
        Interval CurrentInterval { get; }
        IEnumerable<Interval> Intervals { get; }
        TimeSpan IntervalTimeout { get; }
        TimeSpan Length { get; }
        bool IsRunning { get; }
    }
}
