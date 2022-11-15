using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для FactoryPage.xaml
    /// </summary>
    public partial class FactoryPage : Page
    {
        Border cex = new Border();
        List<Location> Locations = new List<Location>();
        String Path = "";
        public FactoryPage()
        {
            InitializeComponent();
            Locations = Odb.db.Database.SqlQuery<Location>("SELECT * FROM Location", new SqlParameter("", "")).ToList();
            foreach (Location location in Locations)
            {
                Border item = new Border();
                item.Name = location.Name;
                ToolTip t = new ToolTip();
                item.Cursor = Cursors.Hand;
                t.Content = location.Description;
                item.ToolTip = t;
                item.Background = Brushes.Transparent;
                item.BorderBrush = Brushes.Transparent;
                item.BorderThickness = new Thickness(2, 2, 2, 2);
                Main.Children.Add(item);
                Canvas.SetTop(item, location.PosY);
                Canvas.SetLeft(item, location.PosX);
                item.Width = location.Width;
                item.Height = location.Height;
                item.MouseDown += GoTo_Click;
            }

        }

        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Border)sender).Name;
            cex = new Border();
            Location location = Locations.Where(u => u.Name == name).SingleOrDefault();
            if (location == null) return;
            JournalEntry s = FrameApp.FrameObj.NavigationService.RemoveBackEntry();
            FrameApp.FrameObj.Navigate(new CexPage(location));
        }

        private void AddCEX_Click(object sender, RoutedEventArgs e)
        {
            if (cex != null)
            {
                Main.Children.Remove(cex);
                cex = new Border();
            }
            cex.Name = "cex" + (Locations.Last().id + 1).ToString();
            Main.Children.Add(cex);
            Canvas.SetTop(cex, 0);
            Canvas.SetLeft(cex, 0);
            //Main.BeginInit();
            this.MouseUp += Main_MouseUp;
        }

        private void Main_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point Curs = e.GetPosition(Main);
            cex.Background = Brushes.DarkGray;
            Canvas.SetTop(cex, Curs.Y);
            Canvas.SetLeft(cex, Curs.X);
            this.MouseDown += Main_MouseDown;
            this.MouseMove += Main_MouseMove;
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MouseMove -= Main_MouseMove;
            this.MouseUp -= Main_MouseUp;
            Point Loc = new Point(Canvas.GetLeft(cex), Canvas.GetTop(cex));
            Point Size = e.GetPosition(Main);
            cex.Width = Size.X - Loc.X > 0 ? Size.X - Loc.X : 0;
            cex.Height = Size.Y - Loc.Y > 0 ? Size.Y - Loc.Y : 0;
            AddCEX.Background = Brushes.Green;
            this.MouseDown -= Main_MouseDown;
            SaveCex.IsEnabled = true;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            Point Loc = new Point(Canvas.GetLeft(cex), Canvas.GetTop(cex));
            Point Size = e.GetPosition(Main);
            cex.Width = Size.X - Loc.X > 0 ? Size.X - Loc.X : 0;
            cex.Height = Size.Y - Loc.Y > 0 ? Size.Y - Loc.Y : 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] img = ReadImageToBytes();
            Location loc = new Location()
            {
                Description = NameTB.Text,
                Name = cex.Name,
                PosX = (int)Canvas.GetLeft(cex),
                PosY = (int)Canvas.GetTop(cex),
                Width = (int)cex.Width,
                Height = (int)cex.Height
            };
            Odb.db.Database.ExecuteSqlCommand("insert into Location(Description, Image, Name, PosX, PosY, Width, Height) values(@Description, @Image, @Name, @PosX, @PosY, @Width, @Height)",
                new SqlParameter("@Description", loc.Description),
                new SqlParameter("@Image", img),
                new SqlParameter("@Name", loc.Name),
                new SqlParameter("@PosX", loc.PosX),
                new SqlParameter("@PosY", loc.PosY),
                new SqlParameter("@Width", loc.Width),
                new SqlParameter("@Height", loc.Height));
            cex = new Border();
            Path = "";

            MenuGrid.Visibility = Visibility.Hidden;
            foreach (var elem in Main.Children)
            {
                ((Border)elem).MouseDown += GoTo_Click;
                ((Border)elem).Cursor = Cursors.Hand;
                ((Border)elem).Background = Brushes.Transparent;
                ((Border)elem).BorderBrush = Brushes.Transparent;
            }
        }
        private byte[] ReadImageToBytes()
        {
            FileInfo fInfo = new FileInfo(Path);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            byte[] data = br.ReadBytes((int)numBytes);
            return data;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Hidden;
            foreach (var elem in Main.Children)
            {
                ((Border)elem).MouseDown += GoTo_Click;
                ((Border)elem).Cursor = Cursors.Hand;
                ((Border)elem).Background = Brushes.Transparent;
                ((Border)elem).BorderBrush = Brushes.Transparent;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Visible;
            foreach(var elem in Main.Children)
            {
                ((Border)elem).MouseDown -= GoTo_Click;
                ((Border)elem).Cursor = Cursors.Arrow;
                ((Border)elem).Background = Brushes.Gray;
                ((Border)elem).Opacity = 0.5;
                ((Border)elem).BorderBrush = Brushes.Yellow;
            }
        }

        private void AddImg_Click(object sender, RoutedEventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.Multiselect = false;
            fileOpen.CheckFileExists = true;
            fileOpen.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (fileOpen.ShowDialog() == true)
            {
                Path = fileOpen.FileName;
                AddImg.Background = Brushes.Green; 
            }
        }
    }
}
