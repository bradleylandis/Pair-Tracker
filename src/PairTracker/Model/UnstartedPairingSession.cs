using System;

namespace PairTracker.Model
{
    public class UnstartedPairingSession : PairingSessionState
    {
        private PairingSessionImpl pairingSession;
        public UnstartedPairingSession(PairingSessionImpl pairingSession)
        {
            this.pairingSession = pairingSession;
        }

        public void Start()
        {
            pairingSession.intervals.Clear();

            pairingSession.StartNewInterval(Programmer.Neither);
            pairingSession.CurrentState = new RunningPairingSession(pairingSession);
        }

        public void Stop()
        {
            //throw new NotImplementedException();
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