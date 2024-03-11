﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Async
{

    public partial class MainWindow : Window
    {
        int _counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            _counter++;
            LabelCounter.Content = _counter.ToString();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(5000);
        }
    }
}
