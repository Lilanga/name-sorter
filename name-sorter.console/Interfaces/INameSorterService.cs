using name_sorter.Models;

namespace name_sorter.Interfaces
{
    // Interface for sorting a list of PersonName objects
    public interface INameSorterService
    {
        List<PersonName> SortNames(IList<PersonName> names);
    }
}
