using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTracker.View;

namespace PairTracker.Presenter
{
    public class AboutPresenter
    {
        AboutView view;
        string versionNumber;

        public AboutPresenter(AboutView view, string versionNumber)
        {
            this.versionNumber = versionNumber;
            this.view = view;
        }

        public void Show()
        {
            view.DisplayVersionNumber(versionNumber);
            view.Show();
        }
    }
}
