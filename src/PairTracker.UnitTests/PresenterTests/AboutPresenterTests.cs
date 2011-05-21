using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PairTracker.Presenter;
using Moq;
using PairTracker.View;

namespace PairTracker.UnitTests.PresenterTests
{
    public class AboutPresenterTests
    {
        [Test]
        public void ShowCallsShowOnView()
        {
            var mockView = new Mock<AboutView>();

            mockView.Setup(v => v.Show());

            var aboutPresenter = new AboutPresenterImpl(mockView.Object, "1.0");
            aboutPresenter.Show();

            mockView.VerifyAll();
        }
    }
}
