using name_sorter.Models;

namespace name_sorter.Interfaces
{
    // Interface for file operations related to reading and writing names
    public interface IFileService
    {
        IList<PersonName> ReadAllLines(string filePath);
        void WriteAllLines(string filePath, IList<PersonName> lines);
    }
}
