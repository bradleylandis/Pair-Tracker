namespace PairTracker.Model
{
    public interface StatisticGenerator<T>
    {
        T Generate(PairingSession session);
    }
}
