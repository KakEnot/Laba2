using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.IO;
using OfficeOpenXml;


namespace laba2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public int StrinhSplitOptions { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var q = Threat.FileUpload();
            SashaPipiska.ItemsSource = q.Split('%');
        }
       

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }






}
