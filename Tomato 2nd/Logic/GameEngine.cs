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
        private string thePlayer;
        private int counter = 0;
        private int score = 0;
        private GameServer theGames = new GameServer();
        private Game? current;

        public int Score { get => score; set => score = value; }

        /// <summary>
        /// Each player has their own game engine.
        /// </summary>
        /// <param name="player"></param>
        public GameEngine(string player)
        {
            thePlayer = player;
        }

        /// <summary>
        /// Retrieves a game. This basic version only has two games that alternate.
        /// </summary>
        /// <returns></returns>
        public BitmapImage NextGame()
        {
            current = theGames.GetRandomGame();
            
            return current.Image;
        }

        /// <summary>
        /// Checks if the parameter i is a solution to the game URL. If so, score is increased by one.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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