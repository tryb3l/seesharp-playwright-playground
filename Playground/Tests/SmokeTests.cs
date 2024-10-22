using Playground.Pages;

namespace Playground.Tests;

[TestFixture]
public class SmokeTests : PageTest
{
    [Test]
    [Category("NotSignedIn")]
    public async Task SmokeTest_OpenLoginPage_Succesfull()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.NavigateAsync();
        var title = await Page.TitleAsync();
        Equals("Sign In", title);
    }
}
