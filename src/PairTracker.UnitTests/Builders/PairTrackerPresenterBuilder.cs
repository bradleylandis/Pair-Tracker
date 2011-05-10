using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTracker.Presenter;
using PairTracker.View;
using PairTracker.Model;

namespace PairTracker.UnitTests.Builders
{
    public class PairTrackerPresenterBuilder
    {
        PairTrackerView view;
        Session model = new Session(new IntervalFactory(new DateTimeClock()));
        SessionPercentageStatisticGenerator statGenerator = new SessionPercentageStatisticGenerator();

        public PairTrackerPresenterBuilder WithView(PairTrackerView view)
        {
            this.view = view;
            return this;
        }

        public PairTrackerPresenterBuilder WithModel(Session model)
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
            return new PairTrackerPresenter(view, model, statGenerator);
        }
    }
}
