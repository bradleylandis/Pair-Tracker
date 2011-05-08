using NUnit.Framework;
using PairTracker.UnitTests.TestDoubles;
using PairTracker.Model;
using System;

namespace PairTracker.UnitTests.ModelTests
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        public void ToStringContainsProgrammerName()
        {
            var programmerName = "Joe";
            var interval = new TestInterval(new DateTime(2000, 1, 1), new TimeSpan(0, 0, 10), new Programmer(programmerName));

            Assert.That(interval.ToString(), Contains.Substring(programmerName));
        }
    }
}
