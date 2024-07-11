using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace UiDesktopDemoApp.ViewModels.Pages
{
    public partial class ValidateInputViewModel (ISnackbarService snackbarService) :  ObservableValidator
    {

        [ObservableProperty]
        [MinLength(10, ErrorMessage = "Vorname muss mindestenz 10 Stellen haben!")]
        private string _firstName = string.Empty;


        [ObservableProperty]
        [Required (ErrorMessage="E-Mail-Adresse ist ein Pfilchtfeld!")]
        [EmailAddress (ErrorMessage ="E-Mail ist keine gültige E-Mail-Adresse")]
        private string? email;


        [ObservableProperty]
        [Range(1,100, ErrorMessage ="Alter muss zwischen 1 und 100 sein!")]
        private int? age;


        [RelayCommand]
        private void SendButton(object param)
        {

            ValidateAllProperties();

            if( HasErrors)
            {
                string message = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));


                snackbarService.Show(
                "Achtung",
                $"Send Wurde mit Fehler gedrückt: {message} " ,
                ControlAppearance.Danger,
                new SymbolIcon(SymbolRegular.Info28),
                TimeSpan.FromSeconds(5)
                );

            } else
            {
                snackbarService.Show(
                "Achtung",
                $"Send Wurde ohne Fehler gedrückt",
                ControlAppearance.Success,
                new SymbolIcon(SymbolRegular.Info28),
                TimeSpan.FromSeconds(5)
                );
            }


            

        }

    }
}
