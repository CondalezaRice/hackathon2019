using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    public enum LessonDifficulty {Easy, Medium, Hard};
    public class LessonModel { }
    public class Lesson
    {
        private string lesson_string_;
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
        public LessonDifficulty Difficulty { get; set; }
        public string LessonName { get; set; }
        public int CurrentIndex { get; set; }
        public Lesson(string content)
        {
            LessonString = content;
        }
        public Lesson(string content, string name, LessonDifficulty ld)
        {
            LessonString = content;
            Difficulty = ld;
            LessonName = name;
        }
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

    