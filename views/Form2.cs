using MiAppVeterinaria.models;
using System;
using System.Drawing;
using System.Windows.Forms;
using MiAppVeterinaria.repository;

namespace MiAppVeterinaria
{
    public partial class Form2 : Form
    {
        private TableLayoutPanel containerFlow;
        private Repository repo;
        public Form2()
        {
            InitializeComponent();
            containerFlow = this.container;

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        Control CrearSelector(Type enumType, string grupos)
        {
            Panel panelCampo = new Panel();
            panelCampo.Height = 60; // altura suficiente para label + combo
            panelCampo.Dock = DockStyle.Top;

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Debe ser un tipo enum");
            }

            Label lbl = new Label();
            lbl.Text = grupos;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.Location = new Point(0, 0);
            lbl.AutoSize = true;

            ComboBox combo = new ComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.DataSource = Enum.GetValues(enumType);
            combo.Width = 350;
            combo.Location = new Point(0, lbl.Height + 5);

            combo.Name = "cmb" + grupos.Replace(" ", "");
            combo.Tag = grupos.ToLower();

            // Asegura que se ajuste al redimensionar
            panelCampo.Resize += (s, e) =>
            {
                combo.Width = panelCampo.ClientSize.Width;
            };

            panelCampo.Controls.Add(lbl);
            panelCampo.Controls.Add(combo);

            return panelCampo;
        }

        Control CrearCampo(string textoLabel)
        {
            Panel panelCampo = new Panel();
            panelCampo.Height = 60; // altura suficiente para label + textbox
            panelCampo.Dock = DockStyle.Top;  // para que se apile verticalmente en el padre

            Label lbl = new Label();
            lbl.Text = textoLabel;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.Location = new Point(0, 0);
            lbl.AutoSize = true;

            TextBox txt = new TextBox();
            txt.Location = new Point(0, lbl.Height + 5);
            txt.Width = 350; // O ajusta a lo que necesites
            txt.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            txt.Name = "txt" + textoLabel.Replace(" ", "");  // ← nombre identificable

            // Ajustar ancho del textbox al panel cuando se redimensione
            panelCampo.Resize += (s, e) =>
            {
                txt.Width = panelCampo.ClientSize.Width;
            };

            panelCampo.Controls.Add(lbl);
            panelCampo.Controls.Add(txt);

            return panelCampo;

        }
        private void btnRegistrarMascota_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();

            // Contenedor principal
            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            // Layout automático
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoSize = true;
            flow.Dock = DockStyle.Fill;

            // Campos
            flow.Controls.Add(CrearCampo("Raza"));
            flow.Controls.Add(CrearSelector(typeof(Especies), "Especie"));

            flow.Controls.Add(CrearCampo("Dueño"));
            flow.Controls.Add(CrearCampo("Edad"));

            // Botón guardar
            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Width = 200;
            btnGuardar.Height = 35;
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Click += (s, e) =>
            {
                TextBox txtRaza = (TextBox)flow.Controls.Find("txtRaza", true)[0];
                TextBox txtDueño = (TextBox)flow.Controls.Find("txtDueño", true)[0];
                TextBox txtEdad = (TextBox)flow.Controls.Find("txtEdad", true)[0];
                ComboBox cmbEspecie = (ComboBox)flow.Controls.Find("cmbEspecie", true)[0];

                string raza = txtRaza.Text;
                string dueño = txtDueño.Text;
                string edad = txtEdad.Text;
                string especie = cmbEspecie.SelectedItem != null ? cmbEspecie.SelectedItem.ToString() : "No seleccionada";

                MessageBox.Show($"Raza: {raza}\nDueño: {dueño}\nEdad: {edad}\nEspecie: {especie}");

                // Repository.Mascotas.Add(mascota);
                MessageBox.Show("Mascota guardada exitosamente");
            };
            flow.Controls.Add(btnGuardar);

            // Agregar todo al container
            containerFlow.Controls.Add(flow, 1, 0);
        }

        private void btnRegistrarConsulta_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();

            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.Dock = DockStyle.Fill;
            flow.AutoScroll = true;
            flow.AutoSize = true;

            flow.Controls.Add(CrearCampo("Mascota"));
            flow.Controls.Add(CrearCampo("Síntomas"));
            flow.Controls.Add(CrearCampo("Diagnóstico"));
            flow.Controls.Add(CrearCampo("Tratamiento"));
            flow.Controls.Add(CrearCampo("Veterinario"));

            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar Consulta";
            btnGuardar.Width = 200;
            btnGuardar.Height = 35;
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Click += (s, e) =>
            {
                MessageBox.Show("Consulta guardada exitosamente");
            };
            flow.Controls.Add(btnGuardar);

            containerFlow.Controls.Add(flow, 1, 0);
        }

        private void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();

            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.Dock = DockStyle.Fill;
            flow.AutoScroll = true;
            flow.AutoSize = true;

            flow.Controls.Add(CrearCampo("Dueño"));
            flow.Controls.Add(CrearCampo("Mascota"));
            flow.Controls.Add(CrearCampo("Fecha"));
            flow.Controls.Add(CrearCampo("Hora"));
            flow.Controls.Add(CrearCampo("Veterinario"));

            Button btnGuardar = new Button();
            btnGuardar.Text = "Asignar Turno";
            btnGuardar.Width = 200;
            btnGuardar.Height = 35;
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Click += (s, e) =>
            {
                MessageBox.Show("Turno asignado exitosamente");
            };
            flow.Controls.Add(btnGuardar);
            containerFlow.Controls.Add(flow, 1, 0);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void container_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
