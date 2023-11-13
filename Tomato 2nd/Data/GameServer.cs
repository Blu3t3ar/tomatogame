using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tomato_2nd.Logic;

namespace Tomato_2nd.Data
{
    public class GameServer
    {
        private static string ReadUrl(string urlString)
        {
            try
            {
                using (HttpClient client = new())
                {
                    return  client.GetStringAsync(urlString).Result;
                }
            }
            catch (Exception e)
            {
                // TODO: Add proper exception handling.
                Console.WriteLine("An Error occurred: " + e.Message);
                throw;
            }
        }
        public Game GetRandomGame()
        {
        
            string tomatoapi = "https://marcconrad.com/uob/tomato/api.php";
            GameJson game = JsonConvert.DeserializeObject<GameJson>( ReadUrl(tomatoapi));
            string imgurl = game.question;
            BitmapImage ing = new BitmapImage(new Uri(imgurl));
            return new Game(ing, game.solution);
        }
    }
    public class GameJson 
    
    {
        public string question { get; set; }
        public int solution { get; set; }
    }

}

