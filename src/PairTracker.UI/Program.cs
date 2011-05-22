using System;
using System.Windows.Forms;
using Ninject;
using PairTracker.Presenter;
using Raven.Client.Document;

namespace PairTracker.UI
{
    public static class Program
    {
        public static DocumentStore DocumentStore { get; private set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DocumentStore = new DocumentStore() { ConnectionStringName = "RavenDBServer" };
            DocumentStore.Initialize();

            IKernel kernel = new StandardKernel(new PairTrackerModule());
            var presenter = kernel.Get<PairTrackerPresenter>();

            Application.Run((Form)presenter.view);

            DocumentStore.Dispose();
        }
    }
}
