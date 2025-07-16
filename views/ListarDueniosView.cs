using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using MiAppVeterinaria.Services;
using MiAppVeterinaria.DTO;
using MiAppVeterinaria.Models;
using MiAppVeterinaria.Repository;


namespace MiAppVeterinaria.Views
{
    public class ListarDueniosView : UserControl
    {
        private DataGridView dgvDueños;

        private readonly DuenioService duenioService = new DuenioService();

        private List<Duenio> dueñosList;

        private string rolUsuario;

        public ListarDueniosView(string rol)
        {
            rolUsuario = rol;
            InicializarVista();
        }

        private void InicializarVista()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                RowCount = 3,
                ColumnCount = 1,
                AutoScroll = true
            };

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Header
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Formulario
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Tabla

            layout.Controls.Add(ConstruirHeader(), 0, 0);
            layout.Controls.Add(ConstruirTabla(), 0, 2);

            this.Controls.Add(layout);
        }

        private Control ConstruirHeader()
        {
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Margin = new Padding(0, 0, 0, 10)
            };

            panel.Controls.Add(new Label
            {
                Text = "Listados de dueños",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                AutoSize = true
            });

            panel.Controls.Add(new Label
            {
                Text = "Podés ver el registro de cada dueño",
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            });

            return panel;
        }

        private Control ConstruirTabla()
        {
            dgvDueños = new DataGridView
            {
                Height = 300,
                Dock = DockStyle.Top,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.WhiteSmoke,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dueñosList = duenioService.ObtenerDuenios();
            dgvDueños.DataSource = dueñosList;
           
            return dgvDueños;
        }
    }
}
