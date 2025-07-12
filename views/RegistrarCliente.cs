using MiAppVeterinaria.Repository;
using System;
using System.Windows.Forms;

namespace MiAppVeterinaria.Views
{
    public partial class RegistrarCliente : Form
    {
        private readonly DuenioRepository duenioRepository = new DuenioRepository();
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string contacto = textBox3.Text;

            if (duenioRepository.RegistrarDuenio(nombre, apellido, contacto))
            {
                MessageBox.Show("Dueño registrado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Algo fallo");
            }

        }
    }
}
