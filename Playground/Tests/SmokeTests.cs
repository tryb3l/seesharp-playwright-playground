using Playground.Base;

namespace Playground.Tests;

[TestFixture]
public class SmokeTests : BaseTest
{
    [Test]
    [Category("NotSignedIn")]
    public async Task SmokeTest_OpenLoginPage_Succesfull()
    {
        await NavigationService.GoToLoginPageAsync();
        var title = await Page.TitleAsync();
        Equals("Sign In", title);
    }
}
