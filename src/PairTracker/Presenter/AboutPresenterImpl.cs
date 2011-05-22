using PairTracker.View;

namespace PairTracker.Presenter
{
    public class AboutPresenterImpl : AboutPresenter
    {
        AboutView view;
        string versionNumber;

        public AboutPresenterImpl(AboutView view, string versionNumber)
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
