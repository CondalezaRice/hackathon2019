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
        String challenge_easy = "Amazon.com, Inc. is an America multinational technology company based in Seattle," +
            "Washington, that focuses on e-commerce, cloud computing, digital streaming, and artificial intelligence." +
            "It is considered one of the Big Four technology companies along with Google, Apple, and Facebook.";

        String challenge_medium = "Microsoft Corporation is an American multinational technology company with headquarters " +
            "in Redmond, Washington. It develops, manufactures, licenses, supports, and sells computer software, consumer " +
            "electronics, personal computers, and related services. Its best known software products are the Microsoft Windows " +
            "line of operating systems, the Microsoft Office suite, and the Internet Explorer and E-dge web browsers. Its flagship " +
            "hardware products are the Xbox video game consoles and the Microsoft Surface lineup of touchscreen personal computers. " +
            "In 2016, it was the world's largest software maker by revenue (currently Alphabet/Google has more revenue). " +
            "The word 'Microsoft' is a portmanteau of 'microcomputer' and 'software'. Microsoft is ranked No. 30 in the 2018 " +
            "Fortune 500 rankings of the largest United States corporations by total revenue.";

        String challenge_hard = "Facebook, Inc. is an American online social media and social networking service company based in " +
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

        GameViewModel gvm = new GameViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = gvm;
        }
    }
}
