using System;
using PairTracker.Model;

namespace PairTracker.View
{
    public class StartButtonClickedEventArgs : EventArgs
    {
        public Programmer Programmer1 { get; private set; }
        public Programmer Programmer2 { get; private set; }

        public StartButtonClickedEventArgs(Programmer programmer1, Programmer programmer2)
            : base()
        {
            this.Programmer1 = programmer1;
            this.Programmer2 = programmer2;
        }
    }
}
