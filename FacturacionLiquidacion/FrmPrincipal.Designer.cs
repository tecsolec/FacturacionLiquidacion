namespace FacturacionLiquidacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSubirLiquidacion = new System.Windows.Forms.Button();
            this.dGVLiquidaciones = new System.Windows.Forms.DataGridView();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.txtHoja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroliquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piscina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteMBA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empacadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbstotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVLiquidaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubirLiquidacion
            // 
            this.btnSubirLiquidacion.Location = new System.Drawing.Point(335, 5);
            this.btnSubirLiquidacion.Name = "btnSubirLiquidacion";
            this.btnSubirLiquidacion.Size = new System.Drawing.Size(75, 23);
            this.btnSubirLiquidacion.TabIndex = 0;
            this.btnSubirLiquidacion.Text = "Subir Liquidacion";
            this.btnSubirLiquidacion.UseVisualStyleBackColor = true;
            this.btnSubirLiquidacion.Click += new System.EventHandler(this.btnSubirLiquidacion_Click);
            // 
            // dGVLiquidaciones
            // 
            this.dGVLiquidaciones.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVLiquidaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVLiquidaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.numeroliquidacion,
            this.piscina,
            this.ciclo,
            this.loteMBA,
            this.empacadora,
            this.op,
            this.lbstotales});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVLiquidaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVLiquidaciones.Location = new System.Drawing.Point(13, 93);
            this.dGVLiquidaciones.Name = "dGVLiquidaciones";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVLiquidaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVLiquidaciones.Size = new System.Drawing.Size(674, 289);
            this.dGVLiquidaciones.TabIndex = 1;
            this.dGVLiquidaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVLiquidaciones_CellClick);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(12, 7);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(118, 20);
            this.txtArchivo.TabIndex = 2;
            this.txtArchivo.Text = "Subir Archivo de Guias";
            // 
            // txtHoja
            // 
            this.txtHoja.Location = new System.Drawing.Point(211, 7);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(118, 20);
            this.txtHoja.TabIndex = 3;
            this.txtHoja.Text = "Hoja1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hoja a Leer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta:";
            // 
            // cbFilterEstado
            // 
            this.cbFilterEstado.FormattingEnabled = true;
            this.cbFilterEstado.Items.AddRange(new object[] {
            "Todos",
            "Liquidados",
            "Facturados"});
            this.cbFilterEstado.Location = new System.Drawing.Point(546, 59);
            this.cbFilterEstado.Name = "cbFilterEstado";
            this.cbFilterEstado.Size = new System.Drawing.Size(121, 21);
            this.cbFilterEstado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Liquidaciones";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(545, 7);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(141, 20);
            this.dtpDesde.TabIndex = 9;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(546, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(141, 20);
            this.dtpHasta.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estado Liq:";
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            // 
            // numeroliquidacion
            // 
            this.numeroliquidacion.DataPropertyName = "numeroliquidacion";
            this.numeroliquidacion.HeaderText = "# Liq.";
            this.numeroliquidacion.Name = "numeroliquidacion";
            // 
            // piscina
            // 
            this.piscina.DataPropertyName = "piscina";
            this.piscina.HeaderText = "Piscina";
            this.piscina.Name = "piscina";
            // 
            // ciclo
            // 
            this.ciclo.DataPropertyName = "ciclo";
            this.ciclo.HeaderText = "Ciclo";
            this.ciclo.Name = "ciclo";
            // 
            // loteMBA
            // 
            this.loteMBA.DataPropertyName = "loteMBA";
            this.loteMBA.HeaderText = "Lote";
            this.loteMBA.Name = "loteMBA";
            // 
            // empacadora
            // 
            this.empacadora.DataPropertyName = "empacadora";
            this.empacadora.HeaderText = "Empacadora";
            this.empacadora.Name = "empacadora";
            // 
            // op
            // 
            this.op.DataPropertyName = "op";
            this.op.HeaderText = "Ord. Prodcuccion";
            this.op.Name = "op";
            // 
            // lbstotales
            // 
            this.lbstotales.DataPropertyName = "lbstotales";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.lbstotales.DefaultCellStyle = dataGridViewCellStyle2;
            this.lbstotales.HeaderText = "LBS";
            this.lbstotales.Name = "lbstotales";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 394);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFilterEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHoja);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.dGVLiquidaciones);
            this.Controls.Add(this.btnSubirLiquidacion);
            this.Name = "FrmPrincipal";
            this.Text = "Facturación de Liquidaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dGVLiquidaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubirLiquidacion;
        private System.Windows.Forms.DataGridView dGVLiquidaciones;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.TextBox txtHoja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroliquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn piscina;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteMBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn empacadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbstotales;
    }
}

