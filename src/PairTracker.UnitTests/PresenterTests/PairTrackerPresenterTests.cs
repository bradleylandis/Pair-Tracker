using NUnit.Framework;
using PairTracker.Presenter;
using PairTracker.View;
using Moq;
using PairTracker.Model;
using System;
using PairTracker.UnitTests.Builders;

namespace PairTracker.UnitTests.PresenterTests
{
    [TestFixture]
    public class PairTrackerPresenterTests
    {
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
