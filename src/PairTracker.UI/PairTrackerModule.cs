using Ninject.Modules;
using PairTracker.View;
using PairTracker.Model;
using PairTracker.Repository;
using Raven.Client.Document;
using System.Configuration;
using System.Windows.Forms;
using PairTracker.Presenter;

namespace PairTracker.UI
{
    public class PairTrackerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PairTrackerView>().To<PairTrackerForm>();
            Bind<AboutView>().To<AboutForm>();
            Bind<Clock>().To<DateTimeClock>();
            Bind<PairingSession>().To<PairingSessionImpl>();
            Bind<AboutPresenter>().ToSelf()
                .WithConstructorArgument("versionNumber", Application.ProductVersion);

            Bind<Repository<PairingSession>>().To<FileRepository<PairingSession>>()
                .WithConstructorArgument("fileLocation", ConfigurationManager.AppSettings["fileLocation"]);

            //Bind<Repository<PairingSession>>().To<RavenDBRepository<PairingSession>>()
            //    .WithConstructorArgument("store", Program.DocumentStore);
        }
    }
}
