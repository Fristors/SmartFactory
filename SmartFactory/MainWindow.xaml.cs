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

namespace SmartFactory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Odb.db = new System.Data.Entity.DbContext("Data Source=sql;initial catalog=SmartFactory;user id=sa;password=server_esa;MultipleActiveResultSets=True;App=EntityFramework&quot;");
            FrameApp.FrameObj = FrameMain;
            FrameApp.FrameObj.Navigate(new FactoryPage());

        }
    }
}
