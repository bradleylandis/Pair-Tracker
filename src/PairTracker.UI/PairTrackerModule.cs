using System.Configuration;
using System.Windows.Forms;
using Ninject.Modules;
using PairTracker.Model;
using PairTracker.Presenter;
using PairTracker.Repository;
using PairTracker.View;

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
            Bind<AboutPresenter>().To<AboutPresenterImpl>()
                .WithConstructorArgument("versionNumber", Application.ProductVersion);

            Bind<Repository<PairingSession>>().To<FileRepository<PairingSession>>()
                .WithConstructorArgument("fileLocation", ConfigurationManager.AppSettings["fileLocation"]);

            //Bind<Repository<PairingSession>>().To<RavenDBRepository<PairingSession>>()
            //    .WithConstructorArgument("store", Program.DocumentStore);
        }
    }
}
