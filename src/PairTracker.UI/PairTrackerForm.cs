using RawInput;
using PairTracker.View;
using PairTracker.Model;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using PairTracker.Presenter;

namespace PairTracker.UI
{
    public partial class PairTrackerForm : Form, PairTrackerView
    {
        InputDevice inputDevice;
        InputDevice.DeviceEventHandler handler;
        bool tracking = false;

        public event EventHandler<StartButtonClickedEventArgs> StartButton_Clicked;
        public event EventHandler<EventArgs> StopButton_Clicked;
        public event EventHandler<ControllerChangedEventArgs> Controller_Changed;
        public event EventHandler<CloseButtonClickedEventArgs> CloseButton_Clicked;
        public event EventHandler<EventArgs> About_Clicked;
        public event EventHandler<EventArgs> PauseButton_Clicked;

        private Programmer programmer1;
        private Programmer programmer2;

        Timer IntervalTimer { get; set; }

        string keyboardId1 = string.Empty;
        string keyboardId2 = string.Empty;

        public PairTrackerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputDevice = new InputDevice(Handle);
            inputDevice.EnumerateDevices();

            handler = new InputDevice.DeviceEventHandler(inputDevice_KeyPressed);

            IntervalTimer = new Timer();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //TODO: What's the best way to handle when the user clicks on the "X"?
            // I want it to go through the presenter so confirmation/save happens, but then how do you handle e.Cancel = true?
            base.OnClosing(e);
        }

        private void IntervalTimer_Tick(object sender, EventArgs e)
        {
            if (Controller_Changed != null)
                Controller_Changed(this, new ControllerChangedEventArgs(Programmer.Neither));
        }

        private void inputDevice_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            //TODO: Send the keyboard that the input came from to the controller_changed event instead of the programmer and let the presenter figure it out
            Programmer controllingProgrammer = Programmer.Neither;
            if (string.IsNullOrEmpty(keyboardId1))
                keyboardId1 = e.Keyboard.deviceHandle.ToString();
            else if(string.IsNullOrEmpty(keyboardId2) && e.Keyboard.deviceHandle.ToString() != keyboardId1)
                keyboardId2 = e.Keyboard.deviceHandle.ToString();

            if (e.Keyboard.deviceHandle.ToString() == keyboardId1)
                controllingProgrammer = programmer1;
            if (e.Keyboard.deviceHandle.ToString() == keyboardId2)
                controllingProgrammer = programmer2;

            if (Controller_Changed != null)
                Controller_Changed(this, new ControllerChangedEventArgs(controllingProgrammer));
        }
        
        protected override void WndProc(ref Message message)
        {
            if (inputDevice != null && tracking)
                inputDevice.ProcessMessage(message);
            base.WndProc(ref message);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            programmer1 = new Programmer(programmerOneName.Text);
            programmer2 = new Programmer(programmerTwoName.Text);
            if(StartButton_Clicked != null)
                StartButton_Clicked(this, new StartButtonClickedEventArgs(programmer1, programmer2));
        }

        public void StartListeningForInput()
        {
            inputDevice.KeyPressed += handler;
            tracking = true;
        }

        public void StopListeningForInput()
        {
            inputDevice.KeyPressed -= handler;
            tracking = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if(StopButton_Clicked != null)
                StopButton_Clicked(this, new EventArgs());
        }
        
        public void ConfirmClose()
        {
            var result = MessageBox.Show("A session is currently running.  Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo);
            var confirmationStatus = ConfirmationStatus.NotConfirmed;
            if (result == DialogResult.Yes)
                confirmationStatus = ConfirmationStatus.Confirmed;
            if (CloseButton_Clicked != null)
                CloseButton_Clicked(this, new CloseButtonClickedEventArgs(confirmationStatus));
        }

        public void SetStartStopButtonsToPauseMode()
        {
            startButton.Enabled = true;
            stopButton.Enabled = true;
            pauseButton.Enabled = false;
        }

        public void SetStartStopButtonsToStoppedMode()
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            pauseButton.Enabled = false;
        }

        public void SetStartStopButtonsToStartedMode()
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            pauseButton.Enabled = true;
        }

        public void LockNameEntry()
        {
            programmerOneName.Enabled = false;
            programmerTwoName.Enabled = false;
        }

        public void UnlockNameEntry()
        {
            programmerOneName.Enabled = true;
            programmerTwoName.Enabled = true;
        }

        public void DisplayController(Programmer programmer)
        {
            controllerName.Text = programmer.Name + " is currently typing.";
        }

        public void ResetController()
        {
            controllerName.Text = string.Empty;
        }

        public void DisplayIntervals(IEnumerable<Interval> intervals)
        {
            sessionDetails.Items.Clear();
            foreach (var interval in intervals)
                DisplayInterval(interval);
        }

        void DisplayInterval(Interval interval)
        {
            var item = sessionDetails.Items.Add(interval.Programmer.Name);
            item.SubItems.Add(interval.StartTime.TimeOfDay.ToString());
            item.SubItems.Add(interval.EndTime.TimeOfDay.ToString());
            item.SubItems.Add(interval.Length.ToString());
        }

        public void StartIntervalTimeoutTimer(TimeSpan timeout)
        {
            IntervalTimer.Interval = (int)timeout.TotalMilliseconds;
            IntervalTimer.Stop();
            IntervalTimer.Start();
            IntervalTimer.Tick += new EventHandler(IntervalTimer_Tick);
        }

        public void StopIntervalTimeoutTimer()
        {
            IntervalTimer.Stop();
            IntervalTimer.Tick -= new EventHandler(IntervalTimer_Tick);
        }

        public void DisplayStats(IDictionary<Programmer, Statistic> stats)
        {
            statistics.Items.Clear();
            foreach (var stat in stats)
                DisplayStat(stat);
        }

        private void DisplayStat(KeyValuePair<Programmer, Statistic> stat)
        {
            var item = statistics.Items.Add(stat.Key.Name);
            item.SubItems.Add(stat.Value.Percentage.ToString());
            item.SubItems.Add(stat.Value.TotalTime.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CloseButton_Clicked != null)
                CloseButton_Clicked(this, new CloseButtonClickedEventArgs(ConfirmationStatus.Unknown));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (About_Clicked != null)
                About_Clicked(this, new EventArgs());
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (PauseButton_Clicked != null)
                PauseButton_Clicked(this, new StartButtonClickedEventArgs(programmer1, programmer2));
        }
    }
}