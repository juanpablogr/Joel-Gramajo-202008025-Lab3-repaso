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

        void SavePropietarios()
        {
            StreamWriter sw = new StreamWriter(new FileStream(PropPath, FileMode.Create, FileAccess.Write));
            
            for (int i = 0; i < prop.Count; i++)
            {
                sw.WriteLine(prop[i].ToString());
            }

            sw.Close();
        }

        void SaveInmuebles()
        {
            StreamWriter sw = new StreamWriter(new FileStream(InmPath, FileMode.Create, FileAccess.Write));

            for (int i = 0; i < inm.Count; i++)
            {
                sw.WriteLine(inm[i].ToString());
            }

            sw.Close();
        }

        void RefreshGridView()
        {
            gdata.Clear();

            for (int i = 0; i < inm.Count; i++)
            {
                int idx = prop.FindIndex(p => p.Dpi == inm[i].Dpi);
                gdata.Add(new GridData(prop[idx].Nombre, prop[idx].Apellido, inm[i].Ncasa, inm[i].Cuota));
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gdata.OrderByDescending(p => p.Cuota_de_mantenimiento).ToList();
            dataGridView1.Refresh();
        }

        void RefreshInfo()
        {
            if (inm.Count > 0)
            {
                textBox8.Text = "";
                textBox9.Text = "";

                List<Orden> lst = new List<Orden>();

                for (int i = 0; i < inm.Count; i++)
                {
                    int idx = lst.FindIndex(p => p.Dpi == inm[i].Dpi);

                    if (idx == -1)
                    {
                        lst.Add(new Orden(inm[i].Dpi));
                        lst[lst.Count - 1].AddProp(inm[i].Cuota);
                    }
                    else
                    {
                        lst[idx].AddProp(inm[i].Cuota);
                    }
                }

                lst = lst.OrderByDescending(p => p.Props).ToList();
                textBox7.Text = "Dpi: " + lst[0].Dpi + " con " + lst[0].Props + " propiedades.";

                inm = inm.OrderByDescending(p => p.Cuota).ToList();

                int k = 0;
                string[] lines = { "", "", "" };

                for (int i = 0; i < 3; i++)
                {
                    if (inm.Count >= i + 1)
                    {
                        lines[k] = "DPI propietario: " + inm[i].Dpi + " | Número casa: " + inm[i].Ncasa + " | Cuota: " + inm[i].Cuota + "\n";
                        k++;
                    }
                }
                textBox8.Lines = lines;

                lines[0] = "";
                lines[1] = "";
                lines[2] = "";
                k = 0;
                for (int i = inm.Count - 3; i < inm.Count; i++)
                {
                    if (i >= 0)
                    {
                        lines[k] = "DPI propietario: " + inm[i].Dpi + " | Número de casa: " + inm[i].Ncasa + " | Cuota: " + inm[i].Cuota + "\n";
                        k++;
                    }
                }
                textBox9.Lines = lines;

                lst = lst.OrderByDescending(p => p.Cuota_total).ToList();
                textBox10.Text = "DPI: " + lst[0].Dpi + " Cuota total: " + lst[0].Cuota_total;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPropietarios();
            LoadInmuebles();
            RefreshInfo();
            RefreshGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (prop.FindIndex(p => p.Dpi == textBox1.Text) == -1)
                {
                    prop.Add(new Propietario(textBox1.Text, textBox2.Text, textBox3.Text));
                    SavePropietarios();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else MessageBox.Show("ERROR: El propietario ya existe!");
            }
            else MessageBox.Show("ERROR: Datos inválidos!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double n;
            int idx = prop.FindIndex(p => p.Dpi == textBox5.Text);

            if (idx != -1)
            {
                if (textBox6.Text != "" && double.TryParse(textBox4.Text, out n))
                {
                    if (inm.FindIndex(p => p.Ncasa == textBox6.Text) == -1)
                    {
                        Propiedad j = new Propiedad(textBox6.Text, textBox5.Text, n);
                        inm.Add(j);
                        SaveInmuebles();

                        RefreshGridView();

                        RefreshInfo();

                        textBox6.Text = "";
                        textBox5.Text = "";
                        textBox4.Text = "";
                    }
                    else MessageBox.Show("ERROR: La propiedad ya existe!");
                }
                else MessageBox.Show("ERROR: Datos inválidos!");
            }
            else MessageBox.Show("ERROR: El DPI ingresado no está registrado!");
        }
    }
}
