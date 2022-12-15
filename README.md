# VSTA - Very Simple Text Analysis
An interview assignment where I show some design patterns I like in c# development.

## Dependencies
- The solution is built using .NET 6.0 which can be found [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Test
- Tests are executed on every change, 

## Comments
- The solution contains 2 projects.
  - Test project using the xunit template.
  - Core project using the classlib template.
- The solution also contains the container defenition for the API, it can be found in the Docker folder.
- The analytical logic can be replaced by a standardized NLP library with minimal changes if necessary.
- New implementations of the ITextStatistics contract need only know how to fetch data into a ` IEnumerable<string>`. 

