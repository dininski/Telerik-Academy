using System;
using System.Collections.Generic;

namespace Galaxian.Common
{
    class DoubleBufferConsoleRenderer : IRenderer
    {
        private buffer ConsoleBuffer;
        private int visibleRows;
        private int visibleCols;

        public DoubleBufferConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols)
        {
            visibleCols = visibleConsoleCols;
            visibleRows = visibleConsoleRows;
            Console.CursorVisible = false;
            Console.SetWindowSize(visibleConsoleCols + 1, visibleConsoleRows + 3);
            ConsoleBuffer = new buffer(visibleConsoleCols, visibleConsoleRows, visibleConsoleCols, visibleConsoleRows);
            Console.BufferHeight = visibleConsoleRows + 3;
            Console.BufferWidth = visibleConsoleCols + 1;
        }

        public void EnqueueForDrawing(IDrawable obj)
        {

            char[,] objImage = obj.GetBody();
            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);
            int XPos = obj.GetCoordinates().XPosition;
            int YPos = obj.GetCoordinates().YPosition;

            if (obj is GameObject)
            {
                GameObject thisObj = obj as GameObject;

                ConsoleColor color = thisObj.Color;

                for (int row = 0; row < objImage.GetLength(0); row++)
                {
                    for (int col = 0; col < objImage.GetLength(1); col++)
                    {
                        if (YPos + row < visibleRows && YPos >= 0)
                        {
                            ConsoleBuffer.Draw(objImage[row, col].ToString(), XPos + col, YPos + row, (short)thisObj.Color);
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < objImage.GetLength(0); row++)
                {
                    for (int col = 0; col < objImage.GetLength(1); col++)
                    {
                        if (YPos + row < visibleRows && YPos >= 0)
                        {
                            ConsoleBuffer.Draw(objImage[row, col].ToString(), XPos + row, YPos, 4);
                        }
                    }
                }
            }

        }

        public void RenderAll()
        {
            ConsoleBuffer.Print();
            ClearQueue();
        }

        public void ClearQueue()
        {
            ConsoleBuffer.Clear();
        }
    }
}
