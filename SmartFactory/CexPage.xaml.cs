using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace SmartFactory
{
    /// <summary>
    /// Логика взаимодействия для CexPage.xaml
    /// </summary>
    public partial class CexPage : Page
    {
        public delegate void NextPrimeDelegate();
        Location Cex = new Location();
        List<Lamp> Lamps = new List<Lamp>();
        List<StatusNow> Statuss = new List<StatusNow>();
        Timer t { get; set; }
        public CexPage(Location location)
        {
            InitializeComponent();
            Cex = location;
            MemoryStream m = new MemoryStream(Cex.Image);

            BitmapImage a = new BitmapImage();
            a.BeginInit();
            a.StreamSource = m;
            a.EndInit();
            Fon.Source = a;


            Lamps = Odb.db.Database.SqlQuery<Lamp>("select * from Lamp left join DevList on Lamp.DevId = DevList.id where DevList.Location = @param1 and LocPos = 2", new SqlParameter("@param1", Cex.id)).ToList();
            foreach (var lamp in Lamps)
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
            
            t = new Timer(test, null, 0, 1000);
        }

        public void test(object o)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new NextPrimeDelegate(CheckStatus));
        }

        public void CheckStatus()
        {
                Statuss = Odb.db.Database.SqlQuery<StatusNow>("select StatusNow.id as id, DevList.Name as NameDev, StatusList.Status as Status, StatusNow.LastCheck as LastCheck, Lamp.Name as NameLamp from StatusNow left join StatusList on StatusNow.idStatus = StatusList.id left join DevList on DevList.id = StatusNow.idDev left join Lamp on Lamp.DevId = DevList.id where DevList.Location = @param1", new SqlParameter("@param1", Cex.id)).ToList();
                foreach (var status in Statuss)
                {
                    Ellipse elem = new Ellipse();

                    foreach (var item in Main.Children)
                    {
                        if (((Ellipse)item).Name == status.NameLamp)
                        {
                            if ((Ellipse)item == null) continue;


                            switch (status.Status)
                            {
                                case "Работа":
                                    ((Ellipse)item).Fill = Brushes.LightGreen;
                                    break;
                                case "Авария":
                                    ((Ellipse)item).Fill = Brushes.Red;
                                    break;
                                case "Конец операции":
                                    ((Ellipse)item).Fill = Brushes.Yellow;
                                    break;
                                default:
                                    ((Ellipse)item).Fill = Brushes.Gray;
                                    break;
                            }
                            break;
                        }
                    }
                }
            t.Change(3000, 0);
        }
        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string lamp = ((Ellipse)sender).Name;
            //StatusNow status = Odb.db.Database.SqlQuery<StatusNow>("select StatusNow.id as id, DevList.Name as NameDev, StatusList.Status as Status, StatusNow.LastCheck as LastCheck, Lamp.Name as NameLamp from StatusNow left join StatusList on StatusNow.idStatus = StatusList.id left join DevList on DevList.id = StatusNow.idDev left join Lamp on Lamp.DevId = DevList.id where Lamp.Name = @param1", new SqlParameter("@param1", lamp)).SingleOrDefault();
            StatusNow status = Statuss.Find(u => u.NameLamp == lamp);
            StanName.Text = "Станок - " + status.NameDev;
            StatusName.Text = "Статус - " + status.Status;
            CheckName.Text = "Последняя проверка - " + status.LastCheck.ToString("dd.mm.yyyy HH:mm:ss");

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            FrameApp.FrameObj.GoBack();

            GC.Collect();
        }
    }
}
