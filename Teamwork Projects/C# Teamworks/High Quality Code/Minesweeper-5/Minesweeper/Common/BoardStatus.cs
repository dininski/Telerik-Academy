//-----------------------------------------------------------------------
// <copyright file="BoardStatus.cs" company="TelerikAcademy">
// All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Minesweeper.Common
{
    using System;

    /// <summary>
    /// Board status after field opening.
    /// </summary>
    public enum BoardStatus
    {
        /// <summary>
        /// Mined filed has been opened.
        /// </summary>
        SteppedOnAMine,

        /// <summary>
        /// The opened field had been already opened.
        /// </summary>
        FieldAlreadyOpened,

        /// <summary>
        /// The field has been successfully opened.
        /// </summary>
        FieldSuccessfullyOpened,

        /// <summary>
        /// The last non-mined field has been successfully opened.
        /// </summary>
        AllFieldsAreOpened
    }
}
