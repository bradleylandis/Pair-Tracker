using System;
using Moq;
using NUnit.Framework;
using PairTracker.Model;
using PairTracker.Presenter;
using PairTracker.Repository;
using PairTracker.UnitTests.Builders;
using PairTracker.View;

namespace PairTracker.UnitTests.PresenterTests
{
    public class PairTrackerPresenterTests
    {
        [Test]
        public void Pause()
        {
            var stubModel = new Mock<PairingSession>();
            var mockPairTrackerView = new Mock<PairTrackerView>();

            mockPairTrackerView.Setup(v => v.SetStartStopButtonsToPauseMode());

            var presenter = new PairTrackerPresenterBuilder().WithView(mockPairTrackerView.Object).WithModel(stubModel.Object).Build();
            mockPairTrackerView.Raise(v => v.PauseButton_Clicked += null, new EventArgs());

            mockPairTrackerView.VerifyAll();
        }

        [Test]
        public void CloseWithNotConfirmedConfirmationStatusAndSessionIsRunningCallsNothing()
        {
            var stubModel = new Mock<PairingSession>();
            var mockPairTrackerView = new Mock<PairTrackerView>(MockBehavior.Strict);

            stubModel.Setup(m => m.IsRunning).Returns(true);

            var presenter = new PairTrackerPresenterBuilder().WithView(mockPairTrackerView.Object).WithModel(stubModel.Object).Build();
            mockPairTrackerView.Raise(v => v.CloseButton_Clicked += null, new CloseButtonClickedEventArgs(ConfirmationStatus.NotConfirmed));

            mockPairTrackerView.VerifyAll();
        }

        [Test]
        public void CloseWithConfirmedConfirmationStatusAndSessionIsRunningCallsClose()
        {
            var stubModel = new Mock<PairingSession>();
            var mockPairTrackerView = new Mock<PairTrackerView>();

            mockPairTrackerView.Setup(v => v.Close());
            stubModel.Setup(m => m.IsRunning).Returns(true);

            var presenter = new PairTrackerPresenterBuilder().WithView(mockPairTrackerView.Object).WithModel(stubModel.Object).Build();
            mockPairTrackerView.Raise(v => v.CloseButton_Clicked += null, new CloseButtonClickedEventArgs(ConfirmationStatus.Confirmed));

            mockPairTrackerView.VerifyAll();
        }

        [Test]
        public void CloseWithUnknownConfirmationStatusAndSessionIsRunningCallsConfirmClose()
        {
            var stubModel = new Mock<PairingSession>();
            var mockPairTrackerView = new Mock<PairTrackerView>();

            mockPairTrackerView.Setup(v => v.ConfirmClose());
            stubModel.Setup(m => m.IsRunning).Returns(true);

            var presenter = new PairTrackerPresenterBuilder().WithView(mockPairTrackerView.Object).WithModel(stubModel.Object).Build();
            mockPairTrackerView.Raise(v => v.CloseButton_Clicked += null, new CloseButtonClickedEventArgs(ConfirmationStatus.Unknown));

            mockPairTrackerView.VerifyAll();
        }

        [Test]
        public void CloseWithSessionIsNotRunningCallsClose()
        {
            var stubModel = new Mock<PairingSession>();
            var mockPairTrackerView = new Mock<PairTrackerView>();

            mockPairTrackerView.Setup(v => v.Close());
            stubModel.Setup(m => m.IsRunning).Returns(false);

            var presenter = new PairTrackerPresenterBuilder().WithView(mockPairTrackerView.Object).WithModel(stubModel.Object).Build();
            mockPairTrackerView.Raise(v => v.CloseButton_Clicked += null, new CloseButtonClickedEventArgs(ConfirmationStatus.Unknown));

            mockPairTrackerView.VerifyAll();
        }

        [Test]
        public void ShowAboutCallsShowOnAboutPresenter()
        {
            var mockAboutPresenter = new Mock<AboutPresenter>();
            var stubPairTrackerView = new Mock<PairTrackerView>();

            mockAboutPresenter.Setup(p => p.Show());

            var presenter = new PairTrackerPresenterBuilder().WithView(stubPairTrackerView.Object).WithAboutPresenter(mockAboutPresenter.Object).Build();
            stubPairTrackerView.Raise(v => v.About_Clicked += null, new EventArgs());

            mockAboutPresenter.VerifyAll();
        }

        [Test]
        public void StopCallsSave()
        {
            var programmer1 = new Programmer("Joe");
            var programmer2 = new Programmer("Bob");
            var stubSession = new Mock<PairingSession>();

            var stubView = new Mock<PairTrackerView>();
            var mockRepository = new Mock<Repository<PairingSession>>();

            mockRepository.Setup(r => r.Save(stubSession.Object));

            var presenter = new PairTrackerPresenterBuilder().WithView(stubView.Object).WithModel(stubSession.Object).WithRepository(mockRepository.Object).Build();
            stubView.Raise(v => v.StopButton_Clicked += null, new EventArgs());

            mockRepository.VerifyAll();
        }
        
        [Test]
        public void LockNameEntryGetsCalledOnTheViewWhenTheViewRaisesStartButton_Clicked()
        {
            var programmer1 = new Programmer("Joe");
            var programmer2 = new Programmer("Bob");

            var mockView = new Mock<PairTrackerView>();

            mockView.Setup(v => v.LockNameEntry());

            var presenter = new PairTrackerPresenterBuilder().WithView(mockView.Object).Build();
            mockView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));

            mockView.VerifyAll();
        }

        [Test]
        public void UnlockNameEntryGetsCalledOnTheViewWhenTheViewRaisesStopButton_Clicked()
        {
            var programmer1 = new Programmer("Joe");
            var programmer2 = new Programmer("Bob");

            var mockView = new Mock<PairTrackerView>();

            mockView.Setup(v => v.UnlockNameEntry());

            var presenter = new PairTrackerPresenterBuilder().WithView(mockView.Object).Build();
            mockView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));
            mockView.Raise(v => v.StopButton_Clicked += null, new EventArgs());

            mockView.VerifyAll();
        }

        [Test]
        public void DisplayControllerGetsCalledOnTheViewWhenTheViewRaisesControllerChanged()
        {
            var programmer1 = new Programmer("Joe");
            var programmer2 = new Programmer("Bob");

            var mockView = new Mock<PairTrackerView>();

            mockView.Setup(v => v.DisplayController(programmer1));

            var presenter = new PairTrackerPresenterBuilder().WithView(mockView.Object).Build();
            mockView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));
            mockView.Raise(v => v.Controller_Changed += null, new ControllerChangedEventArgs(programmer1));

            mockView.VerifyAll();
        }

        [Test]
        public void ResetControllerGetsCalledOnTheViewWhenTheViewRaisesControllerChangedWithNeitherProgrammer()
        {
            var programmer1 = new Programmer("Joe");
            var programmer2 = new Programmer("Bob");

            var mockView = new Mock<PairTrackerView>();

            mockView.Setup(v => v.ResetController());

            var presenter = new PairTrackerPresenterBuilder().WithView(mockView.Object).Build();
            mockView.Raise(v => v.StartButton_Clicked += null, new StartButtonClickedEventArgs(programmer1, programmer2));
            mockView.Raise(v => v.Controller_Changed += null, new ControllerChangedEventArgs(Programmer.Neither));

            mockView.VerifyAll();
        }
    }
}
