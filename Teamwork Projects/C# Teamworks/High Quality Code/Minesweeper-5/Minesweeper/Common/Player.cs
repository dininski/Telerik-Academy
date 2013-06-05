//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TelerikAcademy">
// All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Minesweeper.Common
{
    using System;

    /// <summary>
    /// Represents a game player.
    /// </summary>
    public class Player : IComparable
    {
        /// <summary>
        /// Player's name.
        /// </summary>
        private string name;

        /// <summary>
        /// Player's score.
        /// </summary>
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">Player's name.</param>
        /// <param name="score">Player's score.</param>
        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <value>The player name.</value>
        public string Name
        {
            get
            { 
                return this.name; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the player must not be null or empty !!!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        /// <value>The player score.</value>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score must not be negative number !!!");
                }

                this.score = value; 
            }
        }

        /// <summary>
        /// Compares two instances of the class <see cref="Player" /> by their scores.
        /// </summary>
        /// <param name="obj">The other player.</param>
        /// <returns>
        /// Returns -1 if this player's scores are bigger than the other player's score,
        /// 1 if this player's scores are smaller than the other player's score or 0 if the
        /// scores are equal.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Player))
            {
                throw new ArgumentException("A Player object is required for comparison.");
            }

            return -1 * this.score.CompareTo(((Player)obj).score);
        }

        /// <summary>
        /// Converts an instance of the class <see cref="Player" /> into a string.
        /// </summary>
        /// <returns>
        /// A string containing player's name and player's score. Example:
        /// Ivan --> 100.
        /// </returns>
        public override string ToString()
        {
            string result = this.name + " --> " + this.score;
            return result;
        }
    }
}
