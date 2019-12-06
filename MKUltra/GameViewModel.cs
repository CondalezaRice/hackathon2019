﻿using MKUltra.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MKUltra
{

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }



    class GameViewModel : ViewModelBase
    {
        public string challenge_aerobic = "The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively " +
            "gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start. " +
            "The running speed starts slowly, but gets faster each minute after you hear this signal. *aggressive beep* A single lap should " +
            "be completed each time you hear this sound. ding Remember to run in a straight line, and run as long as possible. " +
            "The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word " +
            "start. On your mark, get ready, start.";

        public string challenge_easy = "Amazon.com, Inc. is an America multinational technology company based in Seattle," +
            "Washington, that focuses on e-commerce, cloud computing, digital streaming, and artificial intelligence." +
            "It is considered one of the Big Four technology companies along with Google, Apple, and Facebook.";

        public string challenge_medium = "Microsoft Corporation is an American multinational technology company with headquarters " +
            "in Redmond, Washington. It develops, manufactures, licenses, supports, and sells computer software, consumer " +
            "electronics, personal computers, and related services. Its best known software products are the Microsoft Windows " +
            "line of operating systems, the Microsoft Office suite, and the Internet Explorer and E-dge web browsers. Its flagship " +
            "hardware products are the Xbox video game consoles and the Microsoft Surface lineup of touchscreen personal computers. " +
            "In 2016, it was the world's largest software maker by revenue (currently Alphabet/Google has more revenue). " +
            "The word 'Microsoft' is a portmanteau of 'microcomputer' and 'software'. Microsoft is ranked No. 30 in the 2018 " +
            "Fortune 500 rankings of the largest United States corporations by total revenue.";

        public string challenge_hard = "Facebook, Inc. is an American online social media and social networking service company based in " +
            "Menlo Park, California. It was founded by Mark Zuckerberg, along with fellow Harvard College students and " +
            "roommates Eduardo Saverin, Andrew McCollum, Dustin Moskovitz and Chris Hughes. It is considered one of the Big Four" +
            "technology companies along with Amazon, Apple, and Google. The founders initially limited the website's membership " +
            "to Harvard students and subsequently Columbia, Stanford, and Yale students. Membership was eventually expanded to " +
            "the remaining Ivy League schools, MIT, and higher education institutions in the Boston area, then various other " +
            "universities, and lastly high school students. Since 2006, anyone who claims to be at least 13 years old has been " +
            "allowed to become a registered user of Facebook, though this may vary depending on local laws. The name comes from " +
            "the face book directories often given to American university students. Facebook held its initial public " +
            "offering (IPO) in February 2012, valuing the company at $104 billion, the largest valuation to date for a " +
            "newly listed public company. Facebook makes most of its revenue from advertisements that appear onscreen and in users' News Feeds.";

        public CollectionViewSource cvs { get; set; }
        public ICollectionView LessonsCollectionView { get; set; }

        private bool playerHasWon;
        public bool PlayerHasWon
        {
            get => playerHasWon;
            set => SetProperty(ref playerHasWon, value);
        }

        private bool gameHasStarted;
        public bool GameHasStarted
        {
            get => gameHasStarted;
            set => SetProperty(ref gameHasStarted, value);
        }

        private bool _isDisplayingStatistics = false;
        public bool IsDisplayingStatistics
        {
            get => _isDisplayingStatistics;
            set => SetProperty(ref _isDisplayingStatistics, value);
        }

        private ICommand togglePlayerHasWon;
        public ICommand TogglePlayerHasWon
        {
            get => togglePlayerHasWon;
            set => SetProperty(ref togglePlayerHasWon, value);
        }

        private ICommand _toggleDisplayStatisticsCommand;
        public ICommand ToggleDisplayStatisticsCommand
        {
            get => _toggleDisplayStatisticsCommand;
            set => SetProperty(ref _toggleDisplayStatisticsCommand, value);
        }

        private ICommand startGame;
        public ICommand StartGame
        {
            get => startGame;
            set => SetProperty(ref startGame, value);
        }

        private ObservableCollection<Lesson> lessonsCollection;
        public ObservableCollection<Lesson> LessonsCollection
        {
            get => lessonsCollection;
            set => SetProperty(ref lessonsCollection, value);
        }

        private ObservableCollection<Player> playersCollection;
        public ObservableCollection<Player> PlayersCollection
        {
            get => playersCollection;
            set => SetProperty(ref playersCollection, value);
        }

        public GameViewModel()
        {
            TogglePlayerHasWon = new DelegateCommand(OnTogglePlayerHasWon, null);
            StartGame = new DelegateCommand(OnStartGame, null);
            ToggleDisplayStatisticsCommand = new DelegateCommand(OnToggleDisplayStatistics, null);

            LessonsCollection = new ObservableCollection<Lesson>();
            cvs = new CollectionViewSource();
            cvs.Source = LessonsCollection;
            LessonsCollectionView = cvs.View;

            LessonsCollection.Add(new Lesson(challenge_aerobic, "Fantastic Fitness", LessonDifficulty.Easy));
            LessonsCollection.Add(new Lesson(challenge_easy, "Amazing Amazon", LessonDifficulty.Easy));
            LessonsCollection.Add(new Lesson(challenge_medium, "Marvelous Microsoft", LessonDifficulty.Medium));
            LessonsCollection.Add(new Lesson(challenge_hard, "Fantastic Facebook", LessonDifficulty.Hard));

        }

        private void OnTogglePlayerHasWon(object o)
        {
            PlayerHasWon = !PlayerHasWon;
        }

        private void OnStartGame(object o)
        {
            GameHasStarted = true;
        }

        private void OnToggleDisplayStatistics (object o)
        {
            IsDisplayingStatistics = !IsDisplayingStatistics;
        }
    }
}
