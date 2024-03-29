﻿using MKUltra.Model;
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
            try
            {

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

            catch
            {
                Console.WriteLine("Error, out of bounds for input");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (gvm.CurrentLesson == null)
                return;

            try
            {
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
            catch
            {
                Console.WriteLine("Error out of bounds for input");
            }
        }

        private void lessonsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            gvm.CurrentLesson = (Lesson)lb.SelectedItem;
        }

        private void UpdateStatisticsOnCharacterTyped(bool isCharacterCorrect, string lastKey)
        {
            // Console.WriteLine(Environment.CurrentDirectory);
            string Path = Environment.CurrentDirectory;
            Path = Path.Remove(Path.Length-9);
            Path = Path + "fortunate_son.wav";
            Console.WriteLine(Path);

            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(Path);

            if (gvm.SingleGameStatistics.TotalCharactersTyped == 0)
            {
                _isChallengeStarted = true;

                //Start timer
                Task.Run(async () =>
                {
                    while (!gvm.PlayerHasWon && gvm.GameHasStarted)
                    {
                        await Task.Delay(1000);
                        if (!gvm.PlayerHasWon && gvm.GameHasStarted)
                        {
                            gvm.SingleGameStatistics.TotalSecondsPlayed++;
                        }
                    }
                });
            }

            gvm.SingleGameStatistics.TotalCharactersTyped++;
            if (isCharacterCorrect)
            {
                gvm.SingleGameStatistics.CharactersCorrect++;

                if ( lastKey.Equals(Key.Space.ToString() ) || lastKey.Equals(".")) //If character was a space or period then increment total words
                {
                    gvm.SingleGameStatistics.TotalWords++; // do we want to make a serperate counter for punctuation?
                }

                //update combo score
                gvm.SingleGameStatistics.Combo++;

                //combo message
                if (gvm.SingleGameStatistics.Combo > 25)
                {
                    gvm.SingleGameStatistics.Combo_Message = "WOW!! Keep it up!";
                }

                //sound test
                if (gvm.SingleGameStatistics.Combo == 25)
                {
                    System.Media.SoundPlayer soundPlayer2 = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Notify.wav");
                    soundPlayer2.Play();
                }
                if (gvm.SingleGameStatistics.Combo == 50)
                {
                    //do something else cool
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    soundPlayer.Play();
                }
            }
            else
            {
                gvm.SingleGameStatistics.CharactersIncorrect++;
                //set combo score back to 0
                gvm.SingleGameStatistics.Combo = 0;
                //setting combo message back to nothing because if you lost the combo you are nothing
                gvm.SingleGameStatistics.Combo_Message = " ";
                //play the you messed up noise
                System.Media.SystemSounds.Hand.Play();
                soundPlayer.Stop();
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

            //Update words per minute
            gvm.SingleGameStatistics.WordsPerMinute = Convert.ToInt32(Math.Floor(gvm.SingleGameStatistics.TotalWords / (gvm.SingleGameStatistics.TotalSecondsPlayed/60)));
            
            //End of game cumulative updating
            if (gvm.CurrentLesson.TypingProgress.Length == gvm.CurrentLesson.LessonString.Length)
            {
                gvm.PlayerHasWon = true;
                _isChallengeStarted = false;
                // cumulative update stats
                ++gvm.CumulativeStatistics.GamesWon;
                ++gvm.CumulativeStatistics.TotalGamesPlayed;
                gvm.CumulativeStatistics.TotalWords += gvm.SingleGameStatistics.TotalWords;
                gvm.CumulativeStatistics.TotalSecondsPlayed += gvm.SingleGameStatistics.TotalSecondsPlayed;
                gvm.CumulativeStatistics.WordsPerMinute = Convert.ToInt32(Math.Floor(gvm.CumulativeStatistics.TotalWords / (gvm.CumulativeStatistics.TotalSecondsPlayed / 60)));
            }
            else if (gvm.CurrentLesson.TypingProgress.Length == gvm.CurrentLesson.LessonString.Length)
            {
                gvm.PlayerHasWon = false;
                // cumulative update stats
                ++gvm.CumulativeStatistics.GamesLost;
                ++gvm.CumulativeStatistics.TotalGamesPlayed;
            }

        }

        private void StartMenu_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MyMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gvm.UserInputTextBox = UserInputTextBox;
        }
    }
}
