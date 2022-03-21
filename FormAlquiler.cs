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
    }
}
