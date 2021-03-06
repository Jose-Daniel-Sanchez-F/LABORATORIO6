namespace LABORATORIO6
{
    public partial class Form1 : Form
    {
        List <Vehiculo> vehiculos= new List<Vehiculo> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void GuardarVehiculo()
        {
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
           
            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.placa);
                writer.WriteLine(vehiculo.marca);
                writer.WriteLine(vehiculo.modelo);
                writer.WriteLine(vehiculo.color);
                writer.WriteLine(vehiculo.preciokilometro);
            }

            writer.Close();
        }

        private void buttonIngreso_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo ();
            vehiculo.placa = textBoxPlaca.Text;
            vehiculo.marca = textBoxMarca.Text;
            vehiculo.color = textBoxColor.Text;
            vehiculo.modelo = Convert.ToInt16(textBoxModelo.Text);
            vehiculo.preciokilometro = Convert.ToDecimal(textBoxPrecio.Text); 

            int poscion = vehiculos.FindIndex(x=>x.placa==vehiculo.placa);

            if(poscion==-1)
            {
                vehiculos.Add(vehiculo);
                GuardarVehiculo();
            }else
            {
                MessageBox.Show("Placa Repetida"); 
            }

        }

        private void buttonAlquiler_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
        }
    }
}