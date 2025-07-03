
namespace MiAppVeterinaria
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegistrarMascota = new System.Windows.Forms.Button();
            this.btnRegistrarConsulta = new System.Windows.Forms.Button();
            this.btnAsignarTurno = new System.Windows.Forms.Button();
            this.btnConsultarHistorial = new System.Windows.Forms.Button();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.btnRegistrarMascota);
            this.flowLayoutPanel1.Controls.Add(this.btnRegistrarConsulta);
            this.flowLayoutPanel1.Controls.Add(this.btnAsignarTurno);
            this.flowLayoutPanel1.Controls.Add(this.btnConsultarHistorial);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 181);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegistrarMascota
            // 
            this.btnRegistrarMascota.Location = new System.Drawing.Point(3, 190);
            this.btnRegistrarMascota.Name = "btnRegistrarMascota";
            this.btnRegistrarMascota.Size = new System.Drawing.Size(222, 44);
            this.btnRegistrarMascota.TabIndex = 1;
            this.btnRegistrarMascota.Text = "Registrar Mascota";
            this.btnRegistrarMascota.UseVisualStyleBackColor = true;
            this.btnRegistrarMascota.Click += new System.EventHandler(this.btnRegistrarMascota_Click);
            // 
            // btnRegistrarConsulta
            // 
            this.btnRegistrarConsulta.Location = new System.Drawing.Point(3, 240);
            this.btnRegistrarConsulta.Name = "btnRegistrarConsulta";
            this.btnRegistrarConsulta.Size = new System.Drawing.Size(224, 44);
            this.btnRegistrarConsulta.TabIndex = 2;
            this.btnRegistrarConsulta.Text = "Registrar Consulta";
            this.btnRegistrarConsulta.UseVisualStyleBackColor = true;
            this.btnRegistrarConsulta.Click += new System.EventHandler(this.btnRegistrarConsulta_Click);
            // 
            // btnAsignarTurno
            // 
            this.btnAsignarTurno.Location = new System.Drawing.Point(3, 290);
            this.btnAsignarTurno.Name = "btnAsignarTurno";
            this.btnAsignarTurno.Size = new System.Drawing.Size(224, 44);
            this.btnAsignarTurno.TabIndex = 3;
            this.btnAsignarTurno.Text = "Asignar turno";
            this.btnAsignarTurno.UseVisualStyleBackColor = true;
            this.btnAsignarTurno.Click += new System.EventHandler(this.btnAsignarTurno_Click);
            // 
            // btnConsultarHistorial
            // 
            this.btnConsultarHistorial.Location = new System.Drawing.Point(3, 340);
            this.btnConsultarHistorial.Name = "btnConsultarHistorial";
            this.btnConsultarHistorial.Size = new System.Drawing.Size(224, 44);
            this.btnConsultarHistorial.TabIndex = 4;
            this.btnConsultarHistorial.Text = "Consulta historial";
            this.btnConsultarHistorial.UseVisualStyleBackColor = true;
            // 
            // container
            // 
            this.container.ColumnCount = 3;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.container.Location = new System.Drawing.Point(245, 0);
            this.container.Name = "container";
            this.container.RowCount = 1;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.container.Size = new System.Drawing.Size(555, 450);
            this.container.TabIndex = 1;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.container_Paint_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.container);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegistrarMascota;
        private System.Windows.Forms.Button btnRegistrarConsulta;
        private System.Windows.Forms.Button btnAsignarTurno;
        private System.Windows.Forms.Button btnConsultarHistorial;
        private System.Windows.Forms.TableLayoutPanel container;
    }
}