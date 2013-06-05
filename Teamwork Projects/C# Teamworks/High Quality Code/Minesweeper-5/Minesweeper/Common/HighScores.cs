namespace Minesweeper.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A high scores class, that scores information about the top scores.
    /// </summary>
    public class HighScores
    {
        /// <summary>
        /// A list, containing the top players.
        /// </summary>
        private readonly List<Player> topPlayers;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScores" /> class.
        /// </summary>
        /// <param name="maxTopPlayers">The maximum amount of top players.</param>
        public HighScores(int maxTopPlayers)
        {
            this.topPlayers = new List<Player>();
            this.topPlayers.Capacity = maxTopPlayers;
        }

        /// <summary>
        /// Determines whether a score is among the top scores.
        /// </summary>
        /// <param name="score">The score.</param>
        /// <returns>True if the score is one of the top scores.</returns>
        public bool IsHighScore(int score)
        {
            if (this.topPlayers.Capacity > this.topPlayers.Count)
            {
                return true;
            }

            if (score > this.topPlayers.Min().Score)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a top score.
        /// </summary>
        /// <param name="player">The player that achieved the score.</param>
        public void AddTopScore(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("The player cannot be null");
            }

            if (this.topPlayers.Capacity > this.topPlayers.Count)
            {
                this.topPlayers.Add(player);
                this.topPlayers.Sort();
            }
            else
            {
                this.topPlayers.RemoveAt(this.topPlayers.Capacity - 1);
                this.topPlayers.Add(player);
                this.topPlayers.Sort();
            }
        }

        /// <summary>
        /// Displays the top scores.
        /// </summary>
        /// <returns>The top scores as a string.</returns>
        public string GetTopScores()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.topPlayers.Count; i++)
            {
                sb.AppendLine(string.Format("{0}. {1}", i + 1, this.topPlayers[i]));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Processes the score by adding it to the top scores if necessary.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="score">The player score.</param>
        public void ProcessScore(string name, int score)
        {
            if (score < 0)
            {
                throw new ArgumentException("The player score cannot be negative");
            }

            if (this.IsHighScore(score))
            {
                Player player = new Player(name, score);
                this.AddTopScore(player);
            }
        }
    }
}
