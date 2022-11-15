using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SmartFactory
{
    internal class StatusNow
    {
        public int id { get; set; }
        public string NameDev { get; set; }
        public string Status { get; set; }
        public DateTime LastCheck { get; set; }
        public string NameLamp { get; set; }
    }
    public class Location
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
    internal class Lamp
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
