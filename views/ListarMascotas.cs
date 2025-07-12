using MiAppVeterinaria.Services;
using System;
using System.Windows.Forms;


namespace MiAppVeterinaria
{
    public class ListarMascotas : Form
    {
        private DataGridView dataGridView1;
        private readonly IMascotaService _mascotaService;

        public ListarMascotas()
        {
            _mascotaService = new MascotaService();
            this.Text = "Listado de Mascotas";
            this.Size = new System.Drawing.Size(800, 450);

            dataGridView1 = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(dataGridView1);

            this.Load += ListarMascotas_Load;
        }

        private void ListarMascotas_Load(object sender, EventArgs e)
        {
            CargarMascotas();
        }

        private void CargarMascotas()
        {
            try
            {
                var lista = _mascotaService.GetMascotas();
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mascotas: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ListarMascotas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ListarMascotas";
            this.Load += new System.EventHandler(this.ListarMascotas_Load_1);
            this.ResumeLayout(false);

        }

        private void ListarMascotas_Load_1(object sender, EventArgs e)
        {

        }
    }
}
