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
    /// Interaction logic for VotingView.xaml
    /// </summary>
    public partial class VotingView : Page
    {
        MainWindow mainWindow;
        int year_level, voterID, maleID = 0, femaleID = 0;
        BackgroundWorker imageLoader;
        int[] iconIDs = {1920987, 1921078, 1820826, 1820364, 1520293, 1520045};
        int[] choicesIDs;

        public VotingView(MainWindow mainWindow, int voterID ,int year_level)
        {
            InitializeComponent();
            Loaded += VotingView_Loaded;

            this.mainWindow = mainWindow;
            this.voterID = voterID;
            this.year_level = year_level;

            choicesIDs = new int[4];
            switch (year_level)
            {
                case 1:
                    choicesIDs[0] = iconIDs[2];
                    choicesIDs[1] = iconIDs[3];
                    choicesIDs[2] = iconIDs[4];
                    choicesIDs[3] = iconIDs[5];
                    break;
                case 2:
                    choicesIDs[0] = iconIDs[0];
                    choicesIDs[1] = iconIDs[1];
                    choicesIDs[2] = iconIDs[4];
                    choicesIDs[3] = iconIDs[5];
                    break;
                case 5:
                    choicesIDs[0] = iconIDs[0];
                    choicesIDs[1] = iconIDs[1];
                    choicesIDs[2] = iconIDs[2];
                    choicesIDs[3] = iconIDs[3];
                    break;
            }

            image1.Opacity = 0;
            image2.Opacity = 0;
            image3.Opacity = 0;
            image4.Opacity = 0;

            submit.IsEnabled = false;

            imageLoader = new BackgroundWorker();
            imageLoader.DoWork += imageLoader_DoWork;
            imageLoader.WorkerReportsProgress = true;
            imageLoader.ProgressChanged += imageLoader_ProgressChanged;
        }

        private void VotingView_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.FadeFrameIn();
            imageLoader.RunWorkerAsync();
        }

        private BitmapImage pixelBin(String path)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnDemand;
            bi.CreateOptions = BitmapCreateOptions.DelayCreation;
            bi.DecodePixelHeight = 577;
            bi.DecodePixelWidth = 385;
            bi.UriSource = new Uri("pack://application:,,/" + path, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            bi.Freeze();
            return bi;
        }

        private void imageLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (year_level)
            {
                case 1:
                    imageLoader.ReportProgress(1, pixelBin("Resources/2m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(11, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(2, pixelBin("Resources/2f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(12, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(3, pixelBin("Resources/5m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(13, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(4, pixelBin("Resources/5f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(14, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    break;
                case 2:
                    imageLoader.ReportProgress(1, pixelBin("Resources/1m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(11, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(2, pixelBin("Resources/1f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(12, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(3, pixelBin("Resources/5m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(13, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(4, pixelBin("Resources/5f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(14, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    break;
                case 5:
                    imageLoader.ReportProgress(1, pixelBin("Resources/1m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(11, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(2, pixelBin("Resources/1f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(12, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(3, pixelBin("Resources/2m.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(13, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    imageLoader.ReportProgress(4, pixelBin("Resources/2f.png"));
                    for (double i = 0; i <= 1; i += 0.01)
                    {
                        imageLoader.ReportProgress(14, i);
                        System.Threading.Thread.Sleep(5);
                    }
                    break;
            }
            System.Threading.Thread.Sleep(250);
        }

        private void imageLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    image1.Source = (BitmapImage)e.UserState; break;
                case 2:
                    image2.Source = (BitmapImage)e.UserState; break;
                case 3:
                    image3.Source = (BitmapImage)e.UserState; break;
                case 4:
                    image4.Source = (BitmapImage)e.UserState; break;

                case 11:
                    image1.Opacity = (double)e.UserState; break;
                case 12:
                    image2.Opacity = (double)e.UserState; break;
                case 13:
                    image3.Opacity = (double)e.UserState; break;
                case 14:
                    image4.Opacity = (double)e.UserState; break;
            }
        }      

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Opacity = 1;
            button3.Opacity = 0.4;
            maleID = choicesIDs[0];
            if (maleID != 0 && femaleID != 0)
                submit.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.Opacity = 1;
            button4.Opacity = 0.4;
            femaleID = choicesIDs[1];
            if (maleID != 0 && femaleID != 0)
                submit.IsEnabled = true;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button1.Opacity = 0.4;
            button3.Opacity = 1;
            maleID = choicesIDs[2];
            if (maleID != 0 && femaleID != 0)
                submit.IsEnabled = true;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button2.Opacity = 0.4;
            button4.Opacity = 1;
            femaleID = choicesIDs[3];
            if (maleID != 0 && femaleID != 0)
                submit.IsEnabled = true;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            submit.IsEnabled = false;
            if (mainWindow.firebase.CommandVote(new Vote(voterID, maleID, femaleID)))
                mainWindow.setFrame(new VoteStatus(mainWindow, "VOTE SUBMITTED"));
            else
                mainWindow.setFrame(new VoteStatus(mainWindow, "ALREADY VOTED"));
        }    
    }
}
