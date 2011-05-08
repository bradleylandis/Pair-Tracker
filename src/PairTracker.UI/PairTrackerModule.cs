using Ninject.Modules;
using PairTracker.View;
using PairTracker.Model;

namespace PairTracker.UI
{
    public class PairTrackerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PairTrackerView>().To<PairTrackerForm>();
            Bind<Clock>().To<DateTimeClock>();
        }
    }
}
