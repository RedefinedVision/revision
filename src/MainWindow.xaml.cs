using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace revision_app
{
    public partial class MainWindow : Window
    {
        public static MainWindow _Instance;
        public MainWindow()
        {
            InitializeComponent();
            Thread.Sleep(1500 / Environment.ProcessorCount); // Avoid launch lag.

            _Instance = this;
        }

        private void NavigationChanged(object sender, RoutedEventArgs e)
        {
            // Neutral: #FF1B1E1E
            // Active: #FF333838

            Button ClickedButton = sender as Button;
            if (ClickedButton != null)
            {
                int ButtonCount = 0;
                foreach (FrameworkElement CurrentElement in navbar_buttons.Children)
                {
                    if (CurrentElement is Button)
                    {
                        ButtonCount++;
                        Button CurrentButton = CurrentElement as Button;
                        CurrentButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF1B1E1E");

                        if (CurrentButton == ClickedButton)
                        {
                            // Bind button actions
                            switch (ButtonCount)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }
                        }
                    }
                }

                ClickedButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF333838");
            }
        }

        private void DragbarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public static void HandlerNavigate(string ViewPath) => MainWindow._Instance.handler.Navigate(new Uri(ViewPath, UriKind.Relative));
    }
}
