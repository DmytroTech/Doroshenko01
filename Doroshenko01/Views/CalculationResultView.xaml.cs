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

namespace Doroshenko01
{

    public partial class CalculationResultView : UserControl
    {

        public CalculationResultView()
        {
            InitializeComponent();
        }

        public string PropAge
        {
            get { return (string)GetValue(PropertyAgeProperty); }
            set { SetValue(PropertyAgeProperty, value); }
        }

        public string PropWest
        {
            get { return (string)GetValue(PropertyWestProperty); }
            set { SetValue(PropertyWestProperty, value); }
        }

        public string PropChina
        {
            get { return (string)GetValue(PropertyChinaProperty); }
            set { SetValue(PropertyChinaProperty, value); }
        }

        public static readonly DependencyProperty PropertyAgeProperty = DependencyProperty.Register
        (
            "PropAge",
            typeof(string),
            typeof(CalculationResultView),
            new PropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty PropertyWestProperty = DependencyProperty.Register
        (
            "PropWest",
            typeof(string),
            typeof(CalculationResultView),
            new PropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty PropertyChinaProperty = DependencyProperty.Register
        (
            "PropChina",
            typeof(string),
            typeof(CalculationResultView),
            new PropertyMetadata(string.Empty)
        );
        

    }
}
