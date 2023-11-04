﻿namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Course
{
    private readonly DateTime _startDate;
    
    private List<Group> _groups = new();

    private List<Section> _sections;

    public Course(DateTime startDate, List<Section> sections)
    {
        _startDate = startDate;
        _sections = sections;
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

        foreach (Section section in _sections)
        {
            foreach (Group group in groupsWithChildren)
            {
                bool fits = group.FitsInSection(_startDate, section);
            }
        }

        // foreach (Group group in groupsWithChildren)
        // {
        //     List<List<Visitor>> subGroups = DivideInSubGroups(group);
        //
        //     foreach (List<Visitor> subGroup in subGroups)
        //     {
        //         foreach (Visitor visitor in subGroup)
        //         {
        //             // Chair? chair = GetNextColumnChair(sectionLetter);
        //             // if (chair == null)
        //             // {
        //             //     chair = GetNextRowChair(sectionLetter);
        //             // }
        //
        //             // if (group.GetChildren(_startDate).Any(c => c.Chair != null));
        //             // {
        //             //     
        //             // }
        //         
        //             if (!visitor.IsAdult(_startDate) && chair.RowNumber == 1 && chair.ColumnNumber != MaxColumns - 1)
        //             {
        //                 visitor.AssignChair(chair);
        //             }
        //             else if (visitor.IsAdult(_startDate))
        //             {
        //                 visitor.AssignChair(chair);
        //             }
        //         }
        //     }
        // }

        var ab = 23;
    }

    public List<List<Visitor>> DivideInSubGroups(Group group)
    {
        List<List<Visitor>> subGroups = group.GetChildren(_startDate).Chunk(Group.MaxChildrenPerAdult).Select(chunk => chunk.ToList()).ToList();
        List<Visitor> adultsWatchingChildren = group.GetAdults(_startDate).Take(group.GetNumberOfAdultsWatchingChildren(_startDate)).ToList();
            
        foreach (List<Visitor> subGroup in subGroups)
        {
            Visitor adult = adultsWatchingChildren.First();
            subGroup.Add(adult);
            adultsWatchingChildren.Remove(adult);
        }

        return subGroups;
    }
}