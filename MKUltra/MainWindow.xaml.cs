using MKUltra.Model;
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

namespace MKUltra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameViewModel gvm = new GameViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = gvm;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Lesson l = (Lesson)gvm.LessonsCollectionView.CurrentItem;
            if ((char)e.Text[0] != l.LessonString[l.CurrentIndex])
            {
                e.Handled = true;
            }
            else
            {
                l.CurrentIndex++;
                if (l.CurrentIndex == l.LessonString.Length)
                {
                    youWonText.Visibility = Visibility.Visible;
                }
            }
            
        }
    }
}
