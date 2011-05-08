using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PairTracker.Model;
using System.Threading;

namespace PairTracker.IntegrationTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ContinuousSessionWithSeveralSwitches()
        {
            var bradley = new Programmer("Bradley");
            var alex = new Programmer("Alex");

            var session = new Session(new IntervalFactory(new DateTimeClock()));

            session.Start(bradley, alex);
            session.SwitchController(bradley);
            Thread.Sleep(9000);
            session.SwitchController(alex);
            Thread.Sleep(4000);
            session.SwitchController(bradley);
            Thread.Sleep(10000);
            session.SwitchController(Programmer.Neither);
            session.Stop();

            Assert.That(session.Intervals.Count(), Is.EqualTo(5));
            Assert.That((int)session.Length.TotalSeconds, Is.EqualTo(23));
        }

        [Test]
        public void SessionWithPauseBetweenTwoSwitches()
        {
            var bradley = new Programmer("Bradley");
            var alex = new Programmer("Alex");

            var session = new Session(new IntervalFactory(new DateTimeClock()));

            session.Start(bradley, alex);
            session.SwitchController(bradley);
            Thread.Sleep(5000);
            session.Pause();
            Thread.Sleep(3000);
            session.Continue();
            session.SwitchController(alex);
            Thread.Sleep(5000);
            session.Stop();

            Assert.That(session.Intervals.Count(), Is.EqualTo(4));
            Assert.That((int)session.Length.TotalSeconds, Is.EqualTo(10));
        }
    }
}
