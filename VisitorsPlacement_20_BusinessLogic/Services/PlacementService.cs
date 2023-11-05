using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_20_BusinessLogic.Services;

public class PlacementService
{
    // public void Place()
    // {
    //     List<Section> sections = new();
    //     Course course = new(DateTime.Now, sections);
    //     List<Group> groupsOrderedByRegisterDate = new();
    //     
    //     // Filter groups by course capacity based on registration date
    //     List<Group> groupsWhoNeedToBePlaced = new();
    //     foreach (Group group in groupsOrderedByRegisterDate)
    //     {
    //         if (group.Visitors.Count + groupsWhoNeedToBePlaced.Sum(g => g.Visitors.Count) > course.GetCapacity())
    //         {
    //             break;
    //         }
    //         
    //         groupsWhoNeedToBePlaced.Add(group);
    //     }
    //     
    //     // Place groups in sections
    //     List<Group> groupsOrderedByChildrenFirst = groupsWhoNeedToBePlaced; // TODO: order by children first
    //     foreach (Group group in groupsWhoNeedToBePlaced)
    //     {
    //         foreach (Section section in sections)
    //         {
    //             if (group.FitsFullyInSection())
    //             {
    //                 group.PlaceInSection(section);
    //                 break;
    //             }
    //         }
    //     }
    // }
}