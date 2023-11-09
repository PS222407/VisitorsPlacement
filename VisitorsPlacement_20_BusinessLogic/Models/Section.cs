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

    public Chair? GetNextChair()
    {
        int rowNumber = 1;
        
        Chair? nextChair = GetNextColumnChair(rowNumber);
        while (nextChair == null)
        {
            rowNumber++;
            if (rowNumber > MaxRows)
            {
                break;
            }
            nextChair = GetNextColumnChair(rowNumber);
        }
        
        return nextChair;
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
    public string DisplayInAscii()
    {
        string result = "";

        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                Chair chair = _chairs.First(c => c.RowNumber == i + 1 && c.ColumnNumber == j + 1);
                result += chair.Visitor == null ? "XX " : chair.Visitor.IsAdult() ? $"{chair.Visitor.GetGroupNumber()}A " : $"{chair.Visitor.GetGroupNumber()}C ";
            }
            result += "\n ";
        }

        return result;
    }

    public bool TryPlaceGroup(Group group)
    {
        if (group.GetChildren().Count > 0)
        {
            // als section vol is of niet op rij 1 is of er maar 1 stoel vrij is in rij 1 return foutloos maar zonder te plaatsen
            Chair? chair = GetNextChair();
            if (chair == null || chair.RowNumber != 1 || IsLastChairInRow(chair))
            {
                return true;
            }

            foreach (Visitor child in group.GetChildren())
            {
                if (chair == null)
                {
                    return false;
                }

                if (!IsLastChairInRow(chair) && chair.RowNumber == 1)
                {
                    child.AssignChair(chair);
                    chair = GetNextChair();
                }
                else
                {
                    Visitor? adult = group.GetAdults().FirstOrDefault(a => !a.IsAssignedToChair());
                    if (adult == null)
                    {
                        return false;
                    }
                    
                    adult.AssignChair(chair);
                    
                    break;
                }
            }

            foreach (Visitor adult in group.GetAdults().Where(a => !a.IsAssignedToChair()))
            {
                
            }
        }
    }

    public bool IsLastChairInRow(Chair chair)
    {
        return chair.ColumnNumber == NumberOfColumns;
    }
}