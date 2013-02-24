using System;
using MobilePhone.Common;

namespace MobilePhone.Common
{
    public class Display
    {
        public int? numberOfColors;
        public int? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.numberOfColors = value;
            }
        }

        //adding another class DisplaySize, which will 
        //hold the width and height of the display

        public DisplaySize Size { get; set; }

        //constructor initializing all the properties
        public Display(int? numberOfColors, DisplaySize size)
        {
            this.NumberOfColors = numberOfColors;
            this.Size = new DisplaySize(size.Height, size.Width);
        }

        //the default DisplaySize constructor creates 320x240, if 
        //not explicitly specified otherwise
        //and the default number of colors is 32K.
        //All the possible constructors:

        public Display()
            : this(null, new DisplaySize())
        {
        }

        public Display(Display displayToCopy)
            : this(displayToCopy.NumberOfColors, displayToCopy.Size)
        {
        }

        public Display(int numberOfColors)
            : this(numberOfColors, new DisplaySize())
        {
        }

        public Display(DisplaySize size)
            : this(null, size)
        {
        }

        override public string ToString()
        {
            return String.Format("Number of colors: {0}\nDisplay size: {1}", NumberOfColors, Size);
        }

    }
}
