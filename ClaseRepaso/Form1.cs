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
//acceso a binaryFormater
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Text;




namespace ejercicioClase8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double total;
        FileStream archivo;
        StreamReader sr;
        StreamWriter sw;
        Sistema miEmpresa;

        private void bLeer_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.InitialDirectory = ".";
            Abrir.Filter = "Archivos CSV (*.CSV)|*.CSV";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                archivo = new FileStream(Abrir.FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(archivo);
                string linea;
                string[] campos;
                ItemFactura consumible;
                while (!sr.EndOfStream)
                {
                    campos = sr.ReadLine().Split(';');
                    if (campos[0] == "s" || campos[0] == "S")
                    {
                        consumible = new Servicio(campos[2],
                                    Convert.ToInt32(campos[3]));
                        consumible.Precio = Convert.ToDouble(campos[4]);
                        consumible.Codigo = Convert.ToInt32(campos[1]);
                        miEmpresa.consumibles.Add(consumible);
                    }
                    if (campos[0] == "p" || campos[0] == "P")
                    {
                        consumible = new Producto(campos[2]);
                        consumible.Codigo = Convert.ToInt32(campos[1]);
                        consumible.Precio = Convert.ToDouble(campos[4]);
                        miEmpresa.consumibles.Add(consumible);
                    }
                }
                sr.Close();
                archivo.Close();
                AgregarDatos();
            }
        }
        private void AgregarDatos()
        {
            foreach (ItemFactura c in miEmpresa.consumibles)
            {
                if (c is Servicio)
                    cBservicio.Items.Add(c);
                else
                    cBproducto.Items.Add(c);
            }
        }
                       
        private void PrepararOrden()
        {
            lBitemFactura.Items.Clear();
            lBitemFactura.Items.Add("Cliente: " + tBnombre.Text);
            lBitemFactura.Items.Add(" ");
            total = 0;
            tBnombre.Enabled = false;
            bGenerar.Text = "Nuevo";
            bAgregarPro.Enabled = true;
            bAgregarSer.Enabled = true;
            bGuardar.Enabled = true;
        }
        private void FinalizarOrden()
        {
            tBnombre.Text = "";
            tBnombre.Enabled = true;
            lBitemFactura.Items.Clear();
            bGenerar.Text = "Generar";
            bAgregarPro.Enabled = false;
            bAgregarSer.Enabled = false;
            bGuardar.Enabled = false;
        }
        private void bGenerar_Click(object sender, EventArgs e)
        {
            if (tBnombre.Enabled)
            {
                if (tBnombre.Text != "")
                    PrepararOrden();
                else
                    MessageBox.Show("Complete nombre del cliente");

            }
            else
            {
              if ( MessageBox.Show("Cancela Orden?","Advertencia",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation)
                    == DialogResult.OK)
                {
                    FinalizarOrden();
                }
            }
           
        }

        private void bAgregarSer_Click(object sender, EventArgs e)
        {
            ItemFactura consumible = (ItemFactura)cBservicio.SelectedItem;
            lBitemFactura.Items.Add(consumible.Codigo + " " +
                consumible.Descripcion + " " + consumible.Precio.ToString("$0.00"));
            total += consumible.Precio;
        }

        private void bAgregarPro_Click(object sender, EventArgs e)
        {
            int cantidad = (int)nUcantidad.Value;
            
            ItemFactura consumible = (ItemFactura)cBproducto.SelectedItem;
            double precio = cantidad * consumible.Precio;
            lBitemFactura.Items.Add(consumible.Codigo + " " +
                consumible.Descripcion + " " + cantidad + " subtotal:"
                + precio.ToString("$0.00"));
            total += precio;
        }
        private void GenerarOrden()
        {
            int cantidad = lBitemFactura.Items.Count - 3;
            string[] items = new string[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                items[i] = lBitemFactura.Items[i+2].ToString();
            }

            OrdenDeObra unaOrden = new OrdenDeObra(tBnombre.Text,
                                       items, total);
            miEmpresa.ordenesGeneradas.Add(unaOrden);
        }
        private void bGuardar_Click(object sender, EventArgs e) // Boton de Guardar
        {
            lBitemFactura.Items.Add("Total a Pagar: " + total.ToString(" $0.00"));
            string nombre = Application.StartupPath + @"\" + tBnombre.Text;
            archivo = new FileStream(nombre, FileMode.OpenOrCreate, FileAccess.Write);
            sw = new StreamWriter(archivo);
                foreach (string linea in lBitemFactura.Items)
                    sw.WriteLine(linea);
                sw.Close();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(archivo, miEmpresa);
            archivo.Close();
            GenerarOrden();
            FinalizarOrden();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            miEmpresa = new Sistema();

            if (File.Exists("datos.bin")) 
            {
                archivo = new FileStream("datos.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                miEmpresa = (Sistema)bf.Deserialize(archivo);
                AgregarDatos();
            }
            else
                miEmpresa = new Sistema();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            archivo = new FileStream("datos.bin", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(archivo, miEmpresa);
            archivo.Close();

        }
    }
}
