using NUnit.Framework;
using PairTracker.Model;
using PairTracker.UnitTests.TestDoubles;
using System;
using System.Collections.Generic;

namespace PairTracker.UnitTests.ModelTests
{
    [TestFixture]
    public class SessionPercentageStatisticGeneratorTests
    {
        [Test]
        public void SessionWith1IntervalResultsIn1ProgrammerWith100Percent()
        {
            var programmerJoe = new Programmer("Joe");
            var intervals = new List<Interval>();
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 0), new TimeSpan(0, 0, 10), programmerJoe));
            var session = new TestSession(programmerJoe, new Programmer("Bob"), intervals);

            var statGenerator = new SessionPercentageStatisticGenerator();
            var results = statGenerator.Generate(session);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[programmerJoe], Is.EqualTo(100));
        }

        [Test]
        public void SessionWith2EqualIntervalsResultsIn2ProgrammersWith50PercentEach()
        {
            var programmerJoe = new Programmer("Joe");
            var programmerBob = new Programmer("Bob");
            var intervals = new List<Interval>();
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 0), new TimeSpan(0, 0, 5), programmerJoe));
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 5), new TimeSpan(0, 0, 5), programmerBob));
            var session = new TestSession(programmerJoe, programmerBob, intervals);

            var statGenerator = new SessionPercentageStatisticGenerator();
            var results = statGenerator.Generate(session);

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[programmerJoe], Is.EqualTo(50));
            Assert.That(results[programmerBob], Is.EqualTo(50));
        }

        [Test]
        public void SessionWith3EqualIntervalsWith1BeingNeitherResultsIn2ProgrammersWith50PercentEach()
        {
            var programmerJoe = new Programmer("Joe");
            var programmerBob = new Programmer("Bob");
            var intervals = new List<Interval>();
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 0), new TimeSpan(0, 0, 5), programmerJoe));
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 5), new TimeSpan(0, 0, 5),Programmer.Neither));
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 10), new TimeSpan(0, 0, 5), programmerBob));
            var session = new TestSession(programmerJoe, programmerBob, intervals);

            var statGenerator = new SessionPercentageStatisticGenerator();
            var results = statGenerator.Generate(session);

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[programmerJoe], Is.EqualTo(50));
            Assert.That(results[programmerBob], Is.EqualTo(50));
        }

        [Test]
        public void SessionWith2IntervalsForSameProgrammerResultsIn1ProgrammersWith100Percent()
        {
            var programmerJoe = new Programmer("Joe");
            var programmerBob = new Programmer("Bob");
            var intervals = new List<Interval>();
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 0), new TimeSpan(0, 0, 5), programmerJoe));
            intervals.Add(new TestInterval(new DateTime(2000, 1, 1, 0, 0, 5), new TimeSpan(0, 0, 5), programmerJoe));
            var session = new TestSession(programmerJoe, programmerBob, intervals);

            var statGenerator = new SessionPercentageStatisticGenerator();
            var results = statGenerator.Generate(session);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[programmerJoe], Is.EqualTo(100));
        }
    }
}
