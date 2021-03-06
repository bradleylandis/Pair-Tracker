﻿using PairTracker.Model;
using PairTracker.Presenter;
using PairTracker.Repository;
using PairTracker.UnitTests.TestDoubles;
using PairTracker.View;

namespace PairTracker.UnitTests.Builders
{
    public class PairTrackerPresenterBuilder
    {
        PairTrackerView view;
        PairingSession model = new PairingSessionImpl(new IntervalFactory(new DateTimeClock()));
        SessionPercentageStatisticGenerator statGenerator = new SessionPercentageStatisticGenerator();
        Repository<PairingSession> repository = new TestRepository<PairingSession>();
        AboutPresenter aboutPresenter = new AboutPresenterImpl(null, "1.0.0");

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

        public PairTrackerPresenterBuilder WithAboutPresenter(AboutPresenter aboutPresenter)
        {
            this.aboutPresenter = aboutPresenter;
            return this;
        }

        public PairTrackerPresenter Build()
        {
            return new PairTrackerPresenter(view, model, aboutPresenter, statGenerator, repository);
        }
    }
}
