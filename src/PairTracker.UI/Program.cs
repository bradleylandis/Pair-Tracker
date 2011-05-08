using System.Windows.Forms;
using PairTracker.View;
using PairTracker.Presenter;
using Ninject;
using System;

namespace PairTracker.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new PairTrackerModule());
            var presenter = kernel.Get<PairTrackerPresenter>();

            Application.Run((Form)presenter.view);
        }
    }
}
