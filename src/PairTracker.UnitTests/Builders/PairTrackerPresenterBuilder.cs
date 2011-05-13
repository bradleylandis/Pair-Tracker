using PairTracker.Presenter;
using PairTracker.View;
using PairTracker.Model;
using PairTracker.Repository;
using PairTracker.UnitTests.TestDoubles;

namespace PairTracker.UnitTests.Builders
{
    public class PairTrackerPresenterBuilder
    {
        PairTrackerView view;
        IPairingSession model = new PairingSession(new IntervalFactory(new DateTimeClock()));
        SessionPercentageStatisticGenerator statGenerator = new SessionPercentageStatisticGenerator();
        Repository<IPairingSession> repository = new TestRepository<IPairingSession>();

        public PairTrackerPresenterBuilder WithRepository(Repository<IPairingSession> repository)
        {
            this.repository = repository;
            return this;
        }

        public PairTrackerPresenterBuilder WithView(PairTrackerView view)
        {
            this.view = view;
            return this;
        }

        public PairTrackerPresenterBuilder WithModel(IPairingSession model)
        {
            this.model = model;
            return this;
        }

        public PairTrackerPresenterBuilder WithStatGenerator(SessionPercentageStatisticGenerator statGenerator)
        {
            this.statGenerator = statGenerator;
            return this;
        }

        public PairTrackerPresenter Build()
        {
            return new PairTrackerPresenter(view, model, null, statGenerator, repository);
        }
    }
}
