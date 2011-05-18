﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class UnstartedPairingSession : PairingSessionState
    {
        private PairingSessionImpl pairingSession;
        public UnstartedPairingSession(PairingSessionImpl pairingSession)
        {
            this.pairingSession = pairingSession;
        }

        public void Start(Programmer programmer1, Programmer programmer2)
        {
            pairingSession.intervals.Clear();
            pairingSession.Programmer1 = programmer1;
            pairingSession.Programmer2 = programmer2;

            pairingSession.StartNewInterval(Programmer.Neither);
            pairingSession.CurrentState = new RunningPairingSession(pairingSession);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void SwitchController(Programmer programmer)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}