using System;
using PairTracker.Model;

namespace PairTracker.View
{
    public class ControllerChangedEventArgs : EventArgs
    {
        public Programmer Programmer { get; private set; }

        public ControllerChangedEventArgs(Programmer programmer)
            : base()
        {
            this.Programmer = programmer;
        }
    }
}
