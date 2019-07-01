using Panacea.Core;
using Panacea.Modularity;
using Panacea.Modularity.UiManager;
using Panacea.Modules.BatteryIndicator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modules.BatteryIndicator
{
    class BaterryIndicatorPlugin : IPlugin
    {
        private readonly PanaceaServices _core;

        public BaterryIndicatorPlugin(PanaceaServices core)
        {
            _core = core;
        }

        public Task BeginInit()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        NavigationControlViewModel _navButton;
        public Task EndInit()
        {
            if(_core.TryGetUiManager(out IUiManager ui))
            {
                _navButton = new NavigationControlViewModel();
                ui.AddNavigationBarControl(_navButton);
            }
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            if(_navButton != null && _core.TryGetUiManager(out IUiManager ui))
            {
                ui.RemoveNavigationBarControl(_navButton);
                _navButton = null;
            }
            return Task.CompletedTask;
        }
    }
}
