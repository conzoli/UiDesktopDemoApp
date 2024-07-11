﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiDesktopDemoApp.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace UiDesktopDemoApp.Views.Pages
{
    /// <summary>
    /// Interaktionslogik für InputPage.xaml
    /// </summary>
    public partial class InputPage : INavigableView<InputViewModel>
    {

        public InputViewModel ViewModel { get; }

        public InputPage(InputViewModel viewModel)
        {
            ViewModel = viewModel;

            DataContext = this;

            InitializeComponent();

        }

        
    }
}
