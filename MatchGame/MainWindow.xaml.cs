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


namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10).ToString("0.0s");
            //timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";

            }

            
        }

        private void SetUpGame()
        {
            
            //LIst is a collection that stores a set of values in order
            // new List<string> create your list or an instace of a list.
            List<string> animalEmoji = new List<string>()
            {
                "🐙","🐙",
                "🐟","🐟",
                "🐘","🐘",
                "🐳","🐳",
                "🐫","🐫",
                "🐷","🐷",
                "🐫","🐫",
                "🙈","🙈",

            };

            //Random generator
            Random random = new Random();

            //foreach loop to assign emojis to the textboxes
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //By selecting the TextBlock class, give it a name to then access it in the loop

                // create a integer by getting the numbers of all the emojis or list items
                // it then gets a random number from the count and assigns it to index integer.
                // random.Next returns a random integer from the given parameter --> animalEmoji.Count

                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    // get a string or the emoji string code from the list randomly by given index.
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    // use remove at to remove from the specific index of the the animal emoji 
                    // basically is emptying the list as it is displayed on the screen.
                    animalEmoji.RemoveAt(index);
                }
                                          


            }

            // Start the Timer
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;

            //throw new NotImplementedException();
        }

        TextBlock lastTextBlockClicked; // defines that TextBlock can also be accessed with lastTextBlockClicked
        bool findingMatch = false; // Creates a boolean variable called findingMatch to be used for finding if there was a match


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //Initialize a new object using the parameter sender which is an object of TextBlock
            TextBlock textBlock = sender as TextBlock;
            //Logic to find out if the there is a match between the sender and the last textBlock clicked
            //This will in turn be used to show or not show the matching animals
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden; // current textBox as it has been selected
                lastTextBlockClicked = textBlock; // Since it was match the current last animal clicked is the same and as a object
                findingMatch = true; // We are now ready to match to the second animal
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++; // match found, hence increase the matches found
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false; // we have found a match so we need to restart the logic by making findingMatch false.
            }
            else //if it is not the first time clicking the animal or we find a match, we show the visibility of the last animal.
            {
                
                lastTextBlockClicked.Visibility = Visibility.Visible; 
                findingMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
              
            
            if (matchesFound == 8)
            {
                SetUpGame(); // restart the game when finished and is clicked
            }

        }
    }
}

