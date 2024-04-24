using Microsoft.AspNetCore.Components;

namespace Interprobet.Layout
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        public string PromotionPage = "/promotion";
        public string LinePage = "https://store.line.me/officialaccount/th";
        public TimeSpan SlowSpeed = TimeSpan.FromSeconds(10.0);
        public bool isMenuShow { get; set; }

        void LoggleMenu()
        {
            if (isMenuShow)
            {
                isMenuShow = false;
            }
            else
            {
                isMenuShow = true;
            }

        }
        string SetBackgroundToZ0(bool isShow)
        {
            if (isMenuShow)
                return "z-0";
            return "z-0";
        }

        string DialogCss(bool isShow)
        {
            if (isMenuShow)
                return "ease-out duration-300 opacity-100 z-50";
            return "ease-in duration-200 hidden z-0";
        }
        string DialogBackground(bool isShow)
        {
            if (isMenuShow)
                return "ease-out duration-300 opacity-100 translate-y-0 sm:scale-10 z-20";
            return "ease-in duration-20 hidden translate-y-4 sm:translate-y-0 sm:scale-95";
        }

        void NavigateTo(string route)
        {
            NavigationManager.NavigateTo(route);
        }
    }
}
