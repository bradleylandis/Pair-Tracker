using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PairTracker.Model;
using Moq;

namespace PairTracker.UnitTests.ModelTests
{
    [TestFixture]
    public class SesssionTests
    {
        [Test]
        public void StartSetsTheStartTime()
        {
            Programmer programmer1 = new Programmer("Joe");
            Programmer programmer2 = new Programmer("Bob");

            var time = DateTime.Now;

            var mockClock = new Mock<Clock>();

            mockClock.Setup(c => c.Now).Returns(time);

            var session = new Session(new IntervalFactory(mockClock.Object));

            session.Start(programmer1, programmer2);
            session.Stop();

            Assert.That(session.StartTime, Is.EqualTo(time));
        }
    }
}
