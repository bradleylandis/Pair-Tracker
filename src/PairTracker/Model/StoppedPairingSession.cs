using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public class StoppedPairingSession : PairingSessionState
    {
        public void Start(Programmer programmer1, Programmer programmer2)
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

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}