using name_sorter.Models;
using name_sorter.Services;

namespace name_sorter.tests
{
    // Unit tests for NameSorterService implementation
    public class NameSorterServiceTest
    {
        // Here we are testing the sorting logic, assuming it sorts by last name, then by given names
        [Fact]
        public void SortNames_ShouldSortByLastName_ThenGivenNames()
        {
            var names = new List<PersonName>
        {
            new PersonName("Janet Parsons"),
            new PersonName("Adonis Julius Archer"),
            new PersonName("Marin Alvarez"),
            new PersonName("Hunter Uriah Mathew Clarke"),
        };

            var service = new NameSorterService();
            var result = service.SortNames(names);

            // Assert that the names are sorted correctly
            Assert.Equal("Marin Alvarez", result[0].FullName);
            Assert.Equal("Adonis Julius Archer", result[1].FullName);
            Assert.Equal("Hunter Uriah Mathew Clarke", result[2].FullName);
            Assert.Equal("Janet Parsons", result[3].FullName);

            // list should contain the same number of names after sorting
            Assert.Equal(names.Count, result.Count);
        }
    }
}
