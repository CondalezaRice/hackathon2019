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
        private bool _isChallengeStarted = false;
        private bool _isChallengeEnded = false;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = gvm;
        }

        private void UpdateLessonProgress(string lastKey)
        {
            gvm.CurrentLesson.CurrentIndex++;
            gvm.CurrentLesson.TypingProgress = gvm.CurrentLesson.LessonString.Substring(0, gvm.CurrentLesson.CurrentIndex);
            UpdateStatisticsOnCharacterTyped(true, lastKey);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (gvm.CurrentLesson == null)
                return;

            // good space
            if (e.Key == Key.Space && gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() == " ")
            {
                gvm.CurrentLesson.TypingHistory += " ";
                UpdateLessonProgress(e.Key.ToString());
                // Call validation stuff (gmv.statistics_handler.whatever())
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
                UpdateStatisticsOnCharacterTyped(false, e.Key.ToString());
                e.Handled = true;
            }
            else if (e.Key == Key.Space && gvm.CurrentLesson.LessonString[gvm.CurrentLesson.CurrentIndex].ToString() != " ")
            {
                gvm.CurrentLesson.TypingHistory += " ";
                UpdateStatisticsOnCharacterTyped(false, e.Key.ToString());
                e.Handled = true;
            }
            else if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                UpdateStatisticsOnCharacterTyped(false, e.Key.ToString());
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
                UpdateLessonProgress(e.Text);
            }
            else
            {
                UpdateStatisticsOnCharacterTyped(false, e.Text);
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

        private void UpdateStatisticsOnCharacterTyped(bool isCharacterCorrect, string lastKey)
        {
            if (!_isChallengeStarted && !_isChallengeEnded)
            {
                _isChallengeStarted = true;

                //Start timer
                Task.Run(async () =>
                {
                    while (!gvm.PlayerHasWon)
                    {
                        await Task.Delay(1000);
                        gvm.SingleGameStatistics.TotalSecondsPlayed++;
                    }
                });
            }

            gvm.SingleGameStatistics.TotalCharactersTyped++;
            if (isCharacterCorrect)
            {
                gvm.SingleGameStatistics.CharactersCorrect++;

                if ( lastKey.Equals(Key.Space.ToString() ) || lastKey.Equals(Key.OemPeriod.ToString() ) ) //If character was a space, comma or period then increment total words
                {
                    gvm.SingleGameStatistics.TotalWords++; // do we want to make a serperate counter for punctuation?
                }

                //update combo score
                gvm.SingleGameStatistics.Combo++;
            }
            else
            {
                gvm.SingleGameStatistics.CharactersIncorrect++;
                //set combo score back to 0
                gvm.SingleGameStatistics.Combo = 0;
            }

            // update percentage correct
            double new_percentage_correct = ((gvm.SingleGameStatistics.CharactersIncorrect / gvm.SingleGameStatistics.CharactersCorrect) - 1) * -100;
            if (new_percentage_correct >= 0)
            {
                gvm.SingleGameStatistics.Percentage_correct = new_percentage_correct;
            }
            else
            {
                gvm.SingleGameStatistics.Percentage_correct = 0;
            }
            

            if (gvm.CurrentLesson.TypingProgress.Length == gvm.CurrentLesson.LessonString.Length)
            {
                gvm.PlayerHasWon = true;
            }

        }

        private void StartMenu_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
