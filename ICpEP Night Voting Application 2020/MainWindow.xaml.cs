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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker workerFadeFrame, workerFadeFrameIn;
        public FireBaseHelper firebase;

        public bool initial = true;
        public MainWindow()
        {
            InitializeComponent();

            workerFadeFrame = new BackgroundWorker();
            workerFadeFrame.DoWork += workerFadeFrame_DoWork;
            workerFadeFrame.WorkerReportsProgress = true;
            workerFadeFrame.ProgressChanged += workerFadeFrame_ProgressChanged;

            workerFadeFrameIn = new BackgroundWorker();
            workerFadeFrameIn.DoWork += workerFadeFrameIn_DoWork;
            workerFadeFrameIn.WorkerReportsProgress = true;
            workerFadeFrameIn.ProgressChanged += workerFadeFrameIn_ProgressChanged;

            firebase = new FireBaseHelper();

            setFrame(new DefaultView(this));

            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
        }

        public bool isSettingFrame()
        {
            return workerFadeFrame.IsBusy;
        }

        public void setFrame(Page page){
            Console.WriteLine("Set Frame | Changing frame");
            if (!workerFadeFrame.IsBusy)
                workerFadeFrame.RunWorkerAsync(page);
        }
        public void FadeFrameIn()
        {
            if (!workerFadeFrameIn.IsBusy)
                workerFadeFrameIn.RunWorkerAsync();
        }

        private void workerFadeFrame_DoWork(object sender, DoWorkEventArgs e)
        {
            for (double i = 1; i >= 0; i -= 0.01)
            {
                workerFadeFrame.ReportProgress(1, i);
                System.Threading.Thread.Sleep(2);
            }
            workerFadeFrame.ReportProgress(2, e.Argument);
        }

        private void workerFadeFrame_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
                frame.Opacity = (double)e.UserState;
            if (e.ProgressPercentage == 2)
            {
                frame.NavigationService.Navigate((Page)e.UserState);
                frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            }
                
        }

        private void workerFadeFrameIn_DoWork(object sender, DoWorkEventArgs e)
        {
            for (double i = 0; i <= 1; i += 0.01)
            {
                workerFadeFrameIn.ReportProgress(1, i);
                System.Threading.Thread.Sleep(2);
            }
        }

        private void workerFadeFrameIn_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
                frame.Opacity = (double)e.UserState;
        }

        #region Window Scaling
        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else
                return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {

        }

        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);
            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }

        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }

        private void CalculateScale()
        {
            double yScale = ActualHeight / 785f;
            double xScale = ActualWidth / 745f;
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(myMainWindow, value);
        }
        #endregion
    }
}
