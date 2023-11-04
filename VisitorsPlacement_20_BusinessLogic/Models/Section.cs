namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Section
{
    private List<Chair> _chairs = new();

    public string Letter { get; private set; }

    public int NumberOfColumns { get; private set; }

    public int NumberOfRows { get; private set; }

    public IReadOnlyList<Chair> Chairs => _chairs;
    
    private const int MaxRows = 3;

    private const int MinRowLength = 3;

    private const int MaxColumns = 10;

    public Section(string letter, int numberOfColumns, int numberOfRows)
    {
        Letter = letter;
        NumberOfColumns = numberOfColumns;
        NumberOfRows = numberOfRows;

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                _chairs.Add(new Chair(i + 1, j + 1, letter));
            }
        }
    }

    public Chair? GetNextColumnChair(int rowNumber)
    {
        Chair? lastOccupiedChairInColumn = _chairs.Where(c => c.RowNumber == rowNumber && c.Visitor != null).MaxBy(c => c.ColumnNumber);
        if (lastOccupiedChairInColumn == null)
        {
            return _chairs.First(c => c.RowNumber == rowNumber); 
        }
    
        int nextColumnIndex = lastOccupiedChairInColumn.ColumnNumber + 1;
        if (nextColumnIndex > NumberOfColumns)
        {
            return null;
        }
        
        return _chairs.First(c => c.RowNumber == rowNumber && c.ColumnNumber == nextColumnIndex);
    }

    // public Chair? GetNextRowChair(string sectionLetter)
    // {
    //     Chair? lastOccupiedChairInRow = _chairs.Where(c => c.SectionLetter == sectionLetter).MaxBy(c => c.RowNumber);
    //     if (lastOccupiedChairInRow == null)
    //     {
    //         return new Chair(1, 1, sectionLetter);
    //     }
    //
    //     int nextRowIndex = lastOccupiedChairInRow.RowNumber + 1;
    //     if (nextRowIndex > MaxRows)
    //     {
    //         return null;
    //     }
    //     
    //     return new Chair(nextRowIndex, lastOccupiedChairInRow.ColumnNumber, sectionLetter);
    // }
}