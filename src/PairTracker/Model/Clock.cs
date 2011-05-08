using System;

namespace PairTracker.Model
{
    public interface Clock
    {
        DateTime Now { get; }
    }
}
