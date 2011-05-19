﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public interface PairingSession : PairingSessionState
    {
        void Initialize(Programmer programmer1, Programmer programmer2);
        Interval CurrentInterval { get; }
        IEnumerable<Interval> Intervals { get; }
        TimeSpan IntervalTimeout { get; }
        TimeSpan Length { get; }
        bool IsRunning { get; }
    }
}
