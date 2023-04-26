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
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.IO;

namespace WpfAppSQLTermekek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharpconnection";
        public List<Products> productList = new();
        public MySqlConnection connection;
        public SaveFileDialog saveFileDialog = new();

        public MainWindow()
        {
            InitializeComponent();
            DatabaseConnection();
            LoadCategory();
            LoadManifacturer();
            LoadProductsInList();

            
        }

        private void DatabaseConnection()
        {
            try
            {
                connection = new(connectionString);
                connection.Open();
                Console.WriteLine("Connected to mysql");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            };
        }

        private void CloseDatabaseConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        private void LoadProductsInList()
        {
            string getProducts = "SELECT * FROM termekek";
            MySqlCommand getProductCommand = new(getProducts, connection);
            MySqlDataReader reader = getProductCommand.ExecuteReader();

            while (reader.Read())
            {
                Products newProduct = new Products(reader.GetString("Kategoria"),
                                                    reader.GetString("Gyarto"),
                                                    reader.GetString("Nev"),
                                                    reader.GetInt32("Ar"),
                                                    reader.GetInt32("Garido"));
                productList.Add(newProduct);
            }
            reader.Close();
            dgProducts.ItemsSource = productList;

        }

        private void LoadCategory()
        {
            string getCategory = "SELECT DISTINCT kategoria FROM termekek ORDER BY kategoria";
            MySqlCommand getCategoryCommand = new(getCategory, connection);
            MySqlDataReader reader = getCategoryCommand.ExecuteReader();

            cbCategory.Items.Add("-Nincs megadva-");
            while (reader.Read())
            {
                cbCategory.Items.Add(reader.GetString("kategoria"));
            }
            reader.Close();
            cbCategory.SelectedIndex = 0;
        }

        private void LoadManifacturer()
        {
            string getManifacturer = "SELECT DISTINCT gyarto FROM termekek ORDER BY gyarto";
            MySqlCommand getManifacturerCommand = new(getManifacturer, connection);
            MySqlDataReader reader = getManifacturerCommand.ExecuteReader();

            cbManifacturers.Items.Add("-Nincs megadva-");
            while (reader.Read())
            {
                cbManifacturers.Items.Add(reader.GetString("gyarto"));
            }
            reader.Close();
            cbManifacturers.SelectedIndex = 0;
        }

        private string SortingQueryMaker()
        {
            bool haveCondition = false;
            string sortedListquery = "SELECT * FROM termekek ";

            if (cbManifacturers.SelectedIndex > 0 || cbCategory.SelectedIndex > 0 || txtProducts.Text != "")
            {
                sortedListquery += " WHERE ";
            }
            if (cbManifacturers.SelectedIndex > 0)
            {
                sortedListquery += $"gyarto='{cbManifacturers.SelectedItem} '";
                haveCondition = true;
            }
            if (cbCategory.SelectedIndex > 0)
            {
                if (haveCondition)
                {
                    sortedListquery += " AND ";
                }
                sortedListquery += $"kategoria='{cbCategory.SelectedItem}'";
                haveCondition = true; 
            }
            if (txtProducts.Text != "")
            {
                if (haveCondition)
                {
                    sortedListquery += " AND ";
                }
                sortedListquery += $"nev LIKE '%{txtProducts.Text}%' ";
            }
            return sortedListquery;
        }

        private void SortingQuery(object sender, RoutedEventArgs e)
        {
            productList.Clear();
            string sortedListSql = SortingQueryMaker();
            MySqlCommand sqlCommand = new(sortedListSql, connection);
            MySqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Products newProduct = new Products(reader.GetString("Kategoria"),
                                                    reader.GetString("Gyarto"),
                                                    reader.GetString("Nev"),
                                                    reader.GetInt32("Ar"),
                                                    reader.GetInt32("Garido"));
                productList.Add(newProduct);
            }
            reader.Close();
            dgProducts.Items.Refresh();
        }
        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, ToCSVString(productList));

            }
        }
    }

}
