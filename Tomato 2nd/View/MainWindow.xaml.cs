using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tomato_2nd.Logic;

namespace Tomato_2nd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameEngine engine;
        
        public MainWindow(string user)
        {
            InitializeComponent();

            engine = new GameEngine("Playername");
            var img = engine.NextGame();
            ImageBrush ib = new ImageBrush(img);
            ib.ImageSource = img;
            tomato.Source=img;
            

            label.Content = "What is the value of the tomato?";
            score.Content = "score: " + engine.Score;
            username.Content = "Welcome: " +user;  // Getting user name from login window

        }

        // Method that is called when a button has been pressed.
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button senderButton = (sender as Button);
            string buttonContentOfPressed = senderButton.Content.ToString();
            int numPressed = int.Parse(buttonContentOfPressed);

            bool result = engine.CheckSolution(numPressed);
            if (result)
            {
                label.Content = "Good Result";
                MessageBox.Show("Good answer :) Next game? ", "Good Result", MessageBoxButton.OK, MessageBoxImage.Question);
                score.Content = "score: " + engine.Score;
                var img = engine.NextGame();
                ImageBrush ib = new ImageBrush(img);
                ib.ImageSource = img;
                tomato.Source = img;
            }
            else
            {
                label.Content = "Try again";
                MessageBox.Show("Wrong answer, try again :) ", "Try Again", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
