using System.Windows.Forms;
using PairTracker.View;

namespace PairTracker.UI
{
    public partial class AboutForm : Form, AboutView
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            this.ShowDialog();
        }
    }
}
