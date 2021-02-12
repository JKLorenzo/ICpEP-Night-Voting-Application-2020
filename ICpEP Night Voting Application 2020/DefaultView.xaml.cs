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
    /// Interaction logic for DefaultView.xaml
    /// </summary>
    public partial class DefaultView : Page
    {
        MainWindow mainWindow;
        BackgroundWorker workerFadeOutBlockFadeInBox, workerFadeOutBoxFadeInBlock;
        MediaElement me;
        ClassList classList;
        List<Student> students;
        int currentView = 0, status = 0, voterID = 0;
        GlobalKeyboardHook _globalKeyboardHook;

        public DefaultView(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            gridTextBox.Opacity = 0;
            gridTextBlock.Opacity = 1;

            playBackgroundVideo();

            workerFadeOutBlockFadeInBox = new BackgroundWorker();
            workerFadeOutBlockFadeInBox.DoWork += workerFadeOutBlockFadeInBox_DoWork;
            workerFadeOutBlockFadeInBox.RunWorkerCompleted += workerFadeOutBlockFadeInBox_RunWorkerCompleted;
            workerFadeOutBlockFadeInBox.WorkerReportsProgress = true;
            workerFadeOutBlockFadeInBox.ProgressChanged += workerFadeOutBlockFadeInBox_ProgressChanged;

            workerFadeOutBoxFadeInBlock = new BackgroundWorker();
            workerFadeOutBoxFadeInBlock.DoWork += workerFadeOutBoxFadeInBlock_DoWork;
            workerFadeOutBoxFadeInBlock.RunWorkerCompleted += workerFadeOutBoxFadeInBlock_RunWorkerCompleted;
            workerFadeOutBoxFadeInBlock.WorkerReportsProgress = true;
            workerFadeOutBoxFadeInBlock.ProgressChanged += workerFadeOutBoxFadeInBlock_ProgressChanged;

            classList = new ClassList();

            SwitchViews();
        }

        private void searchStudent(String ID)
        {
            tb1.IsEnabled = false;
            tb2.IsEnabled = false;
            tb3.IsEnabled = false;
            tb4.IsEnabled = false;
            tb5.IsEnabled = false;
            tb6.IsEnabled = false;
            tb7.IsEnabled = false;

            students = null;
            voterID = int.Parse(ID);
            if (ID.StartsWith("192"))
                students = classList.first_year;
            else if (ID.StartsWith("182"))
                students = classList.second_year;
            else if (ID.StartsWith("152") || ID.StartsWith("142") || ID.StartsWith("132") || ID.StartsWith("010"))
                students = classList.fifth_year;


            bool hasMatch = false;
            Student thisStudent = null;
            if (students != null)
            {
                foreach (Student student in students)
                {
                    if (ID.Equals(student.ID.ToString()))
                    {
                        thisStudent = student;
                        hasMatch = true;
                    }
                }
            }
            
            if (hasMatch)
            {
                bool hasVoted = false;
                List<Vote> voted = mainWindow.firebase.voted;
                foreach (Vote vote in voted)
                    if (voterID == vote.ID)
                        hasVoted = true;

                if (hasVoted)
                {
                    textBlock.Text = "Already Voted";
                    gridTextBlockInstruct1.Text = "Press 'Back Space' to go back";
                    gridTextBlockInstruct2.Text = "";
                }
                else
                {
                    textBlock.Text = thisStudent.Name;
                    gridTextBlockInstruct1.Text = "Press 'Enter' to continue";
                    gridTextBlockInstruct2.Text = "Press 'Back Space' to go back";
                }
            }
            else
            {
                textBlock.Text = "Not Found";
                gridTextBlockInstruct1.Text = "Press 'Back Space' to go back";
                gridTextBlockInstruct2.Text = "";
            }
            textBlock.FontSize = 40;
            Console.WriteLine(DateTime.Now + " Search Student | Calling SwitchView");
            SwitchViews();
        }

        private void Continue()
        {
            Console.WriteLine("Continue Method | Called");
            if (!textBlock.Text.Equals("Not Found") && !gridTextBlockInstruct1.Text.Equals("Press 'Back Space' to go back"))
            {
                Console.WriteLine("Continue Method | Changing Frame");
                int year_level = 0;
                if (students == classList.first_year)
                    year_level = 1;
                else if (students == classList.second_year)
                    year_level = 2;
                else if (students == classList.fifth_year)
                    year_level = 5;
                
                mainWindow.setFrame(new VotingView(mainWindow, voterID, year_level));
            }
            Console.WriteLine("Continue Method | Called");
        }

        private void SwitchViews()
        {
            Console.WriteLine(DateTime.Now + " Switch View | Started");
            if (status == 0)
            {
                status = 1;
                if (currentView == 0)
                {
                    Console.WriteLine(DateTime.Now + " Switch View | Switching to TextBox");
                    workerFadeOutBlockFadeInBox.RunWorkerAsync();
                    gridTextBox.Visibility = Visibility.Visible;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + " Switch View | Switching to TextBlock");
                    workerFadeOutBoxFadeInBlock.RunWorkerAsync();
                    gridTextBlock.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Console.WriteLine(DateTime.Now + " Switch View | Switching view failed");
            }
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                switch (e.KeyboardData.VirtualCode)
                {
                    case 8:
                        if (currentView == 0 && status == 0)
                        {
                            Console.WriteLine(DateTime.Now + " OnKeyPressed | Calling SwitchView()");
                            _globalKeyboardHook?.Dispose();
                            SwitchViews();
                        }
                        break;
                    case 13:
                        if (currentView == 0 && status == 0)
                        {
                            Console.WriteLine(DateTime.Now + " OnKeyPressed | Calling Continue()");
                            _globalKeyboardHook?.Dispose();
                            Continue();
                            e.Handled = true;
                        }
                        break;
                }
            }
        }

        #region Animation BackgroundWorker

        private void workerFadeOutBlockFadeInBox_DoWork(object sender, DoWorkEventArgs e)
        {
            if (mainWindow.initial == true)
            {
                while (mainWindow.firebase.isConnected().Result == false && voterID == 0)
                    System.Threading.Thread.Sleep(1000);
                mainWindow.firebase.startVotedListener();
                mainWindow.initial = false;
            }

            for (double i = 1; i >= 0; i -= 0.01)
            {
                workerFadeOutBlockFadeInBox.ReportProgress(1, i);
                System.Threading.Thread.Sleep(2);
            }
            for (double i = 0; i <= 1; i += 0.01)
            {
                workerFadeOutBlockFadeInBox.ReportProgress(2, i);
                System.Threading.Thread.Sleep(10);
            }
        }

        private void workerFadeOutBlockFadeInBox_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                gridTextBlock.Opacity = Double.Parse(e.UserState.ToString());
                if (gridTextBlockInstruct.Opacity > Double.Parse(e.UserState.ToString()))
                    gridTextBlockInstruct.Opacity = Double.Parse(e.UserState.ToString());
            }
            else
            {
                gridTextBox.Opacity = Double.Parse(e.UserState.ToString());
            }
        }

        private void workerFadeOutBlockFadeInBox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridTextBlock.Visibility = Visibility.Collapsed;
            if (!tb7.Text.Equals(""))
                tb7.Text = "";
                
            currentView = 1;
            status = 0;

            _globalKeyboardHook?.Dispose();

            tb1.IsEnabled = true;
            tb2.IsEnabled = true;
            tb3.IsEnabled = true;
            tb4.IsEnabled = true;
            tb5.IsEnabled = true;
            tb6.IsEnabled = true;
            tb7.IsEnabled = true;

            if (tb1.Text.Equals(""))
                tb1.Focus();
            else
                tb7.Focus();
            Console.WriteLine(DateTime.Now + " FadeIn Box | Fading Completed");
        }

        private void workerFadeOutBoxFadeInBlock_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(150);
            for (double i = 1; i >= 0; i -= 0.01)
            {
                workerFadeOutBoxFadeInBlock.ReportProgress(1, i);
                System.Threading.Thread.Sleep(2);
            }
            for (double i = 0; i <= 1; i += 0.01)
            {
                workerFadeOutBoxFadeInBlock.ReportProgress(2, i);
                System.Threading.Thread.Sleep(10);
            }
        }

        private void workerFadeOutBoxFadeInBlock_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    gridTextBox.Opacity = Double.Parse(e.UserState.ToString());
                    break;
                case 2:
                    gridTextBlock.Opacity = Double.Parse(e.UserState.ToString());
                    gridTextBlockInstruct.Opacity = Double.Parse(e.UserState.ToString());
                    break;
            }
        }

        private void workerFadeOutBoxFadeInBlock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridTextBox.Visibility = Visibility.Collapsed;
            currentView = 0;
            status = 0;

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            Console.WriteLine(DateTime.Now + " FadeIn Block | Fading Completed");
        }

        #endregion

        #region Background Video Controls

        private void playBackgroundVideo()
        {
            VisualBrush vb = new VisualBrush();
            me = new MediaElement();
            me.Stretch = Stretch.UniformToFill;
            me.Width = 1920;
            me.Height = 1080;
            me.LoadedBehavior = MediaState.Manual;
            me.MediaOpened += Me_MediaOpened;
            me.MediaEnded += me_OnMediaEnded;
            me.Source = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "BackgroundVideo.mp4"), UriKind.Relative);
            me.Volume = 0;
            me.Play();
            me.SpeedRatio = 1;
            vb.Visual = me;
            // Set Background from Black to Vid
            mainWindow.grid.Background = vb;
            
        }

        private void Me_MediaOpened(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Media Element | Media Opened");
            mainWindow.FadeFrameIn();
        }

        private void me_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            me.Position = new TimeSpan(0, 0, 0);
            me.Play();
        }

        #endregion

        #region TextBox Control Handlers

        private KeyEventArgs FilterInput(KeyEventArgs e)
        {
            char x = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (!char.IsDigit(x) && !char.IsControl(x) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                e.Handled = true;
            return e;
        }

        private void tb1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                tb1.Text = "";
                e.Handled = true;
            }
        }

        private void tb2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb2.Text.Equals(""))
                    tb1.Text = "";
                else
                    tb2.Text = "";
                tb1.Focus();
                e.Handled = true;
            }
        }

        private void tb3_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb3.Text.Equals(""))
                    tb2.Text = "";
                else
                    tb3.Text = "";
                tb2.Focus();
                e.Handled = true;
            }
        }

        private void tb4_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb4.Text.Equals(""))
                    tb3.Text = "";
                else
                    tb4.Text = "";
                tb3.Focus();
                e.Handled = true;
            }
        }

        private void tb5_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb5.Text.Equals(""))
                    tb4.Text = "";
                else
                    tb5.Text = "";
                tb4.Focus();
                e.Handled = true;
            }
        }

        private void tb6_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb6.Text.Equals(""))
                    tb5.Text = "";
                else
                    tb6.Text = "";
                tb5.Focus();
                e.Handled = true;
            }
        }

        private void tb7_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e = FilterInput(e);
            if (e.Key == Key.Back)
            {
                if (tb7.Text.Equals(""))
                {
                    tb6.Text = "";
                    tb6.Focus();
                }
                else
                    tb7.Text = "";
                    
                e.Handled = true;
            }
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb1.Text.Equals(""))
            {
                tb2.Focus();
            }
        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb2.Text.Equals(""))
            {
                tb3.Focus();
            }
        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb3.Text.Equals(""))
            {
                tb4.Focus();
            }
        }

        private void tb4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb4.Text.Equals(""))
            {
                tb5.Focus();
            }
        }

        private void tb5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb5.Text.Equals(""))
            {
                tb6.Focus();
            }
        }

        private void tb6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb6.Text.Equals(""))
            {
                tb7.Focus();
            }
        }

        private void tb7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb7.Text.Equals(""))
            {
                Console.WriteLine(DateTime.Now + " tb7 TextChanged | Calling SearchStudent()");
                String ID = tb1.Text + tb2.Text + tb3.Text + tb4.Text + tb5.Text + tb6.Text + tb7.Text;
                searchStudent(ID);
            }
        }
        #endregion
    }
}
