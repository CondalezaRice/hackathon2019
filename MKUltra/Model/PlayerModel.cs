using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    //Will move to proper home if time allows
    public class Statistics_Handler
    {

        //Counter is how many words we have in the completed words string. Essentially it is our score before
        //  accounting for any other weirdness that may have been typed in
        private int counter;
        private int score;

        /*
        private string word;
        private string lesson_words;

        public string Word { get => word; set => word = value; }
        public string Lesson_words { get => Lesson_words; set => Lesson_words = value; }
        */
        public int Counter { get => counter; set => counter = value; }
        public int Score { get => score; set => score = value; }

        public Statistics_Handler()
        {
            init();
        }

        //get score
        public int get_score()
        {
            return score;
        }

        //get word count
        public int get_word_count()
        {
            return counter;
        }

        // each time the completed words section adds a space call this
        public void check_word(string word, string lesson_words)
        {
            //for word in split(' ') lesson_words:
            string[] lesson_words_list = lesson_words.Split(' ');
            if (lesson_words_list[counter] == word)
            {
                
            }

            else
            {
                Console.WriteLine("This is what didn't match");
                Console.WriteLine(lesson_words_list[counter], word);
            }

            Counter = ++Counter;
        }

        public void init()
        {
            Counter = 0;
        }

    }

    public class PlayerModel
    {
    }

    public class Player : INotifyPropertyChanged
    {
        private int wins_;
        private int losses_;
        public int CurrentIndex { get; set; }
        private string lesson_current_progress = "";
        private LessonHistory[] lessons_history_;
        private string name_;

        public int Wins_ { get => wins_; set => wins_ = value; }
        public int Losses_ { get => losses_; set => losses_ = value; }
        public string Lesson_current_progress { get => lesson_current_progress; set => lesson_current_progress = value; }
        public LessonHistory[] Lessons_history_ { get => lessons_history_; set => lessons_history_ = value; }
        public string Name_ { get => name_; set => name_ = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
