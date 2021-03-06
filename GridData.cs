using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Gramajo_202008025_Lab3_repaso
{
    class GridData
    {
        string nombre_propietario;
        string apellido_propietario;
        string numero_de_casa;
        double cuota_de_mantenimiento;

        public string Nombre_propietario { get => nombre_propietario; set => nombre_propietario = value; }
        public string Apellido_propietario { get => apellido_propietario; set => apellido_propietario = value; }
        public string Numero_de_casa { get => numero_de_casa; set => numero_de_casa = value; }
        public double Cuota_de_mantenimiento { get => cuota_de_mantenimiento; set => cuota_de_mantenimiento = value; }

        public GridData(string nombre, string apellido, string ncasa, double cuota)
        {
            this.Nombre_propietario = nombre;
            this.Apellido_propietario = apellido;
            this.Numero_de_casa = ncasa;
            this.Cuota_de_mantenimiento = cuota;
        }
    }
}
