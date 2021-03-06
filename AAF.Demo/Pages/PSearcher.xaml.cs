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

using System.Data;
using System.Globalization;

namespace AAF.Demo.Pages
{
    /// <summary>
    /// PExtractor.xaml 的交互逻辑
    /// </summary>
    public partial class PSearcher : UserControl
    {
        public PSearcher()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog()
            {
                Description="请选择根目录",
            };
            if (tb_fileAddress.Text != "")
            {
                dialog.SelectedPath = tb_fileAddress.Text;
            }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_fileAddress.Text = dialog.SelectedPath;
            }
        }

       
    }

    [ValueConversion(typeof(object), typeof(bool))]
    public class MyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
