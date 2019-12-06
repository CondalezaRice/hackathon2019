using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    //This is for you Parker
    public class Text_Handler
    {
        //Make instance of text_handler and call init()
        //Call
        // is word correct
        //  pass in word and lesson words
        //  check if they are equal
        //  if not - return a false bool
        //  else return true
        private int counter;

        /*
        private string word;
        private string lesson_words;

        public string Word { get => word; set => word = value; }
        public string Lesson_words { get => Lesson_words; set => Lesson_words = value; }
        */
        public int Counter { get => Counter; set => Counter = value; }

        public bool check_word(string word, string lesson_words)
        {
            bool ret;
            //for word in split(' ') lesson_words:
            string[] lesson_words_list = lesson_words.Split(' ');
            if (lesson_words_list[counter] == word)
            {
                ret = true;
            }

            else
            {
                Console.WriteLine("This is what didn't match");
                Console.WriteLine(lesson_words_list[counter], word);
                ret = false;
            }

            counter = ++counter;
            return ret;
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
