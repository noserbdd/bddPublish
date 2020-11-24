using BoDi;
using Driver_AutoTests.PageObjects;

namespace Driver_AutoTests.Factories
{
    class PageFactory : IPageFactory
    {
        private readonly IObjectContainer _objectContainer;

        public PageFactory(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public T GetPage<T>()
            where T : PageBase
        {
            return _objectContainer.Resolve<T>();
        }
    }
}
