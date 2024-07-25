﻿using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace UiDesktopDemoApp.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "WPF UI - UiDesktopDemoApp";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Data",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Input",
                Icon = new SymbolIcon {Symbol = SymbolRegular.CheckboxChecked24 },
                TargetPageType = typeof(Views.Pages.InputPage)
            },
            new NavigationViewItem()
            {
                Content = "Validate Input",
                Icon = new SymbolIcon {Symbol = SymbolRegular.ClipboardCheckmark24 },
                TargetPageType = typeof(Views.Pages.ValidateInputPage)
            },
            new NavigationViewItem()
            {
                Content = "Card Examples",
                Icon = new SymbolIcon {Symbol = SymbolRegular.ContactCard24},
                TargetPageType= typeof(Views.Pages.CardPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
