namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Chair
{
    public int RowNumber { get; private set; }

    public int ColumnNumber { get; private set; }

    public string SectionLetter { get; private set; }

    public Visitor? Visitor { get; private set; }

    public Chair(int rowNumber, int columnNumber, string sectionLetter)
    {
        RowNumber = rowNumber;
        ColumnNumber = columnNumber;
        SectionLetter = sectionLetter;
    }

    public override string ToString()
    {
        return $"{SectionLetter}{RowNumber}-{ColumnNumber}";
    }

    public void AssignVisitor(Visitor visitor)
    {
        Visitor = visitor;
    }
}