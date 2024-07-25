using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopDemoApp.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace UiDesktopDemoApp.ViewModels.Pages
{
    public partial class CardPageViewModel(INavigationService navigationService,
                                           ISnackbarService snackbarService,
                                           IContentDialogService contentDialogService) : ObservableValidator
    {



        [RelayCommand]
        private void OnClickButton(object sender)
        {
            navigationService.Navigate(typeof(DashboardPage));
        }

        [ObservableProperty]
        private IList<string> _options = new ObservableCollection<string>() { "Option1", "Option2", "Option3" };

        [ObservableProperty]
        private string? _selectedOption = "Option1";

        partial void OnSelectedOptionChanged(string? value)
        {
            snackbarService.Show(
            "Achtung",
            $"ComboBox wurde auf die Option '{value}' geändert",
            ControlAppearance.Info,
            new SymbolIcon(SymbolRegular.Info28),
            TimeSpan.FromSeconds(5)
            );
        }


        [ObservableProperty]
        private bool _toggled = false;

        partial void OnToggledChanged(bool value)
        {

            var strValue = value ? "true" : "false";

            snackbarService.Show(
             "Achtung",
             $"Toggle Box wurde geändert auf: {strValue}",
             ControlAppearance.Info,
             new SymbolIcon(SymbolRegular.Info28),
             TimeSpan.FromSeconds(5)
             );
        }
        
    }
}
