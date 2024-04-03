# Playwright Testing in .NET
[Playwright Documentation](https://playwright.dev/dotnet/)

# Steps
1. [Step 1: Set up Project](#Step-1-Set-up-Project)
      - [If you don't have powershell...](#If-you-don't-have-powershell...)
2. [Step 2: Add your First Test](#Step-2-Add-your-First-Test)
3. [Step 3: Run your tests](#Step-3-Run-your-tests)
4. [Step 4: Record a new test](#Step-4-Record-a-new-test)

## Step 1 Set up Project
Create a new project:
```powershell
dotnet new nunit -n PlaywrightTests
cd PlaywrightTests
```
Add the NUnit Package:
```
dotnet add package Microsoft.Playwright.NUnit
```
Build the project to generate the playwright.ps1 script:
```
dotnet build
```
Install Playwright:
```
pwsh bin/Debug/net8.0/playwright.ps1 install
```

### If you don't have powershell...
```
winget search Microsoft.PowerShell
```
```
winget install --id Microsoft.Powershell --source winget
winget install --id Microsoft.Powershell.Preview --source winget
```

## Step 2 Add your First Test
Replace the contents of UnitTest1 with the following:
```
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }
}
```

## Step 3 Run your tests
Using `dotnet test` will automatically run your tests in `headless` mode, meaning the GUI will not appear. To run your tests not in `headless` mode, run the following: 
```
$env:PWDEBUG=1
dotnet test
```

## Step 4 Record a new test
```
pwsh bin/Debug/net8.0/playwright.ps1 codegen demo.playwright.dev/todomvc
```
The first part tells Playwright to record a new test using codegen. You then pass in a URL that you want to test.
When recording a new test, select `NUnit` from the drop down menu and copy the generated code into a new file. Make sure the namespace and the Class name are correct in your new test.
