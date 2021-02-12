using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace ICpEP_Night_Voting_Application_2020
{
    /// <summary>
    /// Interaction logic for VoteStatus.xaml
    /// </summary>
    public partial class VoteStatus : Page
    {
        BackgroundWorker backgroundWorkerDelay;
        MainWindow mainWindow;
        public VoteStatus(MainWindow mainWindow, String status)
        {
            InitializeComponent();
            Loaded += VoteStatus_Loaded;

            textBlock.Text = status;

            this.mainWindow = mainWindow;

            backgroundWorkerDelay = new BackgroundWorker();
            backgroundWorkerDelay.DoWork += BackgroundWorkerDelay_DoWork;
            backgroundWorkerDelay.RunWorkerCompleted += BackgroundWorkerDelay_RunWorkerCompleted;
        }

        private void VoteStatus_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.FadeFrameIn();
            backgroundWorkerDelay.RunWorkerAsync();
        }

        private void BackgroundWorkerDelay_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1500);
        }
        private void BackgroundWorkerDelay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainWindow.setFrame(new DefaultView(mainWindow));
        }
    }
}
