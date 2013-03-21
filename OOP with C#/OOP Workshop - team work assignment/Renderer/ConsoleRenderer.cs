using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    public class ConsoleRenderer : IRenderer
    {
        int renderContextMatrixRows;
        int renderContextMatrixCols;
        char[,] renderContextMatrix;

        public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols)
        {
            Console.SetWindowSize(visibleConsoleCols + 1, visibleConsoleRows + 3);
            
            Console.BufferHeight = visibleConsoleRows + 3;
            Console.BufferWidth = visibleConsoleCols + 1;

            renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

            this.renderContextMatrixRows = renderContextMatrix.GetLength(0);
            this.renderContextMatrixCols = renderContextMatrix.GetLength(1);

            this.ClearQueue();
        }

        public void EnqueueForDrawing(IDrawable obj)
        {
            char[,] objImage = obj.GetBody();

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            Coordinates objTopLeft = obj.GetCoordinates();

            int lastRow = Math.Min(objTopLeft.YPosition + imageRows, this.renderContextMatrixRows);
            int lastCol = Math.Min(objTopLeft.XPosition + imageCols, this.renderContextMatrixCols);

            for (int row = obj.GetCoordinates().YPosition; row < lastRow; row++)
            {
                for (int col = obj.GetCoordinates().XPosition; col < lastCol; col++)
                {
                    if (row >= 0 && row < renderContextMatrixRows &&
                        col >= 0 && col < renderContextMatrixCols)
                    {
                        renderContextMatrix[row, col] = objImage[row - obj.GetCoordinates().YPosition, col - obj.GetCoordinates().XPosition];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    scene.Append(this.renderContextMatrix[row, col]);
                }

                scene.Append(Environment.NewLine);
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearQueue()
        {
            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    this.renderContextMatrix[row, col] = ' ';
                }
            }
        }
    }
}
