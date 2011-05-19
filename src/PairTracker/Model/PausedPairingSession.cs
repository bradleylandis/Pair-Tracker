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

        public void Start()
        {
            pairingSession.StartNewInterval(Programmer.Neither);
            pairingSession.CurrentState = new RunningPairingSession(pairingSession);
        }

        public void Stop()
        {
            pairingSession.StopCurrentInterval();
            pairingSession.CurrentState = new StoppedPairingSession();
        }

        public void SwitchController(Programmer programmer)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }
    }
}