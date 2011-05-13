using PairTracker.Model;
using PairTracker.View;
using System.Collections.Generic;
using System;
using PairTracker.Repository;

namespace PairTracker.Presenter
{
    public class PairTrackerPresenter
    {
        public PairTrackerView view { get; private set; }
        PairingSession model;
        SessionPercentageStatisticGenerator statGenerator;
        Repository<PairingSession> repository;
        AboutPresenter aboutPresenter;

        public PairTrackerPresenter(PairTrackerView view, PairingSession model, AboutPresenter aboutPresenter, SessionPercentageStatisticGenerator statGenerator, Repository<PairingSession> repository)
        {
            this.view = view;
            this.model = model;
            this.statGenerator = statGenerator;
            this.repository = repository;
            this.aboutPresenter = aboutPresenter;

            view.StartButton_Clicked += new EventHandler<StartButtonClickedEventArgs>(StartSession);
            view.StopButton_Clicked += new EventHandler<EventArgs>(EndSession);
            view.Controller_Changed += new EventHandler<ControllerChangedEventArgs>(ChangeControllerHandler);
            view.CloseButton_Clicked += new EventHandler<CloseButtonClickedEventArgs>(Close);
            view.About_Clicked += new EventHandler<EventArgs>(ShowAbout);
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            aboutPresenter.Show();
        }

        private void Close(object sender, CloseButtonClickedEventArgs e)
        {
            if (e.ConfirmationStatus == ConfirmationStatus.Confirmed || !model.IsRunning)
            {
                EndSession();
                view.Close();
            }
            else if (e.ConfirmationStatus == ConfirmationStatus.Unknown)
            {
                view.ConfirmClose();
            }
        }

        private void StartSession(object sender, StartButtonClickedEventArgs e) 
        {
            model.Start(e.Programmer1, e.Programmer2);
            view.LockNameEntry();
            view.SetStartStopButtonsToStartedMode();
            view.DisplayIntervals(model.Intervals);
        }

        private void EndSession(object sender, EventArgs e) 
        { 
            EndSession();
        }

        private void EndSession()
        {
            model.Stop();

            view.ResetController();
            view.UnlockNameEntry();
            view.SetStartStopButtonsToStoppedMode();
            view.DisplayIntervals(model.Intervals);

            DisplayStats();
            repository.Save(model);
        }

        private void DisplayStats()
        {
            view.DisplayStats(statGenerator.Generate(model));
        }

        private void ChangeControllerHandler(object sender, ControllerChangedEventArgs e)
        {
            model.SwitchController(e.Programmer);
            view.StartIntervalTimeoutTimer(model.IntervalTimeout);
            if (model.CurrentInterval.Programmer == Programmer.Neither)
                view.ResetController();
            else
                view.DisplayController(model.CurrentInterval.Programmer);
            view.DisplayIntervals(model.Intervals);
            DisplayStats();
        }
    }
}