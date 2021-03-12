using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Gramajo_202008025_Lab3_repaso
{
    class Propiedad
    {
        string ncasa;
        string dpi;
        double cuota;

        public string Ncasa { get => ncasa; set => ncasa = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public double Cuota { get => cuota; set => cuota = value; }

        public Propiedad(string ncasa, string dpi, double cuota)
        {
            this.Ncasa = ncasa;
            this.Dpi = dpi;
            this.Cuota = cuota;
        }

        public override string ToString()
        {
            return this.ncasa + ";" + this.dpi + ";" + this.cuota;
        }
    }
}
