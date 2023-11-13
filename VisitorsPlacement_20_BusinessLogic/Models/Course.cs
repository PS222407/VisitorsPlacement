namespace VisitorsPlacement_20_BusinessLogic.Models;

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

        group.SetVisitorsAge(_startDate);
        
        if (!group.IsValid()) return false;
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
        List<Group> groups = _groups.OrderBy(g => g.RegistrationDate).ToList();
        
        foreach (Group group in groups)
        {
            foreach (Section section in _sections)
            {
                if (section.TryPlaceGroup(group))
                {
                    break;
                }
            }
        }

        foreach (Section section in _sections)
        {
            section.PlaceAdultsFromBuffer();
        }
    }
}