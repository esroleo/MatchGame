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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
                string testString = "test";
                int index = random.Next(animalEmoji.Count);
                // get a string or the emoji string code from the list randomly by given index.
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                // use remove at to remove from the specific index of the the animal emoji 
                // basically is emptying the list as it is displayed on the screen.
                animalEmoji.RemoveAt(index);
            }

            //throw new NotImplementedException();
        }

    }
}

