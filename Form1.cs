using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Joel_Gramajo_202008025_Lab3_repaso
{
    public partial class Form1 : Form
    {
        List<Propietario> prop = new List<Propietario>();
        List<Propiedad> inm = new List<Propiedad>();
        List<GridData> gdata = new List<GridData>();

        string PropPath = Directory.GetCurrentDirectory() + "\\" + "Propietarios.txt";
        string InmPath = Directory.GetCurrentDirectory() + "\\" + "Propiedades.txt";

        void LoadPropietarios()
        {
            StreamReader sr = new StreamReader(new FileStream(PropPath, FileMode.OpenOrCreate, FileAccess.Read));

            foreach(string line in sr.ReadToEnd().Split('\n'))
            {
                if (line.Length != 0)
                {
                    string[] pr = line.Split(';');
                    prop.Add(new Propietario(pr[0], pr[1], pr[2]));
                }
            }

            sr.Close();
        }

        void LoadInmuebles()
        {
            StreamReader sr = new StreamReader(new FileStream(InmPath, FileMode.OpenOrCreate, FileAccess.Read));

            foreach(string line in sr.ReadToEnd().Split('\n'))
            {
                if (line.Length != 0)
                {
                    string[] pr = line.Split(';');
                    inm.Add(new Propiedad(pr[0], pr[1], double.Parse(pr[2])));
                }
            }

            sr.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPropietarios();
            LoadInmuebles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
