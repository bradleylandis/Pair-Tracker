using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.View
{
    public enum ConfirmationStatus
    {
        Unknown,
        NotConfirmed,
        Confirmed
    }

    public class CloseButtonClickedEventArgs : EventArgs
    {
        public ConfirmationStatus ConfirmationStatus { get; private set; }

        public CloseButtonClickedEventArgs(ConfirmationStatus confirmationStatus) : base()
        {
            this.ConfirmationStatus = confirmationStatus;
        }
    }
}
