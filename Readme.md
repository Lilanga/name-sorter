# Name Sorter

This is a simple console application to sort list of names by the last name as first priority and then by the given names. Names should be input as text file. 

Sorted list will be printed on the console and output to a text file as well.

## Build

**Preqrequiste**: .NET SDK: .NET 9.0

Check your version with

  ```bash
  dotnet --version
  ```

and install correct .NET SDK

### Usage

You can build the solution with:

```bash
dotnet restore
dotnet build
```

Run tests with

```bash
dotnet test
```

Run the solution with solution code

```bash
dotnet run -- ./unsorted-names-list.txt
```

Or use the build binay in the bin folder

```bash
name-sorter.console.exe unsorted-names-list.txt
```
