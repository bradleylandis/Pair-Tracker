using Ninject.Modules;
using PairTracker.View;
using PairTracker.Model;
using PairTracker.Repository;
using Raven.Client.Document;
using System.Configuration;

namespace PairTracker.UI
{
    public class PairTrackerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PairTrackerView>().To<PairTrackerForm>();
            Bind<AboutView>().To<AboutForm>();
            Bind<Clock>().To<DateTimeClock>();
            Bind<IPairingSession>().To<PairingSession>();

            //Bind<Repository<IPairingSession>>().To<FileRepository<IPairingSession>>()
            //    .WithConstructorArgument("fileLocation", ConfigurationManager.AppSettings["fileLocation"]);

            Bind<Repository<IPairingSession>>().To<RavenDBRepository<IPairingSession>>()
                .WithConstructorArgument("store", Program.DocumentStore);
        }
    }
}
