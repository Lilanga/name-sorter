namespace name_sorter.Models
{
    // Model representing a person's name, with properties for full name, last name, and given names
    // We are assuming names are space-separated and the last part is the last name
    public class PersonName
    {
        public string FullName { get; }
        public string LastName { get; }
        public string[] GivenNames { get; }

        public PersonName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(fullName));
            }

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(fullName));

            FullName = fullName.Trim();
            var parts = FullName
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // we are checking for a minimum of 2 parts (given name + last name) and a maximum of 4 parts (3 given names + last name) rule here
            if (parts.Length < 2)
                throw new ArgumentException($"Invalid name '{FullName}': must contain at least a given name and a last name (min 2 parts).");
            if (parts.Length > 4)
                throw new ArgumentException($"Invalid name '{FullName}': cannot contain more than 3 given names + 1 last name (max 4 parts).");

            LastName = parts.Last();
            GivenNames = parts.Take(parts.Length - 1).ToArray();
        }

        // Override ToString for easy display of the full name
        public override string ToString() => FullName;
    }
}
