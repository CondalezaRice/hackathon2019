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
    }

    //LessonHistory in progress, it is meant to help store keystrokes for playback purposes 
    public class LessonHistory
    {
        private Lesson lesson_;
        private int mistakes_;
        //todo: data structure for time to keypress/character

        public Lesson Lesson_ { get => lesson_; set => lesson_ = value; }

        public int Mistakes_ { get => mistakes_; set => mistakes_ = value; }
    }
}

    