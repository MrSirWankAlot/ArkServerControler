﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using ArkServerConfigEditor.Model;
using ArkServerConfigEditor.Viewmodel;
using Path = System.IO.Path;

namespace ArkServerConfigEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMindowViewmodel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = this.DataContext as MainMindowViewmodel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Setting> vmSettingList = vm.SettingList;
            File.WriteAllLines(vm.IniPath,vmSettingList.Select(x=> $"{x.SettingName}={x.SettingValue}"));
        }
    }
}
