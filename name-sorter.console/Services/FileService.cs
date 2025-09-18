using name_sorter.Interfaces;
using name_sorter.Models;


namespace name_sorter.Services
{
    // Service for file operations, implementing IFileService to read and write files from the filesystem
    // This implementation of IFileService uses System.IO to handle file operations
    public class FileService : IFileService
    {

        // Reads all lines from a file and converts them to a list of PersonName objects
        // We are expecting file to be a text file with one name per line
        public IList<PersonName> ReadAllLines(string inputFilePath)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(inputFilePath));

            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException($"File not found: {inputFilePath}");

            try
            {
                var lines = File.ReadAllLines(inputFilePath);
                var names = new List<PersonName>();
                int invalidCount = 0;
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    try
                    {
                        var name = new PersonName(line);
                        names.Add(name);
                    }
                    catch (ArgumentException)
                    {
                        invalidCount++;
                        // Warn user about invalid names
                        Console.WriteLine($"Warning: Skipping invalid name '{line}'");
                    }
                    finally
                    {
                        // print a summary if this is the last line and error count is greater than 0
                        if (invalidCount > 0 && names.Count + invalidCount == lines.Length)
                        {
                            Console.WriteLine($"Warning: {invalidCount} invalid names encountered.");
                            Console.WriteLine("-------------------------------------------------------------");
                        }
                    }
                }
                
                return names;
            }
            catch (Exception ex) when (!(ex is FileNotFoundException))
            {
                throw new InvalidOperationException($"Failed to read file: {inputFilePath}", ex);
            }
        }

        // Writes a list of PersonName objects to a file, one name per line
        // If the file already exists, it will be overwritten
        public void WriteAllLines(string filePath, IList<PersonName> personList)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (personList == null)
                throw new ArgumentNullException(nameof(personList));

            try
            {

                File.WriteAllLines(filePath, personList.Select(n => n.FullName));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to write to file: {filePath}", ex);
            }
        }
    }
}
