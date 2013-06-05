namespace MinesweeperUnitTests.MockClasses
{
    using System.Text;
    using Minesweeper.Common;
    using Minesweeper.Renderers;

    public class MockRenderer : IRenderer
    {
        private readonly StringBuilder mockMessage;
        private readonly StringBuilder mockError;
        private Board mockBoard;

        public MockRenderer()
        {
            this.mockMessage = new StringBuilder();
            this.mockError = new StringBuilder();
        }

        public string GetMessage()
        {
            return this.mockMessage.ToString();
        }

        public string GetError()
        {
            return this.mockError.ToString();
        }

        public Board GetBoard()
        {
            return this.mockBoard;
        }

        public void DrawBoard(Board board)
        {
            this.mockBoard = board;
        }

        public void DisplayMessage(string message)
        {
            this.mockMessage.Append(message);
        }

        public void DisplayError(string error)
        {
            this.mockError.Append(error);
        }
    }
}
