using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PairTracker.Model;
using PairTracker.UnitTests.TestDoubles;

namespace PairTracker.UnitTests.ModelTests
{
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
            var session = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));

            session.Initialize(new Programmer("Joe"), new Programmer("Bob"));
            session.Start();
            session.Pause();

            Assert.That(session.Intervals.Count(), Is.EqualTo(1));
            Assert.That(session.CurrentInterval, Is.Null);
        }

        [Test]
        public void ResumeStartsANewInterval()
        {
            var session = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));

            session.Initialize(new Programmer("Joe"), new Programmer("Bob"));
            session.Start();
            session.Pause();
            session.Start();

            Assert.That(session.Intervals.Count(), Is.EqualTo(1));
            Assert.That(session.CurrentInterval, Is.Not.Null);
        }

        [Test]
        public void ToStringContainsProgrammer1Name()
        {
            var programmerName = "Joe";
            var session = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));
            session.Initialize(new Programmer(programmerName), new Programmer("Bob"));
            session.Start();
            session.Stop();

            Assert.That(session.ToString(), Contains.Substring(programmerName));
        }
    }
}
