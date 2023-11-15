namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Chair
{
    public int RowNumber { get; }

    public int ColumnNumber { get; }

    private readonly string _sectionLetter;

    public Visitor? Visitor { get; private set; }

    public Chair(int rowNumber, int columnNumber, string sectionLetter)
    {
        RowNumber = rowNumber;
        ColumnNumber = columnNumber;
        _sectionLetter = sectionLetter;
    }

    public override string ToString()
    {
        return $"{_sectionLetter}{RowNumber}-{ColumnNumber}";
    }

    public void AssignVisitor(Visitor visitor)
    {
        Visitor = visitor;
    }

    public void RevokeVisitor()
    {
        Visitor = null;
    }
}