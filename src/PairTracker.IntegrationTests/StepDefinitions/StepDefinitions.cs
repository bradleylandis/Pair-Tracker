using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PairTracker.Model;
using NUnit.Framework;
using System.Threading;
using PairTracker.Presenter;
using Moq;
using PairTracker.View;
using PairTracker.Repository;

namespace PairTracker.IntegrationTests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        PairTrackerPresenter presenter;
        Programmer programmer1 = new Programmer("Bradley");
        Programmer programmer2 = new Programmer("Alex");
        Mock<PairTrackerView> stubPairTrackerView = new Mock<PairTrackerView>();
        PairingSession session = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));

        [Given(@"a new session has been started")]
        public void GivenANewSessionHasBeenStarted()
        {
            var stubAboutView = new Mock<AboutView>();
            var stubRepository = new Mock<Repository<PairingSession>>();
            presenter = new PairTrackerPresenter(stubPairTrackerView.Object, session, new AboutPresenterImpl(stubAboutView.Object, "1.0.0"), new SessionPercentageStatisticGenerator(), stubRepository.Object);
            stubPairTrackerView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));
        }

        [When(@"Programmer 1 takes control")]
        [Given(@"Programmer 1 takes control")]
        public void WhenProgrammer1TakesControl()
        {
            stubPairTrackerView.Raise(v => v.Controller_Changed += null, new ControllerChangedEventArgs(programmer1));
        }

        [When(@"Programmer 2 takes control")]
        [Given(@"Programmer 2 takes control")]
        public void WhenProgrammer2TakesControl()
        {
            stubPairTrackerView.Raise(v => v.Controller_Changed += null, new ControllerChangedEventArgs(programmer2));
        }

        [When(@"the session is stopped")]
        public void WhenTheSessionIsStopped()
        {
            stubPairTrackerView.Raise(v => v.StopButton_Clicked += null, new EventArgs());
        }


        [When(@"the session is paused")]
        [Given(@"the session is paused")]
        public void WhenTheSessionIsPaused()
        {
            stubPairTrackerView.Raise(v => v.PauseButton_Clicked += null, new EventArgs());
        }

        [When(@"the session is resumed")]
        [Given(@"the session is resumed")]
        public void WhenTheSessionIsResumed()
        {
            stubPairTrackerView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));
        }

        [Then(@"the session contains (\d+) interval[s]*")]
        public void ThenTheSessionContainsNIntervals(int n)
        {
            Assert.That(session.Intervals.Count(), Is.EqualTo(n));
        }

        [When(@"(\d+) seconds elapses")]
        [Given(@"(\d+) seconds elapses")]
        public void When_NSecondsElapses(int n)
        {
            Thread.Sleep(n * 1000);
        }

        [Then(@"the session length is (\d+) second[s]*")]
        public void ThenTheSessionLengthIsNSeconds(int n)
        {
            Assert.That(Math.Floor(session.Length.TotalSeconds), Is.EqualTo(n));
        }
    }
}
