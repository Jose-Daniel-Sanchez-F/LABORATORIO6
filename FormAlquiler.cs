using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABORATORIO6
{
    public partial class FormAlquiler : Form
    {
        List<Alquileres> alquileres = new List<Alquileres>();
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Mostrar> mostrar = new List<Mostrar>();

        public FormAlquiler()
        {
            InitializeComponent();
        }

        private void GuardarAlquileres()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach(var alquiler in alquileres)
            {
                writer.WriteLine(alquiler.nit);
                writer.WriteLine(alquiler.placa);
                writer.WriteLine(alquiler.fechaAlquiler);
                writer.WriteLine(alquiler.fechaDevolucion);
                writer.WriteLine(alquiler.kilometros);
            }
            writer.Close();
        }
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Alquileres alquiler = new Alquileres();
            alquiler.nit = textBoxNit.Text;
            alquiler.placa = textBoxPlaca.Text;
            alquiler.fechaAlquiler = dateTimePickerPrestamo.Value;
            alquiler.fechaDevolucion = dateTimePickerDevolucion.Value;
            alquiler.kilometros = Convert.ToInt16(textBoxKilometros.Text);

            alquileres.Add(alquiler);
            GuardarAlquileres();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            for (int i =0; i < alquileres.Count; i++)
            {
                Mostrar mostrarTemp = new Mostrar();
                for (int j = 0; j < clientes.Count; j++)
                {
                    if (alquileres[i].nit==clientes[j].nit)
                    {
                       mostrarTemp.nombre = clientes[j].nombre; 
                    }

                }
                for (int k = 0; k < vehiculos.Count; k++)
                {
                    if (alquileres[i].placa == vehiculos[k].placa)
                    {
                        mostrarTemp.placa= vehiculos[k].placa;  
                        mostrarTemp.color = vehiculos[k].color;
                        mostrarTemp.total = vehiculos[k].preciokilometro * alquileres[i].kilometros;

                    }

                }
                mostrar.Add(mostrarTemp);
                
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                
                dataGridView1.DataSource = mostrar;
                dataGridView1.DataSource = null;

            }
        }
    }
}
