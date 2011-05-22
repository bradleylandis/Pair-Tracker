namespace PairTracker.Repository
{
    public interface Repository<T>
    {
        void Save(T model);
    }
}
