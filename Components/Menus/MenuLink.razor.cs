using BlazorAnimation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Interprobet.Components
{
    public partial class MenuLink
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public string IconPath { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public string Route { get; set; }
        public string Background { get; set; }
        public bool IsRouteActive { get; set; }
        public TimeSpan SlowSpeed = TimeSpan.FromSeconds(10.0);
        protected override void OnInitialized()
        {
            UpdateRouteStatus();
            NavigationManager.LocationChanged += HandleLocationChanged;
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            UpdateRouteStatus();
            StateHasChanged();
        }

        private void UpdateRouteStatus()
        {
            IsRouteActive = IsRouteMatched();
            Background = IsRouteActive ? "bg-gradient-to-b from-[#6426b0] to-[#3b1a6a] border-solid border-2 border-purple-600" : "bg-gradient-to-b from-[#363636] to-[#2b2b2b]";
        }

        private bool IsRouteMatched()
        {
            return NavigationManager.Uri.EndsWith(Route, StringComparison.OrdinalIgnoreCase);
        }

        void NavigateTo(string route)
        {
            NavigationManager.NavigateTo(route);
        }
    }
}
