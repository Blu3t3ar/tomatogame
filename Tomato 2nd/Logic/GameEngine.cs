using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Tomato_2nd.Data;

namespace Tomato_2nd.Logic
{
    /// <summary>
    /// Main class where the games are coming from.
    /// </summary>
    public class GameEngine
    {
        private string Playername;
        private int score = 0;
        private GameServer theGames = new GameServer();
        private Game? current;

        public int Score { get => score; set => score = value; }

        
        /// Each player has their own game engine.
       
        public GameEngine(string player)
        {
            Playername = player;
        }

        
        /// Retrieves a game. 
       
        public BitmapImage NextGame()
        {
            current = theGames.GetRandomGame();
            
            return current.Image;
        }

       
        /// Checks if the parameter i is a solution to the game URL. If so, score is increased by one.
    
        public bool CheckSolution(int i)
        {
            if (i == current.Solution)
            {
                Score++;
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}