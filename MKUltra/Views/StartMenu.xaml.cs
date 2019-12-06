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

namespace MKUltra.Views
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : UserControl
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedDifficultyProperty =
            DependencyProperty.Register("SelectedDifficulty", typeof(string), typeof(StartMenu));
        public string SelectedDifficulty
        {
            get { return (string)GetValue(SelectedDifficultyProperty); }
            set { SetValue(SelectedDifficultyProperty, value); }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem cbi = (ComboBoxItem)cb.SelectedItem;
            SelectedDifficulty = (string)cbi.Content;
        }
    }
}
