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

    public List<Visitor> AdultsInBuffer { get; private set; } = new();

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
            if (rowNumber > NumberOfRows)
            {
                break;
            }

            nextChair = GetNextColumnChair(rowNumber);
        }

        return nextChair;
    }

    private Chair? GetNextColumnChair(int rowNumber)
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
        if (TryPlaceChildren(group) && TryPlaceAdults(group))
        {
            return true;
        }

        RemoveGroupFromSection(group);

        return false;
    }

    private void RemoveGroupFromSection(Group group)
    {
        foreach (Visitor visitor in group.Visitors)
        {
            visitor.RevokeChair();

            if (AdultsInBuffer.Contains(visitor))
            {
                AdultsInBuffer.Remove(visitor);
            }
        }
    }

    private bool TryPlaceChildren(Group group)
    {
        foreach (Visitor child in group.GetChildren())
        {
            Chair? chair = GetNextChair();
            if (chair == null || chair.RowNumber != 1 || IsLastAvailableChairInRow(chair))
            {
                return false;
            }

            child.AssignChair(chair);
        }

        return true;
    }

    private bool TryPlaceAdults(Group group)
    {
        bool firstAdultAfterChild = group.GetChildren().Any();
        foreach (Visitor adult in group.GetAdults().Where(a => !a.IsAssignedToChair()))
        {
            Chair? chair = GetNextChair();
            if (chair == null)
            {
                return false;
            }

            if (firstAdultAfterChild)
            {
                adult.AssignChair(chair);
                firstAdultAfterChild = false;
            }
            else
            {
                int availableChairs = _chairs.Count(c => c.Visitor == null);

                if (availableChairs < 1)
                {
                    return false;
                }

                AdultsInBuffer.Add(adult);
            }
        }

        return true;
    }

    private bool IsLastAvailableChairInRow(Chair chair)
    {
        bool isLastAvailableChairInRow = _chairs.Where(c => c.RowNumber == chair.RowNumber && c.Visitor == null).MaxBy(c => c.ColumnNumber)?.ColumnNumber == chair.ColumnNumber;
        Chair lastAvailableChairConsideringBuffer = _chairs[_chairs.Count - AdultsInBuffer.Count - 1];
        bool isLastChairInRowConsideringBuffer = lastAvailableChairConsideringBuffer.RowNumber == chair.RowNumber && lastAvailableChairConsideringBuffer.ColumnNumber == chair.ColumnNumber;

        return isLastAvailableChairInRow || isLastChairInRowConsideringBuffer;
    }

    public void PlaceAdultsFromBuffer()
    {
        foreach (Visitor adult in AdultsInBuffer)
        {
            Chair? chair = GetNextChair();
            if (chair == null)
            {
                break;
            }

            adult.AssignChair(chair);
        }
    }
}