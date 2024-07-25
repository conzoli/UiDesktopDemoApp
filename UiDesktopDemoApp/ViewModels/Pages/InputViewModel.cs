using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using UiDesktopDemoApp.Models;
using UiDesktopDemoApp.Services;
using UiDesktopDemoApp.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace UiDesktopDemoApp.ViewModels.Pages
{
    public partial class InputViewModel(ISnackbarService snackbarService,
                                        IContentDialogService contentDialogService,
                                        IStringsService stringsService) : ObservableValidator
    {




        [ObservableProperty]
        private string _myTitle = stringsService.GetString("InputPageTitle");

        [ObservableProperty]
        private string _greeter = "Hallo Welt!";


        [ObservableProperty]
        private string? _inputName = String.Empty;


        partial void OnInputNameChanged(string? value)
        {

            if (value == null || value == "" || value.Length <= 2)
            {
                Greeter = "Hallo Welt!";
            }
            else
            {
                Greeter = $"Hallo, {InputName}!";
            }


        }


        [RelayCommand]
        private void OnClickButton(object sender)
        {
            snackbarService.Show(
            "WooooW",
            "Du hast wirklich den Button geklickt!!!!",
            ControlAppearance.Success,
            new SymbolIcon(SymbolRegular.ErrorCircle24),
            TimeSpan.FromSeconds(5)
            );
        }

        [ObservableProperty]
        private bool? _myCheckboxChecked = false;

        partial void OnMyCheckboxCheckedChanged(bool? value)
        {

            var msg = string.Empty;

            switch (value)
            {
                case true:
                    msg = "Checkbox auf 'true' geänder!";
                    break;
                case false:
                    msg = "Checkbox auf 'false' geändert!";
                    break;
            }

            snackbarService.Show(
            "Achtung",
            msg,
            ControlAppearance.Info,
            new SymbolIcon(SymbolRegular.Info28),
            TimeSpan.FromSeconds(5)
            );

        }


        [ObservableProperty]
        private IList<string> _options = new ObservableCollection<string>() { "Option1", "Option2", "Option3" };

        [ObservableProperty]
        private string? _selectedOption = null;

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


        [RelayCommand]
        private void RadioButtonCommand(object Paramter)
        {

            string? strParamter = Paramter as string;


            snackbarService.Show(
            "Achtung",
            $"Radio mit Param '{strParamter}' gewählt",
            ControlAppearance.Success,
            new SymbolIcon(SymbolRegular.Info28),
            TimeSpan.FromSeconds(5)
            );

        }


        [RelayCommand]
        private async Task ShowContentDialogCommand()
        {
            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
            new SimpleContentDialogCreateOptions()
            {
                Title = "Save your work?",
                Content = "Save?",
                PrimaryButtonText = "Save",
                SecondaryButtonText = "Don't Save",
                CloseButtonText = "Cancel",
            }
            );

            if (result == ContentDialogResult.Primary)
            {

                snackbarService.Show(
                    "Achtung",
                    "Antwort war 'Save'",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Info28),
                    TimeSpan.FromSeconds(5)
                );

            }
            else if (result == ContentDialogResult.Secondary)
            {
                snackbarService.Show(
                   "Achtung",
                   "Antwort war 'Don't Save'",
                   ControlAppearance.Success,
                   new SymbolIcon(SymbolRegular.Info28),
                   TimeSpan.FromSeconds(5)
               );
            }
            else
            {
                snackbarService.Show(
                   "Achtung",
                   "Antwort war 'Cancel'",
                   ControlAppearance.Success,
                   new SymbolIcon(SymbolRegular.Info28),
                   TimeSpan.FromSeconds(5)
               );
            }

        }


        [ObservableProperty]
        private ObservableCollection<Product> _productsCollection = GenerateProducts();

        static private ObservableCollection<Product> GenerateProducts()
        {
            var random = new Random();
            var products = new ObservableCollection<Product> { };

            var adjectives = new[] { "Red", "Blueberry" };
            var names = new[] { "Marmalade", "Dumplings", "Soup" };
            var units = new[] { "grams", "kilograms", "milliliters" };

            for (int i = 0; i < 50; i++)
            {
                products.Add(
                    new Product
                    {
                        ProductId = i,
                        ProductCode = i,
                        ProductName =
                            adjectives[random.Next(0, adjectives.Length)]
                            + " "
                            + names[random.Next(0, names.Length)],
                        UnitPrice = Math.Round(random.NextDouble() * 20.0, 3),
                        UnitsInStock = random.Next(0, 100),
                        IsVirtual = random.Next(0, 2) == 1
                    }
                );
            }

            return products;
        }


        [ObservableProperty]
        private Brush _ellipseBackground = Brushes.LightGray;

        [RelayCommand]
        private void RadioButtonColor(object param)
        {

            var paramClass = (MyColorButtonCommand)param;

            string color = paramClass.Param1;


            switch (color)
            {
                case "red":
                    EllipseBackground = Brushes.Red;
                    break;
                case "green":
                    EllipseBackground = Brushes.Green;
                    break;
                case "blue":
                    EllipseBackground = Brushes.Blue;
                    break;
                default:
                    EllipseBackground = Brushes.LightGray;
                    break;
            }




        }

       

    }


    public class MyColorButtonCommand
    {
        public string Param1 { get; set; } = "Gray";
        public object? Param2 { get; set; }
    }

}
