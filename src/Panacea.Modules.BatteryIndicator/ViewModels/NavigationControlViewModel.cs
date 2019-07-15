using MaterialIcons;
using Panacea.Modules.BatteryIndicator.Views;
using Panacea.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panacea.Modules.BatteryIndicator.ViewModels
{
    [View(typeof(NavigationControl))]
    class NavigationControlViewModel:ViewModelBase
    {
        public NavigationControlViewModel()
        {
            _timer.Interval = 60000;
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            UpdateBattery();
        }

        MaterialIconType _batteryIcon;
        public MaterialIconType BatteryIcon
        {
            get => _batteryIcon;
            set
            {
                _batteryIcon = value;
                OnPropertyChanged();
            }
        }

        Timer _timer = new Timer();
        public override void Activate()
        {
            
            UpdateBattery();
        }

        public override void Deactivate()
        {
            
        }

        void UpdateBattery()
        {
            PowerStatus p = SystemInformation.PowerStatus;

            int a = (int)(p.BatteryLifePercent * 100);
            switch (p.BatteryChargeStatus)
            {
                case BatteryChargeStatus.NoSystemBattery:
                    BatteryIcon = MaterialIconType.ic_battery_charging_full;
                    break;
                case BatteryChargeStatus.Charging:

                    if (a < 20)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_alert;
                    }
                    else if (a < 30)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_20;
                    }
                    else if (a < 40)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_30;
                    }
                    else if (a < 60)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_50;
                    }
                    else if (a < 70)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_60;
                    }
                    else if (a < 90)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_80;
                    }
                    else if (a < 100)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_90;
                    }
                    else
                    {
                        BatteryIcon = MaterialIconType.ic_battery_charging_full;
                    }

                    break;
                default:
                    if (a < 20)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_alert;
                    }
                    else if (a < 30)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_20;
                    }
                    else if (a < 40)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_30;
                    }
                    else if (a < 60)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_50;
                    }
                    else if (a < 70)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_60;
                    }
                    else if (a < 90)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_80;
                    }
                    else if (a < 100)
                    {
                        BatteryIcon = MaterialIconType.ic_battery_90;
                    }
                    else
                    {
                        BatteryIcon = MaterialIconType.ic_battery_full;
                    }
                    break;
            }

        }
    }
}
