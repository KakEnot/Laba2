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
        
        List<object> TableThread=new List<object>();

        public MainWindow()
        {
            InitializeComponent();

        }

        public int StrinhSplitOptions { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TableData.ItemsSource = DocumentService.FileUpload();
            TableData.IsReadOnly = true;
            TableData.AutoGenerateColumns = false;
            foreach (var item in TableData.ItemsSource)
            {
                TableThread.Add(item);
            }
            
        }


        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }


        private void TableData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var t = TableData.SelectedItem as Threat;
            if (t != null)
            {
                new InfThreadWindow(t).Show();
            }

        }
    }
}
