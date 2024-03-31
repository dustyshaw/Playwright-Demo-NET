using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class RecordedTests : PageTest
{
    [Test]
    public async Task TestThatIHaveRecorded()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc/#/active");

        // TODO use codegen to record a new test.
    }
}
