//-----------------------------------------------------------------------
// <copyright file="FieldStatus.cs" company="TelerikAcademy">
// All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Minesweeper.Common
{
    using System;

    /// <summary>
    /// Field status collection.
    /// </summary>
    public enum FieldStatus
    {
        /// <summary>
        /// The field is closed.
        /// </summary>
        Closed,

        /// <summary>
        /// The field is opened.
        /// </summary>
        Opened,

        /// <summary>
        /// The field contains a mine.
        /// </summary>
        IsAMine
    }
}
