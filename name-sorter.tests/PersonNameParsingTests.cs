using name_sorter.Models;

namespace name_sorter.tests
{
    public class PersonNameParsingTests
    {
        [Theory]
        [InlineData("Madonna")]                // sinegle part names are not allowed
        [InlineData("Aby Bosco Jhon Doe Elly")]              // five part names are not allowed
        [InlineData("   ")]                    // whitespace only is not allowed
        public void invalidNamesInputsCheck(string input)
        {
            Assert.Throws<ArgumentException>(() => new PersonName(input));
        }

        [Theory]
        [InlineData("Nicolas Cage", "Cage", new[] { "Nicolas" })]                          // required minimum 2 parts
        [InlineData("Adonis Julius Ceasor", "Ceasor", new[] { "Adonis", "Julius" })]         // can handle 3 parts
        [InlineData("Hunter Uriah Mathew Clarke", "Clarke", new[] { "Hunter", "Uriah", "Mathew" })] // maximum is four parts names
        public void validNamesInputCheck(string input, string expectedLast, string[] expectedGiven)
        {
            var p = new PersonName(input);
            Assert.Equal(expectedLast, p.LastName);
            Assert.Equal(expectedGiven, p.GivenNames);
            Assert.Equal(input.Trim(), p.FullName);
        }
    }
}