namespace MinesweeperUnitTests.MockClasses
{
    using Minesweeper.InputMethods;

    public class MockInputMethod : IInputMethod
    {
        private string mockInput;

        public void SetInput(string mockInput)
        {
            this.mockInput = mockInput;
        }

        public string GetUserInput()
        {
            return this.mockInput;
        }
    }
}
