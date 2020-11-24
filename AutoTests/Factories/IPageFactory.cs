using Driver_AutoTests.PageObjects;

namespace Driver_AutoTests.Factories
{
    public interface IPageFactory
    {
        T GetPage<T>() where T : PageBase;
    }
}