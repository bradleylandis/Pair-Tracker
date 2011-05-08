using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PairTracker.Model;
using Moq;
using PairTracker.UnitTests.TestDoubles;

namespace PairTracker.UnitTests.ModelTests
{
    [TestFixture]
    public class SesssionTests
    {
        [Test]
        public void LengthAddsUpLengthOfAllTheIntervals()
        {
            var intervals = new List<Interval>();
            intervals.Add(new TestInterval(new DateTime(), new TimeSpan(0, 0, 1), null));
            intervals.Add(new TestInterval(new DateTime(), new TimeSpan(0, 0, 1), null));

            var session = new TestSession(null, null, intervals);
            
            Assert.That(session.Length.TotalSeconds, Is.EqualTo(2));
        }

        [Test]
        public void PauseStopsCurrentIntervalButDoesntAddANewInterval()
        {
            var session = new Session(new IntervalFactory(new DateTimeClock()));

            session.Start(new Programmer("Joe"), new Programmer("Bob"));
            session.Pause();

            Assert.That(session.Intervals.Count(), Is.EqualTo(1));
            Assert.That(session.CurrentInterval, Is.Null);
        }

        [Test]
        public void ContinueStartsANewInterval()
        {
            var session = new Session(new IntervalFactory(new DateTimeClock()));

            session.Start(new Programmer("Joe"), new Programmer("Bob"));
            session.Pause();
            session.Continue();

            Assert.That(session.Intervals.Count(), Is.EqualTo(1));
            Assert.That(session.CurrentInterval, Is.Not.Null);
        }

        [Test]
        public void ToStringContainsProgrammer1Name()
        {
            var programmerName = "Joe";
            var session = new Session(new IntervalFactory(new DateTimeClock()));
            session.Start(new Programmer(programmerName), new Programmer("Bob"));
            session.Stop();

            Assert.That(session.ToString(), Contains.Substring(programmerName));
        }
    }
}
