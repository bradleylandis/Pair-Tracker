using System.Windows.Forms;
using PairTracker.View;
using PairTracker.Presenter;
using Ninject;
using System;
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
