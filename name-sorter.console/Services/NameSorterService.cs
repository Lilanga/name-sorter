using name_sorter.Interfaces;
using name_sorter.Models;

namespace name_sorter.Services
{
    // Service for sorting a list of PersonName objects, implementing INameSorterService
    public class NameSorterService : INameSorterService
    {
        // Sorts a list of PersonName objects by last name, then by given names
        // This implementation uses LINQ for sorting the names
        public List<PersonName> SortNames(IList<PersonName> names)
        {
            return names
                .OrderBy(n => n.LastName)
                .ThenBy(n => string.Join(" ", n.GivenNames))
                .ToList();
        }
    }
}
