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
using Tomato_2nd.Logic;

namespace Tomato_2nd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameEngine engine;
        public MainWindow()
        {
            InitializeComponent();

           engine = new GameEngine("Playername");
            var img = engine.NextGame();
            ImageBrush ib = new ImageBrush(img);
            ib.ImageSource = img;
            tomato.Background=ib;

            label.Content = "What is the value of the tomato?";
            score.Content = "score: " + engine.Score;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button senderButton = (sender as Button);
            string buttonContentOfPressed = senderButton.Content.ToString();
            int numPressed = int.Parse(buttonContentOfPressed);

            bool result = engine.CheckSolution(numPressed);
            if (result)
            {
                label.Content = "Good result";
                score.Content = "score: " + engine.Score;
                var img = engine.NextGame();
                ImageBrush ib = new ImageBrush(img);
                ib.ImageSource = img;
                tomato.Background = ib;
            }
            else
            {
                label.Content = "Try again";
            }


        }
    }
}
