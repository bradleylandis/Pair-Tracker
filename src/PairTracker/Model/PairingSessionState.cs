using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Model
{
    public interface PairingSessionState
    {
        void Start();
        void Stop();
        void SwitchController(Programmer programmer);
        void Pause();
    }
}
