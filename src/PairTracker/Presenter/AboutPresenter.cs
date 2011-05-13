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

        public AboutPresenter(AboutView view)
        {
            this.view = view;
        }

        public void Show()
        {
            view.Show();
        }
    }
}
