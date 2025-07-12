using MiAppVeterinaria.handlers;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MiAppVeterinaria
{
    public partial class Form1 : Form
    {
        public string username;
        public string password;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Podés manejar cambios de rol si es necesario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT username,password_,rolname FROM usuario u INNER JOIN Rol r ON r.id_rol = u.rol WHERE username = @username AND password_ = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("¡Login exitoso!", $"Acceso a {reader["rolname"].ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string rolname = reader["rolname"].ToString();
                                Form menuPrincipal = new Form2(rolname);
                                menuPrincipal.Text = rolname;
                                menuPrincipal.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
