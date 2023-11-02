# specflow-playwright


## Getting started
1. Clone repo https://github.com/camillelouiegit/specflow-playwright-bdd.git
2. Install Visual Studio
3. Install Specflow for Visual Studio extension
4. Install Playwright extension Tools > NuGet Package Manager > Manage NuGet Packages for Solution
5. Open cli and navigate to project folder structure
6. Install the necessary Playwright dependencies:
```
dotnet add package Microsoft.Playwright.NUnit
dotnet build .\specflow-playwright.sln
pwsh bin/Debug/netX/playwright.ps1 install

```

## Run Test
6. 
```
dotnet test .\specflow-playwright.sln

```