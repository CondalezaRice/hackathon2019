using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{

    public class LessonModel { }
    public class Lesson
    {
        private string lesson_string_;
        private string lesson_name_;
        public string LessonString
        {
            get
            {
                return lesson_string_;
            }

            set
            {
                if (lesson_string_ != value)
                {
                    lesson_string_ = value;
                }
            }
        }

        public string Lesson_name_ { get => lesson_name_; set => lesson_name_ = value; }
    }

    //LessonHistory in progress, it is meant to help store keystrokes for playback purposes 
    public class LessonHistory
    {
        private Lesson lesson_;
        private int mistakes_;
        private List<Keystroke> keystrokes_;

        public Lesson Lesson_ { get => lesson_; set => lesson_ = value; }

        public int Mistakes_ { get => mistakes_; set => mistakes_ = value; }
        public List<Keystroke> Keystrokes_ { get => keystrokes_; set => keystrokes_ = value; }
    }
    public class Keystroke
    {
        private int time_;
        private char character_;

        public int Time_ { get => time_; set => time_ = value; }
        public char Character_ { get => character_; set => character_ = value; }
    }
}

    