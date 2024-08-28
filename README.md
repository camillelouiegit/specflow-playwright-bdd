# specflow-playwright


## Getting started
1. Install Visual Studio Community https://visualstudio.microsoft.com/downloads/
2. Clone repo https://github.com/camillelouiegit/specflow-playwright-bdd.git
3. Install Specflow for Visual Studio extension (Extensions > Manage Extensions > Install Specflow)
4. Install Playwright extension (Tools > NuGet Package Manager > Manage NuGet Packages for Solution > Install Playwright)
5. Install .NET or dotnet https://dotnet.microsoft.com/en-us/download
6. Install the necessary Playwright and Specflow dependencies:
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
 Run a specific test using @tags
```
dotnet test .\specflow-playwright.sln --filter "TestCategory=ValidLogin"
```

## Generate Report - Livingdocs
7. 
```
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
livingdoc test-assembly bin/Debug/net6.0/SpecflowPlaywright.dll -t bin/Debug/net6.0/TestExecution.json --output Report/
start Report/LivingDoc.html
```