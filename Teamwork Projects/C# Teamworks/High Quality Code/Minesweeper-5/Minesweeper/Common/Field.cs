//-----------------------------------------------------------------------
// <copyright file="Field.cs" company="TelerikAcademy">
// All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Minesweeper.Common
{
    using System;

    /// <summary>
    /// Represents one field of the game board.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Holds the sum of all mines positioned in the surrounding fields.
        /// </summary>
        private int value;

        /// <summary>
        /// The status of the field.
        /// </summary>
        private FieldStatus status;

        /// <summary>
        /// Initializes a new instance of the <see cref="Field" /> class.
        /// </summary>
        public Field()
        {
            this.value = 0;
            this.status = FieldStatus.Closed;
        }

        /// <summary>
        /// Gets or sets the sum of all mines positioned in the surrounding fields.
        /// </summary>
        /// <value>The amount of mines in the vicinity.</value>
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException("The number of adjacent mines cannot be less than 0.");
                }

                this.value = value;
            }
        }

        /// <summary>
        /// Gets or sets the status of the field.
        /// </summary>
        /// <value>The status of the field.</value>
        public FieldStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
