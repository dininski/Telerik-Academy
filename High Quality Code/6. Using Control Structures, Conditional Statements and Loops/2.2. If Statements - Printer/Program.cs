namespace IfStatementsPart2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int currentRow = 0;
            int firstRow = 0;
            int lastRow = 0;
            int firstColumn = 0;
            int lastColumn = 0;
            int currentColumn = 0;
            bool canVisitCell = false;
            bool rowIsInRange = firstRow <= currentRow && currentRow <= lastRow;
            bool columnIsInRange = firstColumn <= currentColumn && currentColumn <= lastColumn;
            if (rowIsInRange && columnIsInRange && canVisitCell)
            {
                VisitCell();
            }
        }

        // dummy method
        public static void VisitCell()
        {
        }
    }
}
