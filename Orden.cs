using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Gramajo_202008025_Lab3_repaso
{
    class Orden
    {
        string dpi;
        int props = 0;
        double cuota_total = 0;

        public string Dpi { get => dpi; set => dpi = value; }
        public int Props { get => props; set => props = value; }
        public double Cuota_total { get => cuota_total; set => cuota_total = value; }

        public Orden(string dpi)
        {
            this.dpi = dpi;
        }

        public void AddProp(double cuota)
        {
            this.props++;
            this.cuota_total += cuota;
        }
    }
}
