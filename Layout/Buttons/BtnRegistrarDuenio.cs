using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiAppVeterinaria.Layout.Buttons
{
    public static class BtnRegistrarDuenio
    {
        public static Button Crear(EventHandler onClick = null)
        {
            Button btn = new Button
            {
                Text = "Registrar Dueño",
                Width = 200,
                Height = 35,
                BackColor = Color.LightSkyBlue,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            if (onClick != null)
            {
                btn.Click += onClick;
            }

            return btn;
        }
        public static Button Actualizar(EventHandler onClick = null)
        {
            Button btn = new Button
            {
                Text = "Actualizar Lista",
                Width = 200,
                Height = 35,
                BackColor = Color.LightCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            if(onClick != null)
            {
                btn.Click += onClick;
            }
            return btn;
        }
    }
}
