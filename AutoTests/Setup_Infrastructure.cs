using BoDi;
using Driver_AutoTests.Factories;

namespace Driver_AutoTests.Specflow
{
    public static class Setup_Infrastructure

    {
        public static void Configure(IObjectContainer objectContainer)
        {
            objectContainer.RegisterTypeAs<PageFactory, IPageFactory>();
        }
    }
}
