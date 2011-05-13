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
        PairingSession model = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));
        SessionPercentageStatisticGenerator statGenerator = new SessionPercentageStatisticGenerator();
        Repository<PairingSession> repository = new TestRepository<PairingSession>();

        public PairTrackerPresenterBuilder WithRepository(Repository<PairingSession> repository)
        {
            this.repository = repository;
            return this;
        }

        public PairTrackerPresenterBuilder WithView(PairTrackerView view)
        {
            this.view = view;
            return this;
        }

        public PairTrackerPresenterBuilder WithModel(PairingSession model)
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
