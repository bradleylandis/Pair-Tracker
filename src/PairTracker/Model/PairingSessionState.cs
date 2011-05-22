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
