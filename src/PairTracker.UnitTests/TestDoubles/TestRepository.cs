using PairTracker.Repository;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestRepository<T> : Repository<T>
    {
        public void Save(T model)
        {
           
        }
    }
}
