using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для CHPYPage.xaml
    /// </summary>
    public partial class CHPYPage : Page
    {
        List<StatusNow> Statuss = new List<StatusNow>();
        List<Lamp> Lamps = new List<Lamp>();
        string _location;
        public CHPYPage()
        {
            InitializeComponent();
            this.MouseUp += CHPYPage_MouseUp;
            _location = "Центр обработки станками с ЧПУ";
            Lamps = Odb.db.Database.SqlQuery<Lamp>("select * from Lamp left join DevList on Lamp.DevId = DevList.id where DevList.Location = @param1", new SqlParameter("@param1", _location)).ToList();
            foreach(var lamp in Lamps)
            {
                Ellipse img = new Ellipse();
                img.Name = lamp.Name;
                img.Width = 15;
                img.Height = 15;
                img.MouseDown += Img_MouseDown;
                Main.Children.Add(img);
                Canvas.SetTop(img, lamp.PosY);
                Canvas.SetLeft(img, lamp.PosX);
            }
            Statuss = Odb.db.Database.SqlQuery<StatusNow>("select StatusNow.id as id, DevList.Name as NameDev, StatusList.Status as Status, StatusNow.LastCheck as LastCheck, Lamp.Name as NameLamp from StatusNow left join StatusList on StatusNow.idStatus = StatusList.id left join DevList on DevList.id = StatusNow.idDev left join Lamp on Lamp.DevId = DevList.id where DevList.Location = @param1", new SqlParameter("@param1", _location)).ToList();
            foreach(var status in Statuss)
            {
                Ellipse elem = new Ellipse();
                foreach (var item in Main.Children)
                {
                    if(((Ellipse)item).Name == status.NameLamp)
                    {
                        elem = (Ellipse)item;
                        break;
                    }
                }                 
                if (elem == null) continue;
                switch (status.Status)
                {
                    case "Работа":
                        elem.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        break;
                    case "Авария":
                        elem.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case "Конец операции":
                        elem.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        break;
                    default:
                        elem.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                        break;
                }
            }
            
        }

        private void CHPYPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Point p = e.GetPosition();
            //MessageBox.Show()
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameObj.GoBack();
        }

        private void Stan1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
