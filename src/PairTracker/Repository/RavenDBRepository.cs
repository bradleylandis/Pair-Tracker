using Raven.Client.Document;

namespace PairTracker.Repository
{
    public class RavenDBRepository<T> : Repository<T>
    {
        DocumentStore store;
        public RavenDBRepository(DocumentStore store)
        {
            this.store = store;
        }

        public void Save(T model)
        {
            using (var session = store.OpenSession())
            {
                session.Store(model);
                session.SaveChanges();
            }
        }
    }
}
