﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PairTracker.Model;
using NUnit.Framework;
using System.Threading;

namespace PairTracker.IntegrationTests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        PairingSessionImpl session;
        Programmer programmer1 = new Programmer("Bradley");
        Programmer programmer2 = new Programmer("Alex");

        [Given(@"a new session has been started")]
        public void GivenANewSessionHasBeenStarted()
        {
            session = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));
            session.Initialize(programmer1, programmer2);
            session.Start();
        }

        [When(@"Programmer 1 takes control")]
        [Given(@"Programmer 1 takes control")]
        public void WhenProgrammer1TakesControl()
        {
            session.SwitchController(programmer1);
        }

        [When(@"Programmer 2 takes control")]
        [Given(@"Programmer 2 takes control")]
        public void WhenProgrammer2TakesControl()
        {
            session.SwitchController(programmer2);
        }

        [When(@"the session is stopped")]
        public void WhenTheSessionIsStopped()
        {
            session.Stop();
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

        [When(@"the session is paused")]
        [Given(@"the session is paused")]
        public void WhenTheSessionIsPaused()
        {
            session.Pause();
        }

        [When(@"the session is resumed")]
        [Given(@"the session is resumed")]
        public void WhenTheSessionIsResumed()
        {
            session.Start();
        }
    }
}
