using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tomato_2nd.Logic
{
    
    /// Class of the game. 
    ///
    public class Game

    {
        private BitmapImage image;
        private int solution;

        public int Solution { get => solution; set => solution = value; }
        public BitmapImage Image { get => image; set => image = value; }

        public Game(BitmapImage image, int solution)
        {
            this.image = image;
            this.solution = solution;
        }
    }
}
