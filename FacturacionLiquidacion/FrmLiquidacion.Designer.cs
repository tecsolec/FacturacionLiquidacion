namespace FacturacionLiquidacion
{
    partial class FrmLiquidacion
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
            this.lblLiquidacion = new System.Windows.Forms.Label();
            this.lblEmpacadora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panProducto = new System.Windows.Forms.Panel();
            this.btnLimpiarDetalle = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.cbTalla = new System.Windows.Forms.ComboBox();
            this.cbClase = new System.Windows.Forms.ComboBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.cbEspecie = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLiquidacion = new System.Windows.Forms.TextBox();
            this.cbEmpacadora = new System.Windows.Forms.ComboBox();
            this.cbBodegaSalida = new System.Windows.Forms.ComboBox();
            this.dtpFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.tbEntero = new System.Windows.Forms.TextBox();
            this.tbCola = new System.Windows.Forms.TextBox();
            this.tbBasura = new System.Windows.Forms.TextBox();
            this.tbSobrCC = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.codProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.itemEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDiferencia = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLiquidacion
            // 
            this.lblLiquidacion.AutoSize = true;
            this.lblLiquidacion.Location = new System.Drawing.Point(9, 13);
            this.lblLiquidacion.Name = "lblLiquidacion";
            this.lblLiquidacion.Size = new System.Drawing.Size(61, 13);
            this.lblLiquidacion.TabIndex = 0;
            this.lblLiquidacion.Text = "Liquidacion";
            // 
            // lblEmpacadora
            // 
            this.lblEmpacadora.AutoSize = true;
            this.lblEmpacadora.Location = new System.Drawing.Point(9, 36);
            this.lblEmpacadora.Name = "lblEmpacadora";
            this.lblEmpacadora.Size = new System.Drawing.Size(67, 13);
            this.lblEmpacadora.TabIndex = 1;
            this.lblEmpacadora.Text = "Empacadora";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bodega Salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Basura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cola";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Entero";
            // 
            // panProducto
            // 
            this.panProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panProducto.Controls.Add(this.btnLimpiarDetalle);
            this.panProducto.Controls.Add(this.btnAgregarItem);
            this.panProducto.Controls.Add(this.tbCantidad);
            this.panProducto.Controls.Add(this.cbTalla);
            this.panProducto.Controls.Add(this.cbClase);
            this.panProducto.Controls.Add(this.cbTipo);
            this.panProducto.Controls.Add(this.cbEspecie);
            this.panProducto.Controls.Add(this.label11);
            this.panProducto.Controls.Add(this.label7);
            this.panProducto.Controls.Add(this.label10);
            this.panProducto.Controls.Add(this.label8);
            this.panProducto.Controls.Add(this.label9);
            this.panProducto.Location = new System.Drawing.Point(12, 134);
            this.panProducto.Name = "panProducto";
            this.panProducto.Size = new System.Drawing.Size(604, 93);
            this.panProducto.TabIndex = 8;
            // 
            // btnLimpiarDetalle
            // 
            this.btnLimpiarDetalle.Location = new System.Drawing.Point(317, 61);
            this.btnLimpiarDetalle.Name = "btnLimpiarDetalle";
            this.btnLimpiarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarDetalle.TabIndex = 20;
            this.btnLimpiarDetalle.Text = "Limpiar";
            this.btnLimpiarDetalle.UseVisualStyleBackColor = true;
            this.btnLimpiarDetalle.Click += new System.EventHandler(this.btnLimpiarDetalle_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(148, 61);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarItem.TabIndex = 19;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(243, 34);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(121, 20);
            this.tbCantidad.TabIndex = 17;
            // 
            // cbTalla
            // 
            this.cbTalla.FormattingEnabled = true;
            this.cbTalla.Location = new System.Drawing.Point(56, 34);
            this.cbTalla.Name = "cbTalla";
            this.cbTalla.Size = new System.Drawing.Size(121, 21);
            this.cbTalla.TabIndex = 18;
            // 
            // cbClase
            // 
            this.cbClase.FormattingEnabled = true;
            this.cbClase.Location = new System.Drawing.Point(435, 4);
            this.cbClase.Name = "cbClase";
            this.cbClase.Size = new System.Drawing.Size(121, 21);
            this.cbClase.TabIndex = 17;
            this.cbClase.SelectedValueChanged += new System.EventHandler(this.cbClase_SelectedValueChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(243, 4);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 15;
            this.cbTipo.SelectedValueChanged += new System.EventHandler(this.cbTipo_SelectedValueChanged);
            // 
            // cbEspecie
            // 
            this.cbEspecie.FormattingEnabled = true;
            this.cbEspecie.Location = new System.Drawing.Point(56, 4);
            this.cbEspecie.Name = "cbEspecie";
            this.cbEspecie.Size = new System.Drawing.Size(121, 21);
            this.cbEspecie.TabIndex = 14;
            this.cbEspecie.SelectedValueChanged += new System.EventHandler(this.cbEspecie_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Talla";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Especie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Clase";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(195, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tipo";
            // 
            // tbLiquidacion
            // 
            this.tbLiquidacion.Location = new System.Drawing.Point(93, 10);
            this.tbLiquidacion.Name = "tbLiquidacion";
            this.tbLiquidacion.ReadOnly = true;
            this.tbLiquidacion.Size = new System.Drawing.Size(143, 20);
            this.tbLiquidacion.TabIndex = 9;
            // 
            // cbEmpacadora
            // 
            this.cbEmpacadora.FormattingEnabled = true;
            this.cbEmpacadora.Location = new System.Drawing.Point(93, 33);
            this.cbEmpacadora.Name = "cbEmpacadora";
            this.cbEmpacadora.Size = new System.Drawing.Size(143, 21);
            this.cbEmpacadora.TabIndex = 10;
            // 
            // cbBodegaSalida
            // 
            this.cbBodegaSalida.FormattingEnabled = true;
            this.cbBodegaSalida.Location = new System.Drawing.Point(93, 57);
            this.cbBodegaSalida.Name = "cbBodegaSalida";
            this.cbBodegaSalida.Size = new System.Drawing.Size(143, 21);
            this.cbBodegaSalida.TabIndex = 11;
            // 
            // dtpFechaLiquidacion
            // 
            this.dtpFechaLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiquidacion.Location = new System.Drawing.Point(93, 81);
            this.dtpFechaLiquidacion.Name = "dtpFechaLiquidacion";
            this.dtpFechaLiquidacion.Size = new System.Drawing.Size(143, 20);
            this.dtpFechaLiquidacion.TabIndex = 12;
            // 
            // tbEntero
            // 
            this.tbEntero.Location = new System.Drawing.Point(318, 10);
            this.tbEntero.Name = "tbEntero";
            this.tbEntero.Size = new System.Drawing.Size(143, 20);
            this.tbEntero.TabIndex = 13;
            // 
            // tbCola
            // 
            this.tbCola.Location = new System.Drawing.Point(318, 56);
            this.tbCola.Name = "tbCola";
            this.tbCola.Size = new System.Drawing.Size(143, 20);
            this.tbCola.TabIndex = 14;
            // 
            // tbBasura
            // 
            this.tbBasura.Location = new System.Drawing.Point(318, 79);
            this.tbBasura.Name = "tbBasura";
            this.tbBasura.Size = new System.Drawing.Size(143, 20);
            this.tbBasura.TabIndex = 15;
            // 
            // tbSobrCC
            // 
            this.tbSobrCC.Location = new System.Drawing.Point(318, 33);
            this.tbSobrCC.Name = "tbSobrCC";
            this.tbSobrCC.Size = new System.Drawing.Size(143, 20);
            this.tbSobrCC.TabIndex = 16;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(489, 8);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(127, 23);
            this.btnGrabar.TabIndex = 21;
            this.btnGrabar.Text = "Grabar y Salir";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(489, 37);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(127, 23);
            this.btnTerminar.TabIndex = 22;
            this.btnTerminar.Text = "Terminar Liquidacion";
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // dgvReceta
            // 
            this.dgvReceta.AllowUserToAddRows = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codProducto,
            this.detalle,
            this.cantidad,
            this.precio,
            this.itemModificar,
            this.itemEliminar});
            this.dgvReceta.Location = new System.Drawing.Point(12, 233);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.Size = new System.Drawing.Size(604, 236);
            this.dgvReceta.TabIndex = 23;
            this.dgvReceta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceta_CellClick);
            // 
            // codProducto
            // 
            this.codProducto.DataPropertyName = "codProducto";
            this.codProducto.HeaderText = "Cod. Producto";
            this.codProducto.Name = "codProducto";
            // 
            // detalle
            // 
            this.detalle.DataPropertyName = "detalle";
            this.detalle.HeaderText = "Detalle";
            this.detalle.Name = "detalle";
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            // 
            // itemModificar
            // 
            this.itemModificar.DataPropertyName = "Editar";
            this.itemModificar.HeaderText = "Editar";
            this.itemModificar.Name = "itemModificar";
            // 
            // itemEliminar
            // 
            this.itemEliminar.DataPropertyName = "Eliminar";
            this.itemEliminar.HeaderText = "Eliminar";
            this.itemEliminar.Name = "itemEliminar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Diferencia";
            // 
            // tbDiferencia
            // 
            this.tbDiferencia.Location = new System.Drawing.Point(318, 102);
            this.tbDiferencia.Name = "tbDiferencia";
            this.tbDiferencia.Size = new System.Drawing.Size(143, 20);
            this.tbDiferencia.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(257, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Sobr. CC";
            // 
            // FrmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 470);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvReceta);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbDiferencia);
            this.Controls.Add(this.tbSobrCC);
            this.Controls.Add(this.tbBasura);
            this.Controls.Add(this.tbCola);
            this.Controls.Add(this.tbEntero);
            this.Controls.Add(this.dtpFechaLiquidacion);
            this.Controls.Add(this.cbBodegaSalida);
            this.Controls.Add(this.cbEmpacadora);
            this.Controls.Add(this.tbLiquidacion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmpacadora);
            this.Controls.Add(this.lblLiquidacion);
            this.Name = "FrmLiquidacion";
            this.Text = "Ingreso de detalle de liquidación";
            this.Load += new System.EventHandler(this.FrmLiquidacion_Load);
            this.panProducto.ResumeLayout(false);
            this.panProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLiquidacion;
        private System.Windows.Forms.Label lblEmpacadora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panProducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLiquidacion;
        private System.Windows.Forms.ComboBox cbEmpacadora;
        private System.Windows.Forms.ComboBox cbBodegaSalida;
        private System.Windows.Forms.DateTimePicker dtpFechaLiquidacion;
        private System.Windows.Forms.TextBox tbEntero;
        private System.Windows.Forms.TextBox tbCola;
        private System.Windows.Forms.TextBox tbBasura;
        private System.Windows.Forms.TextBox tbSobrCC;
        private System.Windows.Forms.ComboBox cbTalla;
        private System.Windows.Forms.ComboBox cbClase;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbEspecie;
        private System.Windows.Forms.Button btnLimpiarDetalle;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbDiferencia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewButtonColumn itemModificar;
        private System.Windows.Forms.DataGridViewButtonColumn itemEliminar;
    }
}