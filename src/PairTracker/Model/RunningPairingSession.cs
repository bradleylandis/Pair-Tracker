using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class RunningPairingSession : PairingSessionState
    {
        PairingSessionImpl pairingSession;

        public RunningPairingSession(PairingSessionImpl pairingSession)
        {
            this.pairingSession = pairingSession;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            pairingSession.StopCurrentInterval();
            pairingSession.CurrentState = new StoppedPairingSession();
        }

        public void SwitchController(Programmer programmer)
        {
            if (programmer == pairingSession.CurrentInterval.Programmer)
                return;

            pairingSession.StopCurrentInterval();
            pairingSession.StartNewInterval(programmer);
        }

        public void Pause()
        {
            pairingSession.StopCurrentInterval();
            pairingSession.CurrentState = new PausedPairingSession(pairingSession);
        }
    }
}