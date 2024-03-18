namespace SistemaDeReservas
{
    partial class Frm_ABM_Habitacion
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
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridHabitacion = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitacion)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(508, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 37);
            this.button4.TabIndex = 54;
            this.button4.Text = "Baja Habitacion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(526, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 56;
            this.label4.Text = "Habitaciones";
            // 
            // dataGridHabitacion
            // 
            this.dataGridHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabitacion.Location = new System.Drawing.Point(508, 49);
            this.dataGridHabitacion.Name = "dataGridHabitacion";
            this.dataGridHabitacion.RowHeadersWidth = 51;
            this.dataGridHabitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHabitacion.Size = new System.Drawing.Size(467, 132);
            this.dataGridHabitacion.TabIndex = 57;
            this.dataGridHabitacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHabitacion_RowEnter);
            this.dataGridHabitacion.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHabitacion_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.Label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.dataGridHabitacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.Button2);
            this.groupBox2.Controls.Add(this.Label6);
            this.groupBox2.Controls.Add(this.TextBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-5, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(994, 328);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simple",
            "Doble"});
            this.comboBox1.Location = new System.Drawing.Point(194, 187);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 28);
            this.comboBox1.TabIndex = 59;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(39, 187);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(149, 20);
            this.Label9.TabIndex = 58;
            this.Label9.Text = "Tipo de Habitacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "ValorNoche";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(194, 127);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(300, 26);
            this.textBox4.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 37);
            this.button3.TabIndex = 29;
            this.button3.Text = "Modificar Habitacion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(195, 95);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(299, 26);
            this.textBox6.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Capacidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Piso";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(198, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(299, 26);
            this.textBox5.TabIndex = 19;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(111, 245);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(188, 37);
            this.Button2.TabIndex = 18;
            this.Button2.Text = "Agregar Habitacion";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(27, 37);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(153, 20);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Numero Habitacion";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(198, 31);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(300, 26);
            this.TextBox1.TabIndex = 11;
            // 
            // Frm_ABM_Habitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 485);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_ABM_Habitacion";
            this.Text = "Frm_ABM_Habitacion";
            this.Load += new System.EventHandler(this.Frm_ABM_Habitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitacion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dataGridHabitacion;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.TextBox textBox6;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label Label9;
    }
}