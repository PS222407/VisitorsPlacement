using VisitorsPlacement_20_BusinessLogic.Exceptions;
using VisitorsPlacement_20_BusinessLogic.Services;

namespace VisitorsPlacement_20_BusinessLogic.Models;

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
        List<Group> groupsWithChildren = _groups.Where(g => g.GetChildren(_startDate).Any()).OrderBy(g => g.RegistrationDate).ToList();

        int columnNumber = 0;
        string sectionLetter = "A";

        bool firstLoop = true;
        foreach (Group group in groupsWithChildren)
        {
            if (!firstLoop)
            {
                sectionLetter = SectionLetterHelper.GetNextAlphabet(sectionLetter);
                columnNumber = 0;
            }

            firstLoop = false;

            foreach (Visitor visitor in new List<Visitor>(group.Visitors.OrderBy(v => v.IsAdult(_startDate))))
            {
                if (columnNumber + 1 > MaxRowLength)
                {
                    sectionLetter = SectionLetterHelper.GetNextAlphabet(sectionLetter);
                    columnNumber = 1;
                }
                else
                {
                    columnNumber++;
                }

                Chair chair = new(1, columnNumber, sectionLetter);
                if (chair.ColumnNumber == MaxRowLength)
                {
                    Visitor? adult = group.GetAdults(_startDate).FirstOrDefault(adult => adult.Chair == null);

                    if (adult == null)
                    {
                        throw new TestException();
                    }

                    adult.AssignChair(chair);
                }
                else
                {
                    if (visitor.Chair == null)
                    {
                        visitor.AssignChair(chair);
                    }
                }
            }

            // foreach (Visitor visitor in visitorsOrderedByChildren)
            // {
            //     Chair chair = new(rowNumber, columnNumber, sectionLetter);
            //     chair.AssignVisitor(visitor);
            //     visitor.AssignChair(chair);
            //     _chairs.Add(chair);
            //
            //     if (columnNumber + 1 > MaxRowLength)
            //     {
            //         columnNumber = 1;
            //
            //         if (rowNumber + 1 > MaxRows)
            //         {
            //             rowNumber = 1;
            //             sectionLetter = SectionLetterHelper.GetNextAlphabet(sectionLetter);
            //         }
            //         else
            //         {
            //             rowNumber++;
            //         }
            //     }
            //     else
            //     {
            //         columnNumber++;
            //     }
            // }
        }

        List<Chair>? a = _chairs;
    }
}