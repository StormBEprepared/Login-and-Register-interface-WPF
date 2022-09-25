using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserLoginRegister.Core;

namespace UserLoginRegister.MVVM.ViewModel
{
    internal class MainViewModel :ObservableObject
    {
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutDownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ShowLoginView { get; set; }
        public RelayCommand ShowRegisterView { get; set; }
        public RelayCommand ShowPlayerView { get; set; }
        

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChange();
            }
        }

        public LoginViewModel LoginVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        public PlayerViewModel PlayerVM { get; set; }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            RegisterVM= new RegisterViewModel();
            PlayerVM = new PlayerViewModel();
            CurrentView = LoginVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutDownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });

            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowLoginView = new RelayCommand(o => { CurrentView = LoginVM; });
            ShowRegisterView = new RelayCommand(o => { CurrentView = RegisterVM; });
            ShowPlayerView = new RelayCommand(o => { CurrentView= PlayerVM; });
        }
    }
}
