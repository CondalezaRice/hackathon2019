using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
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
