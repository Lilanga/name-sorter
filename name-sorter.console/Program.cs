using Microsoft.Extensions.DependencyInjection;
using name_sorter.Interfaces;
using name_sorter.Services;
class Program
{
    static void Main(string[] args)
    {

        const string SortedFileName  = "sorted-names-list.txt";

        // Configure services
        var serviceProvider = ConfigureServices();

        // We are expecting a single argument: the input file path
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide path to unsorted names list file as the only argument.");
            Console.WriteLine("Example: name-sorter.console ./unsorted-names-list.txt");
            return;
        }

        var inputPath = args[0];

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Resolve services from the service provider
        var fileService = serviceProvider.GetRequiredService<IFileService>();
        var sorter = serviceProvider.GetRequiredService<INameSorterService>();

        // Read names from the input file, sort them, and write to the output file
        var names = fileService.ReadAllLines(inputPath);
        var sorted = sorter.SortNames(names);
        
        // Print sorted names to the console
        foreach (var name in sorted)
            Console.WriteLine(name);

        fileService.WriteAllLines(SortedFileName, sorted);
    }


    // Configures dependency injection for the application
    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register service implementations
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<INameSorterService, NameSorterService>();

        return services.BuildServiceProvider();
    }

}