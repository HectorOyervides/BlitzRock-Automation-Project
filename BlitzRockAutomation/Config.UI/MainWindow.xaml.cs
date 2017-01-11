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
using Blitz.Shared.Functions;
using Blitz.Shared.Data.DataFunctions;
using System.Data;

namespace Config.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public ReadExcel readExcel = null;
        public DataTable configDatatable;
        public string configFile = "C:\\BlitzRock\\Configuration\\Configuration.xlsx";

        public MainWindow()
        {
            InitializeComponent();

            configDatatable = new DataTable();
            readExcel = new ReadExcel(configDatatable, configFile, "Config");

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
