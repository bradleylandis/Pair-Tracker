using System;

namespace PairTracker.Model
{
    public class StoppedPairingSession : PairingSessionState
    {
        public void Start()
        {
            throw new NotImplementedException();
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
    }
}