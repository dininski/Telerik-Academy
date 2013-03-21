using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxian.Common
{
    public class HighScores
    {
        private static HighScores instance;
        private List<string> top10 = new List<string>();

        public static HighScores Scores
        {
            get
            {
                if (instance == null)
                {
                    instance = new HighScores();
                }
                return instance;
            }
        }

        private HighScores()
        {
            top10.Add("ALF 10 000");
            top10.Add("ALF 9 000");
            top10.Add("ALF 8 000");
            top10.Add("ALF 7 000");
            top10.Add("ALF 6 000");
            top10.Add("ALF 5 000");
            top10.Add("ALF 4 000");
            top10.Add("ALF 3 000");
            top10.Add("ALF 2 000");
            top10.Add("ALF 1 000");
        }

        public List<string> GetTop10()
        {
            return this.top10;
        }

        public void AddScore(string playerScore)
        {
            top10.Sort();
            top10.Reverse();
            int playerScorePosition = Math.Abs(top10.IndexOf(playerScore));
            if (playerScorePosition < 10)
            {
                top10.Insert(playerScorePosition, playerScore);
                top10.RemoveAt(10);
            }
        }
    }
}
