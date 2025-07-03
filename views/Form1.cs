using System;
using System.Windows.Forms;

namespace MiAppVeterinaria
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            this.comboBox1.Items.AddRange(new object[] { "Administrador", "Recepcion", "Veterinario" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.txtUser.Text;
            string password = this.txtPassword.Text;
            string categoriaUsuario = this.comboBox1.SelectedItem?.ToString();

            try
            {
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "123")
                {
                    MessageBox.Show("¡Login exitoso!", $"Acceso a {categoriaUsuario}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form menuPrincipal = new Form2();
                    menuPrincipal.Text = categoriaUsuario;
                    menuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {

        }

        private void txtPassword_Enter_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
