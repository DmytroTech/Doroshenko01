using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FontAwesome.WPF;

namespace Doroshenko01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MWViewModel(ShowLoader);
        }

        //There's no need in this method and it looks very bad. Code was moved to ViewModel

        private void ShowLoader(bool isShow)
        {
            LoadSetting.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}
