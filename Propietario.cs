using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Gramajo_202008025_Lab3_repaso
{
    class Propietario
    {
        string dpi;
        string nombre;
        string apellido;

        public string Dpi { get => dpi; set => dpi = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Propietario(string dpi, string nombre, string apellido)
        {
            this.Dpi = dpi;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public override string ToString()
        {
            return this.dpi + ";" + this.nombre + ";" + this.apellido;
        }
    }
}
