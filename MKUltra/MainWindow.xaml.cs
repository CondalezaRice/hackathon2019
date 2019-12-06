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

        private void UpdateLessonProgress()
        {
            gvm.CurrentLesson.CurrentIndex++;
            gvm.CurrentLesson.TypingProgress = gvm.CurrentLesson.LessonString.Substring(0, gvm.CurrentLesson.CurrentIndex);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (gvm.CurrentLesson == null)
                return;

            if (e.Key == Key.Space && gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() == " ")
            {
                gvm.CurrentLesson.TypingHistory += " ";
                UpdateLessonProgress();
            }
            else if (e.Key != Key.Space && gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() == " ")
            {
                if (e.Key.ToString().Length == 1)
                {
                    if (Char.IsLetterOrDigit(e.Key.ToString()[0]) || Char.IsPunctuation(e.Key.ToString()[0]))
                    {
                        gvm.CurrentLesson.TypingHistory += e.Key.ToString()[0];
                    }
                }
                //Incorrect character
                e.Handled = true;
            }
            else if (e.Key == Key.Space && gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() != " ")
            {
                gvm.CurrentLesson.TypingHistory += " ";
                //Incorrect character
                e.Handled = true;
            }
            else if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                //Incorrect character
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (gvm.CurrentLesson == null)
                return;

            Console.WriteLine($"currentLessonChar: {gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex]}\ncurrentUserChar: {e.Text}\nequals? : {gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() == e.Text}");

            gvm.CurrentLesson.TypingHistory += e.Text;

            if (gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() == e.Text)
            {
                UpdateLessonProgress();
            }
            else
            {
                e.Handled = true;
            }

            Console.WriteLine("Typing History: " + gvm.CurrentLesson.TypingHistory);
            Console.WriteLine("Typing Progress: " + gvm.CurrentLesson.TypingProgress);
        }

        private void lessonsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            gvm.CurrentLesson = (Lesson)lb.SelectedItem;
        }
    }
}
