using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class PausedPairingSession : PairingSessionState
    {
        PairingSessionImpl pairingSession;

        public PausedPairingSession(PairingSessionImpl pairingSession)
        {
            this.pairingSession = pairingSession;
        }

        public void Start(Programmer programmer1, Programmer programmer2)
        {
            throw new NotImplementedException();
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
            pairingSession.StartNewInterval(Programmer.Neither);
            pairingSession.CurrentState = new RunningPairingSession(pairingSession);
        }
    }
}
