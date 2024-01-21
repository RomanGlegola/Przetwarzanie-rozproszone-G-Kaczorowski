using System;
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

namespace MyProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Breakfast breakfast;
        BreakfastAsync breakfastAsync;
        public MainWindow()
        {
            InitializeComponent();

            breakfast = new Breakfast();
            breakfast.MyCallback(UpdateBreakfastList);


            breakfastAsync = new BreakfastAsync();
            breakfastAsync.MyCallback(UpdateBreakfastListAsync);
        }

        private void UpdateBreakfastListAsync(string message)
        {
            this.Dispatcher.Invoke(() =>
            {
                lstBreakfastAsync.Items.Add(message);
            });
        }
   
        private void UpdateBreakfastList(string message)
        {
            lstBreakfast.Items.Add(message);
        }

        private void btnPrepareBrakfast_Click(object sender, RoutedEventArgs e)
        {
            breakfast.MakeBreakfast();
            //MessageBox.Show("hello wpf");
           // lstBreakfast.Items.Add("new item");
        }

        private async void btnPrepareBreakfastAsync_Click(object sender, RoutedEventArgs e)
        {
            await breakfastAsync.MakeBreakfast();
        }
    }
}
