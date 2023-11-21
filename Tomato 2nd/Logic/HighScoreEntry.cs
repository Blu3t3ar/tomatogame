using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato_2nd.Logic
{
    public class HighScoreEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public HighScoreEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }

    public class HighScoreBoard
    {
        private List<HighScoreEntry> highScores = new List<HighScoreEntry>();

        // Method to add a new high score
        public void AddHighScore(string playerName, int score)
        {
            highScores.Add(new HighScoreEntry(playerName, score));
            highScores = highScores.OrderByDescending(h => h.Score).Take(10).ToList(); // Keep top 10 scores
        }

        // Method to display high scores
        public void DisplayHighScores()
        {
            Console.WriteLine("High Scores:");
            foreach (var entry in highScores)
            {
                Console.WriteLine($"{entry.PlayerName} - {entry.Score}");
            }
        }
    }


}
