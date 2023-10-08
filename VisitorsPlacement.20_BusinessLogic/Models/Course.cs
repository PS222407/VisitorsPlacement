using VisitorsPlacement._20_BusinessLogic.Services;

namespace VisitorsPlacement._20_BusinessLogic.Models;

public class Course
{
    private const int MaxRows = 3;

    private const int MinRowLength = 3;

    private const int MaxRowLength = 10;

    private readonly DateTime _startDate;

    private List<Chair> _chairs = new();

    private List<Group> _groups = new();

    public Course(DateTime startDate)
    {
        _startDate = startDate;
    }

    public bool TryAddGroup(Group group)
    {
        if (DateTime.Now > _startDate) return false;
        if (!group.IsValid(_startDate)) return false;
        if (!AreUniqueUsers(group)) return false;
        _groups.Add(group);

        return true;
    }

    private bool AreUniqueUsers(Group group)
    {
        List<Group> groups = new(_groups) { group };

        return groups.SelectMany(g => g.Visitors).Select(v => v.Email).Distinct().Count() == groups.SelectMany(g => g.Visitors).Select(v => v.Email).Count();
    }

    public void CalculateVisitorPlacements()
    {
        // TODO: group can have 20 children and 1 adult, this creates an impossible situation because each subgroup also needs to have an adult

        List<Group> groupsOrderedByChildren = _groups.OrderByDescending(g => g.Visitors.Any(v => !v.IsAdult(_startDate))).ToList();

        int rowNumber = 1;
        int columnNumber = 1;
        string sectionLetter = "A";

        foreach (Group group in groupsOrderedByChildren)
        {
            List<Visitor> visitorsOrderedByChildren = group.Visitors.OrderBy(v => v.IsAdult(_startDate)).ToList();
            foreach (Visitor visitor in visitorsOrderedByChildren)
            {
                Chair chair = new(rowNumber, columnNumber, sectionLetter);
                chair.AssignVisitor(visitor);
                visitor.AssignChair(chair);
                _chairs.Add(chair);
                
                if (columnNumber + 1 > MaxRowLength)
                {
                    columnNumber = 1;

                    if (rowNumber + 1 > MaxRows)
                    {
                        rowNumber = 1;
                        sectionLetter = SectionLetterHelper.GetNextAlphabet(sectionLetter);
                    }
                    else
                    {
                        rowNumber++;
                    }
                }
                else
                {
                    columnNumber++;
                }
            }
        }

        var a = _chairs;
    }
}