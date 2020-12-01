namespace PresentacionDatos
{
    partial class FrmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.Compras = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PtbRegresar = new System.Windows.Forms.PictureBox();
            this.Compritas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PtbRegresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Compritas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.Teal;
            this.btnagregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.ForeColor = System.Drawing.Color.White;
            this.btnagregar.Location = new System.Drawing.Point(665, 63);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(150, 35);
            this.btnagregar.TabIndex = 2;
            this.btnagregar.Text = "Nuevo";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Teal;
            this.btneliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.Location = new System.Drawing.Point(989, 63);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(150, 35);
            this.btneliminar.TabIndex = 4;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 29);
            this.label10.TabIndex = 54;
            this.label10.Text = " Buscar ";
            // 
            // btnmodificar
            // 
            this.btnmodificar.BackColor = System.Drawing.Color.Teal;
            this.btnmodificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnmodificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmodificar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodificar.ForeColor = System.Drawing.Color.White;
            this.btnmodificar.Location = new System.Drawing.Point(827, 63);
            this.btnmodificar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(150, 35);
            this.btnmodificar.TabIndex = 3;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = false;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(93, 64);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(479, 34);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // Compras
            // 
            this.Compras.AutoSize = true;
            this.Compras.BackColor = System.Drawing.Color.Teal;
            this.Compras.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compras.ForeColor = System.Drawing.Color.White;
            this.Compras.Location = new System.Drawing.Point(15, 5);
            this.Compras.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Compras.Name = "Compras";
            this.Compras.Size = new System.Drawing.Size(141, 35);
            this.Compras.TabIndex = 50;
            this.Compras.Text = "COMPRAS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1154, 40);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // PtbRegresar
            // 
            this.PtbRegresar.BackColor = System.Drawing.Color.Teal;
            this.PtbRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PtbRegresar.Image = ((System.Drawing.Image)(resources.GetObject("PtbRegresar.Image")));
            this.PtbRegresar.Location = new System.Drawing.Point(1107, 5);
            this.PtbRegresar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.PtbRegresar.Name = "PtbRegresar";
            this.PtbRegresar.Size = new System.Drawing.Size(32, 32);
            this.PtbRegresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PtbRegresar.TabIndex = 57;
            this.PtbRegresar.TabStop = false;
            this.PtbRegresar.Click += new System.EventHandler(this.PtbRegresar_Click);
            // 
            // Compritas
            // 
            this.Compritas.AllowUserToAddRows = false;
            this.Compritas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Compritas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Compritas.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.Compritas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Compritas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Compritas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Compritas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Compritas.EnableHeadersVisualStyles = false;
            this.Compritas.GridColor = System.Drawing.Color.White;
            this.Compritas.Location = new System.Drawing.Point(15, 123);
            this.Compritas.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Compritas.Name = "Compritas";
            this.Compritas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Compritas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Compritas.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.Compritas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Compritas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Compritas.Size = new System.Drawing.Size(1124, 553);
            this.Compritas.TabIndex = 58;
            this.Compritas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Compritas_CellClick);
            // 
            // FrmCompras
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1154, 692);
            this.ControlBox = false;
            this.Controls.Add(this.Compritas);
            this.Controls.Add(this.PtbRegresar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.Compras);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCompras";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PtbRegresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Compritas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label Compras;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PtbRegresar;
        private System.Windows.Forms.DataGridView Compritas;
    }
}