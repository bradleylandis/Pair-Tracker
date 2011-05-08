namespace PairTracker.Model
{
    interface StatisticFormatter<T, U>
    {
        U Format(T data);
    }
}
