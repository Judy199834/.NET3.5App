using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrimeSieves_DotNet35;

namespace PrimeVisualizer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            min_TextBox.Text = "10";
            max_TextBox.Text = "1496";
            GeneratePrimes();
            GenerateDataTable();
            TestJasonVisualizer();
        }
        void GeneratePrimes()
        {
            primeNumberDisplay.Children.Clear();

            ISieve sieve = SieveFactory.GetSieve(SieveType.Turner);
            ulong min = Convert.ToUInt32(min_TextBox.Text);
            ulong max = Convert.ToUInt32(max_TextBox.Text);
            Prime p;
            do
            {
                p = sieve.NextPrime();
            }
            while (p < min);

            string currentMinText = min_TextBox.Text;
            string currentMaxText = max_TextBox.Text;   
            string result = string.Join(",", new string[] { currentMinText, currentMaxText }); //set a breakpoint here

            for (ulong i = min; i <= max; ++i)
            {
                Ellipse e = new Ellipse();
                e.Height = 10;
                e.Width = 10;
                e.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 200, 105));

                if (i == p)
                {
                    e.Fill = new SolidColorBrush(Color.FromArgb(255, 44, 89, 64));
                    p = sieve.NextPrime();
                }
                primeNumberDisplay.Children.Add(e);
            }
        }

        void generate_Button_Click(object sender, RoutedEventArgs e)
        {
            GeneratePrimes();
            GenerateDataTable();
            TestJasonVisualizer();
        }

        void GenerateDataTable()
        {
            DataTable dt = new DataTable("Table_AX");
            dt.Columns.Add("column0", System.Type.GetType("System.String"));
            DataColumn dc = new DataColumn("column1", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("column2", System.Type.GetType("System.Int32"));
            dt.Columns.Add("column3", System.Type.GetType("System.Guid"));

            dt.Columns.Add(dc);
            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");

            for (int i = 0; i < 50; i++)
            {
                DataRow dr = dt.NewRow();
                dr["column0"] = "AX_" + i;
                dr["column1"] = true;
                dr["column2"] = i;
                dr["column3"] = guid;
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dt.Rows.Add(dr1);    //set a breakpoint here
        }

        void TestJasonVisualizer()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "..\\..\\data.json");
            string json = File.ReadAllText(path);
            string results = json;//set a breakpoint here
        }
    }
}
