using BusinessLigoc;
using Model;
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

namespace CarAccountingWPFWithDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarService carService;
        Car carUpdate;

        public MainWindow()
        {
            InitializeComponent();

            
            carService = new CarService();
            DataGridCar.ItemsSource = carService.Get();
        }

        private void UpdateGrid()
        {
            DataGridCar.ItemsSource = null;
            DataGridCar.ItemsSource = carService.Get();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            carService.Update(e.Row.Item as Car);
            UpdateGrid();
        }

        private void ButtonADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TextBoxModel.Text) || !String.IsNullOrEmpty(TextBoxCompany.Text) || !String.IsNullOrEmpty(TextBoxPrice.Text) /*|| (!String.IsNullOrEmpty(TextBoxReleaseYear.Text))*/)
                {
                   carService.Create(new Model.Car { Model = TextBoxModel.Text, Company = TextBoxCompany.Text, Price = int.Parse(TextBoxPrice.Text), /*ReleaseYear=int.Parse(TextBoxReleaseYear.Text)*/ });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            UpdateGrid();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCar.SelectedItems.Count > 0 && MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < DataGridCar.SelectedItems.Count; i++)
                {
                    Car car = DataGridCar.SelectedItems[i] as Car;
                    if (car != null)
                    {
                        carService.Delete(car);
                    }
                }
            }
            UpdateGrid();

        }

        private void TextBoxCompany_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxCompany.Clear();
        }

        private void TextBoxReleaseYear_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBoxModel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxModel.Clear();
        }

        private void TextBoxPrice_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxPrice.Clear();
        }

        private void TextBoxReleaseYear_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //TextBoxReleaseYear.Clear();
        }

        public void ShowData(Car car)
        {
            //TextBoxModel.Text = car.Model;
            //TextBoxCompany.Text = car.Company;
            //TextBoxPrice.Text = Convert.ToString(car.Price);
            //carUpdate = car;
            
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //carUpdate.Model = TextBoxModel.Text;
            //carUpdate.Company = TextBoxCompany.Text;
            //carUpdate.Price = int.Parse(TextBoxPrice.Text);
            //carService.Update(carUpdate);
           
        }
    }
}
