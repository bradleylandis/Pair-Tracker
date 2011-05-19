using PairTracker.Model;
using System;
using System.Collections.Generic;

namespace PairTracker.View
{
    public interface PairTrackerView
    {
        event EventHandler<StartButtonClickedEventArgs> StartButton_Clicked;
        event EventHandler<EventArgs> StopButton_Clicked;
        event EventHandler<EventArgs> PauseButton_Clicked;
        event EventHandler<ControllerChangedEventArgs> Controller_Changed;
        event EventHandler<CloseButtonClickedEventArgs> CloseButton_Clicked;
        event EventHandler<EventArgs> About_Clicked;

        void SetStartStopButtonsToPauseMode();
        void SetStartStopButtonsToStartedMode();
        void SetStartStopButtonsToStoppedMode();

        void StartListeningForInput();
        void StopListeningForInput();
        void StartIntervalTimeoutTimer(TimeSpan timeout);
        void StopIntervalTimeoutTimer();

        void LockNameEntry();
        void UnlockNameEntry();

        void DisplayController(Programmer name);
        void ResetController();

        void DisplayIntervals(IEnumerable<Interval> intervals);
        void DisplayStats(IDictionary<Programmer, int> stats);

        void Close();
        void ConfirmClose();
    }
}
