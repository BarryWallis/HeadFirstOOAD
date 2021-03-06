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
using DougsDogDoors.ViewModel;

namespace DougsDogDoors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void OpenCloseButton_Click(object sender, RoutedEventArgs e) => viewModel.PressButton();

        private void BarkButton_Click(object sender, RoutedEventArgs e) => viewModel.BarkRecognized();

        private void AddBarksButton_Click(object sender, RoutedEventArgs e) => viewModel.AddBarks();
    }
}
