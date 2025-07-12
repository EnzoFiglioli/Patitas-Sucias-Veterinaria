using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;
using MiAppVeterinaria.Layout.Buttons;
using MiAppVeterinaria.Repository;
using MiAppVeterinaria.Services;
using MiAppVeterinaria.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MiAppVeterinaria
{
    public partial class Form2 : Form
    {
        private TableLayoutPanel containerFlow;
        private FlowLayoutPanel flow;
        private readonly DuenioRepository duenioRepository = new DuenioRepository();
        private readonly MascotaService mascotaService = new MascotaService();
        private readonly VeterinarioService veterinarioService = new VeterinarioService();
        private readonly ConsultaService consultaService= new ConsultaService();


        public Form2(string rol)
        {
            InitializeComponent();
            containerFlow = this.container;



            btnListarMascotas.Click += buttonListarMascotas_Click;

            flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.Dock = DockStyle.Fill;
            flow.AutoScroll = true;
            flow.AutoSize = true;

            switch (rol)
            {
                case "Administrador":
                    Button btnRegistrarVeterinario = crearBoton("Registrar Veterinario");
                    Button btnEditarVeterinario = crearBoton("Editar Veterinario");
                    Button btnRegistrarDuenio = crearBoton("Registrar Dueño");

                    this.btnAsignarTurno.Visible = false;
                    this.btnRegistrarConsulta.Visible = false;
                    this.btnRegistrarMascota.Visible = false;
                    this.btnConsultarHistorial.Visible = false;
                    this.btnListarMascotas.Visible = false;

                    flowLayoutPanel1.Controls.Add(btnRegistrarVeterinario);
                    flowLayoutPanel1.Controls.Add(btnEditarVeterinario);
                    flowLayoutPanel1.Controls.Add(btnRegistrarDuenio);
                    break;

                case "Recepcion":
                    this.btnAsignarTurno.Visible = false;
                    this.btnRegistrarConsulta.Visible = false;
                    this.btnRegistrarMascota.Visible = true;
                    this.btnConsultarHistorial.Visible = false;
                    this.btnListarMascotas.Visible = true;

                    Button btnAgregarDuenio = crearBoton("Agregar Dueño");
                    btnAgregarDuenio.Click += btnAgregarDueño_Click;
                    flowLayoutPanel1.Controls.Add(btnAgregarDuenio);
                    break;

                case "Veterinario":
                    this.btnAsignarTurno.Visible = false;
                    this.btnRegistrarConsulta.Visible = false;
                    break;
            }
        }

        // Crear ComboBox para enumeraciones
        public static Control CrearSelector(Type enumType, string grupos)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("Debe ser un tipo enum");

            Panel panelCampo = new Panel { Height = 60, Dock = DockStyle.Top };

            Label lbl = new Label
            {
                Text = grupos,
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 0),
                AutoSize = true
            };

            ComboBox combo = new ComboBox
            {
                DataSource = Enum.GetValues(enumType),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 350,
                Location = new Point(0, lbl.Height + 5),
                Name = "cmb" + grupos.Replace(" ", ""),
                Tag = grupos.ToLower()
            };

            panelCampo.Resize += (s, e) => combo.Width = panelCampo.ClientSize.Width;

            panelCampo.Controls.Add(lbl);
            panelCampo.Controls.Add(combo);

            return panelCampo;
        }

        // Crear botón con estilo
        private Button crearBoton(string btnName)
        {
            string nombre = btnName.Replace(" ", "");
            return new Button
            {
                Font = new Font("Segoe UI", 9),
                Text = btnName,
                Location = new Point(3, 290),
                Name = "btn" + nombre,
                Size = new Size(224, 44),
                TabIndex = 3,
                UseVisualStyleBackColor = true
            };
        }

        // Crear campo de texto con label
        private Control CrearCampo(string textoLabel)
        {
            Panel panelCampo = new Panel { Height = 60, Dock = DockStyle.Top };

            Label lbl = new Label
            {
                Text = textoLabel,
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 0),
                AutoSize = true
            };

            TextBox txt = new TextBox
            {
                Location = new Point(0, lbl.Height + 5),
                Width = 350,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Name = "txt" + textoLabel.Replace(" ", "")
            };

            panelCampo.Resize += (s, e) => txt.Width = panelCampo.ClientSize.Width;

            panelCampo.Controls.Add(lbl);
            panelCampo.Controls.Add(txt);

            return panelCampo;
        }

        // Registrar Mascota

        private ComboBox SelectorDuenios()
        {

            Label lbl = new Label
            {
                Text = "Dueño de mascota",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 0),
                AutoSize = true
            };

            var listaDuenio = duenioRepository.ObtenerDuenios();
            ComboBox cmb = new ComboBox();
            cmb.DataSource = listaDuenio;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Width = 350;
            cmb.Name = "cmbDueño";
            cmb.Location = new Point(0, lbl.Height + 5);
            cmb.DisplayMember = "NombreCompleto";
            cmb.ValueMember = "Id";
            return cmb;
        }

        private void btnRegistrarMascota_Click(object sender, EventArgs e)
        {
            var repo = new RazaEspecieRepository();

            containerFlow.Controls.Clear();
            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            flow.Controls.Clear();

            flow.Controls.Add(SelectorDuenios());

            Button btnRegistrar = BtnRegistrarDuenio.Crear();
            btnRegistrar.Click += (s, e2) => new RegistrarCliente().Show();
            flow.Controls.Add(btnRegistrar);

            Button btnActualizar = BtnRegistrarDuenio.Actualizar();
            btnActualizar.Click += (s, e2) => duenioRepository.ObtenerDuenios();
            flow.Controls.Add(btnActualizar);

            flow.Controls.Add(CrearCampo("Nombre Mascota"));


            // ComboBox especie
            Label lblEspecie = new Label { Text = "Especie:" };
            ComboBox cmbEspecie = new ComboBox { Width = 350, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEspecie.DataSource = repo.ObtenerEspecies();
            cmbEspecie.DisplayMember = "Nombre";
            cmbEspecie.ValueMember = "Id";

            // ComboBox raza
            Label lblRaza = new Label { Text = "Raza:" };

            ComboBox cmbRaza = new ComboBox { Width = 350, DropDownStyle = ComboBoxStyle.DropDownList };

            // Evento para actualizar razas según especie seleccionada
            cmbEspecie.SelectedIndexChanged += (s, e) =>
            {
                int idEspecie = Convert.ToInt32(cmbEspecie.SelectedValue);
                cmbRaza.DataSource = repo.ObtenerRazasPorEspecie(idEspecie);
                cmbRaza.DisplayMember = "Nombre";
                cmbRaza.ValueMember = "Id";
            };


            flow.Controls.Add(lblEspecie);
            flow.Controls.Add(cmbEspecie);
            flow.Controls.Add(lblRaza);
            flow.Controls.Add(cmbRaza);

            flow.Controls.Add(CrearCampo("Edad"));
            flow.Controls.Add(CrearCampo("Peso"));

            Button btnGuardar = new Button
            {
                Text = "Guardar",
                Width = 200,
                Height = 35,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnGuardar.Click += (s, e2) =>
            {
                try
                {
                    var cmbDuenio = (ComboBox)flow.Controls.Find("cmbDueño", true)[0];
                    // si usás combo de dueños
                    TextBox txtEdad = (TextBox)flow.Controls.Find("txtEdad", true)[0];
                    TextBox txtPeso = (TextBox)flow.Controls.Find("txtPeso", true)[0];

                    if (cmbEspecie.SelectedItem == null || cmbRaza.SelectedItem == null || !int.TryParse(txtEdad.Text, out int edad) || !decimal.TryParse(txtPeso.Text, out decimal peso))
                    {
                        MessageBox.Show("Completá todos los campos correctamente.");
                        return;
                    }

                    int especie = Convert.ToInt32(cmbEspecie.SelectedValue);
                    int raza = Convert.ToInt32(cmbRaza.SelectedValue);
                    TextBox nombre = (TextBox)flow.Controls.Find("txtNombreMascota", true)[0];

                    MascotaDTO mascota = new MascotaDTO
                    {
                        DuenioId = Convert.ToInt32(cmbDuenio.SelectedValue),
                        EspecieId = especie,
                        RazaId = raza,
                        Edad = edad,
                        Peso = peso,
                        Nombre = nombre.Text
                    };

                    string resultado = mascotaService.CreateMascota(mascota);

                    if (resultado == "Mascota creada exitosamente")
                    {
                        MessageBox.Show($"Especie: {especie}\nRaza: {raza}\nEdad: {edad}\nPeso: {peso}", "Mascota guardada");
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            };

            flow.Controls.Add(btnGuardar);
            containerFlow.Controls.Add(flow, 1, 0);
        }


        // Registrar Consulta (sin guardar aún)
        private void btnRegistrarConsulta_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();
            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            flow.Controls.Clear();

            // Label y ComboBox para mascota
            Label lbl = new Label
            {
                Text = "Mascota",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 0),
                AutoSize = true
            };

            var mascotas = mascotaService.GetMascotas();
            ComboBox selectorMascota = new ComboBox
            {
                DataSource = mascotas,
                DisplayMember = "Nombre", // o lo que quieras mostrar
                ValueMember = "Id",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 350,
                Location = new Point(0, lbl.Height + 5)
            };

            flow.Controls.Add(lbl);
            flow.Controls.Add(selectorMascota);

            // Sintomas
            var listaSintomas = new List<string> {
        "Fiebre", "Pérdida de apetito", "Letargo", "Vómitos", "Diarrea",
        "Estornudos", "Tos", "Picazón o rascado excesivo", "Heridas visibles",
        "Cojeo", "Ojos llorosos", "Cambios de comportamiento", "Respiración dificultosa",
        "Babeo excesivo", "Caída del pelo"
    };

            Label elegirSintoma = new Label { Text = "Elegir síntoma:", AutoSize = true };
            ComboBox cmbSintomas = new ComboBox
            {
                DataSource = listaSintomas,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 350,
                Location = new Point(0, lbl.Height + 5),
                ValueMember = "Id"
            };
            CheckBox checkSintoma = new CheckBox
            {
                Text = "El síntoma no está en la lista",
                Checked = false,
                AutoSize = true
            };

            flow.Controls.Add(elegirSintoma);
            flow.Controls.Add(cmbSintomas);
            flow.Controls.Add(checkSintoma);

            // Cambiar entre combo y textbox según el checkbox
            checkSintoma.CheckedChanged += (s, eArgs) =>
            {
                cmbSintomas.Enabled = !checkSintoma.Checked;

                if (checkSintoma.Checked)
                {
                    if (!flow.Controls.ContainsKey("txtSintomaManual"))
                    {
                        var txtSintomaManual = new TextBox
                        {
                            Name = "txtSintomaManual",
                            Width = 350,
                            PlaceholderText = "Describa el síntoma"
                        };

                        int index = flow.Controls.IndexOf(checkSintoma);
                        flow.Controls.Add(txtSintomaManual);
                        flow.Controls.SetChildIndex(txtSintomaManual, index + 1);
                    }
                }
                else
                {
                    var txtSintomaManual = flow.Controls.Find("txtSintomaManual", false).FirstOrDefault();
                    if (txtSintomaManual != null)
                    {
                        flow.Controls.Remove(txtSintomaManual);
                        txtSintomaManual.Dispose();
                    }
                }
            };

            // Emergencia (CheckBox)
            CheckBox checkEmergencia = new CheckBox
            {
                Text = "¿Es una emergencia?",
                AutoSize = true
            };
            flow.Controls.Add(checkEmergencia);

            // Veterinario
            Label lblVeterinario = new Label { Text = "Veterinario:", AutoSize = true };

            var listarVetes = veterinarioService.ListarVeterinarios();
            ComboBox cmbVeterinarios = new ComboBox
            {
                DataSource = listarVetes,
                DisplayMember = "NombreCompleto",
                ValueMember = "Id",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 350,
                Location = new Point(0, lbl.Height + 5)
            };

            flow.Controls.Add(lblVeterinario);
            flow.Controls.Add(cmbVeterinarios);

            // Botón guardar
            Button btnGuardar = new Button
            {
                Text = "Guardar Consulta",
                Width = 200,
                Height = 35,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnGuardar.Click += (s, e2) =>
            {
                // Obtener datos
                string sintomaElegido = checkSintoma.Checked
                    ? flow.Controls.Find("txtSintomaManual", false).FirstOrDefault()?.Text
                    : cmbSintomas.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(sintomaElegido))
                {
                    MessageBox.Show("Debe ingresar o seleccionar un síntoma.");
                    return;
                }

                int mascotaIndex = Convert.ToInt32(selectorMascota.SelectedValue);
                int veterinarioIndex = Convert.ToInt32(cmbVeterinarios.SelectedValue);

                if (mascotaIndex < 0 || veterinarioIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una mascota y un veterinario.");
                    return;
                }

                var mascotaId = mascotaIndex;
                var veterinarioId = veterinarioIndex;

                var consultaDTO = new ConsultaDTO
                {
                    MascotaId = mascotaId,
                    Sintomas = sintomaElegido,
                    Emergencia = checkEmergencia.Checked,
                    VeterinarioId = veterinarioId
                };

                // Guardar
                consultaService.Crear(consultaDTO);
                MessageBox.Show("Consulta guardada exitosamente");
            };

            flow.Controls.Add(btnGuardar);
            containerFlow.Controls.Add(flow, 1, 0);
        }


        // Asignar turno
        private void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();
            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            flow.Controls.Clear();
            flow.Controls.Add(CrearCampo("Dueño"));
            flow.Controls.Add(CrearCampo("Mascota"));
            flow.Controls.Add(CrearCampo("Fecha"));
            flow.Controls.Add(CrearCampo("Hora"));
            flow.Controls.Add(CrearCampo("Veterinario"));

            Button btnGuardar = new Button
            {
                Text = "Asignar Turno",
                Width = 200,
                Height = 35,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnGuardar.Click += (s, e2) =>
            {
                MessageBox.Show("Turno asignado exitosamente");
            };

            flow.Controls.Add(btnGuardar);
            containerFlow.Controls.Add(flow, 1, 0);
        }

        private void buttonListarMascotas_Click(object sender, EventArgs e)
        {
            ListarMascotas lista = new ListarMascotas();
            lista.ShowDialog();
        }

        // Agregar Dueño - Vista
        private void btnAgregarDueño_Click(object sender, EventArgs e)
        {
            containerFlow.Controls.Clear();
            containerFlow.BackColor = Color.WhiteSmoke;
            containerFlow.Padding = new Padding(20);

            flow.Controls.Clear();
            flow.Controls.Add(CrearCampo("Nombre Dueño"));
            flow.Controls.Add(CrearCampo("Apellido Dueño"));
            flow.Controls.Add(CrearCampo("Contacto"));

            Button btnGuardar = new Button
            {
                Name = "btnGuardarDuenio",
                Text = "Guardar",
                Width = 200,
                Height = 35,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.Click += btnGuardarDuenio_Click;

            flow.Controls.Add(btnGuardar);
            containerFlow.Controls.Add(flow, 1, 0);
        }

        // Guardar Dueño - Funcionalidad
        private void btnGuardarDuenio_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txtNombre = (TextBox)flow.Controls.Find("txtNombreDueño", true)[0];
                TextBox txtApellido = (TextBox)flow.Controls.Find("txtApellidoDueño", true)[0];
                TextBox txtContacto = (TextBox)flow.Controls.Find("txtContacto", true)[0];

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string contacto = txtContacto.Text;

                if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido) && !string.IsNullOrWhiteSpace(contacto))
                {
                    MessageBox.Show($"Nombre: {nombre}\nApellido: {apellido}\nContacto: {contacto}", "Dueño guardado");

                    try
                    {
                        using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("crear_duenio", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@i_nombre", nombre);
                                cmd.Parameters.AddWithValue("@i_apellido", apellido);
                                cmd.Parameters.AddWithValue("@i_contacto", contacto);

                                int filasAfectadas = cmd.ExecuteNonQuery();

                                if (filasAfectadas > 0)
                                {
                                    MessageBox.Show("¡Se agregó exitosamente!", "Éxito");
                                }
                                else
                                {
                                    MessageBox.Show("No se agregó ningún registro.", "Advertencia");
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Por favor completá todos los campos", "Campos incompletos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el dueño: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e) { }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;         // Cancela el cierre
            this.Hide();             // Oculta Form2
            new Form1().Show();      // Muestra Form1
        }


        // Eventos sin uso actual
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void container_Paint(object sender, PaintEventArgs e) { }
        private void container_Paint_1(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void BtnGuardar_Click(object sender, EventArgs e) => throw new NotImplementedException();
    }
}
