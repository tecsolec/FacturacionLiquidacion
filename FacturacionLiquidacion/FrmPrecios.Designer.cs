namespace FacturacionLiquidacion
{
    partial class FrmPrecios
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
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.cblClientes = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cblProductos = new System.Windows.Forms.CheckedListBox();
            this.btAgregarCliente = new System.Windows.Forms.Button();
            this.btEliminarCliente = new System.Windows.Forms.Button();
            this.txCodigoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btEliminarProducto = new System.Windows.Forms.Button();
            this.btAgregarProducto = new System.Windows.Forms.Button();
            this.btGuardarPrecios = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txCodigoProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txClaseProducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txTallaProducto = new System.Windows.Forms.TextBox();
            this.cbEspecieProducto = new System.Windows.Forms.ComboBox();
            this.cbTipoProducto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Location = new System.Drawing.Point(12, 167);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.Size = new System.Drawing.Size(919, 252);
            this.dgvPrecios.TabIndex = 0;
            // 
            // cblClientes
            // 
            this.cblClientes.FormattingEnabled = true;
            this.cblClientes.Location = new System.Drawing.Point(12, 26);
            this.cblClientes.Name = "cblClientes";
            this.cblClientes.Size = new System.Drawing.Size(153, 139);
            this.cblClientes.TabIndex = 1;
            this.cblClientes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblClientes_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Productos";
            // 
            // cblProductos
            // 
            this.cblProductos.FormattingEnabled = true;
            this.cblProductos.Location = new System.Drawing.Point(407, 26);
            this.cblProductos.Name = "cblProductos";
            this.cblProductos.Size = new System.Drawing.Size(153, 139);
            this.cblProductos.TabIndex = 3;
            this.cblProductos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblProductos_ItemCheck);
            // 
            // btAgregarCliente
            // 
            this.btAgregarCliente.Location = new System.Drawing.Point(214, 78);
            this.btAgregarCliente.Name = "btAgregarCliente";
            this.btAgregarCliente.Size = new System.Drawing.Size(100, 23);
            this.btAgregarCliente.TabIndex = 5;
            this.btAgregarCliente.Text = "Agregar Cliente";
            this.btAgregarCliente.UseVisualStyleBackColor = true;
            this.btAgregarCliente.Click += new System.EventHandler(this.btAgregarCliente_Click);
            // 
            // btEliminarCliente
            // 
            this.btEliminarCliente.Location = new System.Drawing.Point(214, 111);
            this.btEliminarCliente.Name = "btEliminarCliente";
            this.btEliminarCliente.Size = new System.Drawing.Size(100, 23);
            this.btEliminarCliente.TabIndex = 6;
            this.btEliminarCliente.Text = "Eliminar Cliente";
            this.btEliminarCliente.UseVisualStyleBackColor = true;
            this.btEliminarCliente.Click += new System.EventHandler(this.btEliminarCliente_Click);
            // 
            // txCodigoCliente
            // 
            this.txCodigoCliente.Location = new System.Drawing.Point(265, 28);
            this.txCodigoCliente.Name = "txCodigoCliente";
            this.txCodigoCliente.Size = new System.Drawing.Size(100, 20);
            this.txCodigoCliente.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codigo Cliente:";
            // 
            // btEliminarProducto
            // 
            this.btEliminarProducto.Location = new System.Drawing.Point(814, 111);
            this.btEliminarProducto.Name = "btEliminarProducto";
            this.btEliminarProducto.Size = new System.Drawing.Size(109, 23);
            this.btEliminarProducto.TabIndex = 10;
            this.btEliminarProducto.Text = "Eliminar Producto";
            this.btEliminarProducto.UseVisualStyleBackColor = true;
            this.btEliminarProducto.Click += new System.EventHandler(this.btEliminarProducto_Click);
            // 
            // btAgregarProducto
            // 
            this.btAgregarProducto.Location = new System.Drawing.Point(814, 78);
            this.btAgregarProducto.Name = "btAgregarProducto";
            this.btAgregarProducto.Size = new System.Drawing.Size(109, 23);
            this.btAgregarProducto.TabIndex = 9;
            this.btAgregarProducto.Text = "Agregar Producto";
            this.btAgregarProducto.UseVisualStyleBackColor = true;
            this.btAgregarProducto.Click += new System.EventHandler(this.btAgregarProducto_Click);
            // 
            // btGuardarPrecios
            // 
            this.btGuardarPrecios.Location = new System.Drawing.Point(814, 425);
            this.btGuardarPrecios.Name = "btGuardarPrecios";
            this.btGuardarPrecios.Size = new System.Drawing.Size(117, 23);
            this.btGuardarPrecios.TabIndex = 11;
            this.btGuardarPrecios.Text = "Guardar Precios";
            this.btGuardarPrecios.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Codigo Producto:";
            // 
            // txCodigoProducto
            // 
            this.txCodigoProducto.Location = new System.Drawing.Point(666, 28);
            this.txCodigoProducto.Name = "txCodigoProducto";
            this.txCodigoProducto.Size = new System.Drawing.Size(121, 20);
            this.txCodigoProducto.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(566, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Especie Producto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(566, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tipo Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(566, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Clase Producto:";
            // 
            // txClaseProducto
            // 
            this.txClaseProducto.Location = new System.Drawing.Point(666, 108);
            this.txClaseProducto.Name = "txClaseProducto";
            this.txClaseProducto.Size = new System.Drawing.Size(121, 20);
            this.txClaseProducto.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(566, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Talla Producto:";
            // 
            // txTallaProducto
            // 
            this.txTallaProducto.Location = new System.Drawing.Point(666, 134);
            this.txTallaProducto.Name = "txTallaProducto";
            this.txTallaProducto.Size = new System.Drawing.Size(121, 20);
            this.txTallaProducto.TabIndex = 20;
            // 
            // cbEspecieProducto
            // 
            this.cbEspecieProducto.FormattingEnabled = true;
            this.cbEspecieProducto.Location = new System.Drawing.Point(666, 54);
            this.cbEspecieProducto.Name = "cbEspecieProducto";
            this.cbEspecieProducto.Size = new System.Drawing.Size(121, 21);
            this.cbEspecieProducto.TabIndex = 22;
            // 
            // cbTipoProducto
            // 
            this.cbTipoProducto.FormattingEnabled = true;
            this.cbTipoProducto.Location = new System.Drawing.Point(666, 81);
            this.cbTipoProducto.Name = "cbTipoProducto";
            this.cbTipoProducto.Size = new System.Drawing.Size(121, 21);
            this.cbTipoProducto.TabIndex = 23;
            // 
            // FrmPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 453);
            this.Controls.Add(this.cbTipoProducto);
            this.Controls.Add(this.cbEspecieProducto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txTallaProducto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txClaseProducto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txCodigoProducto);
            this.Controls.Add(this.btGuardarPrecios);
            this.Controls.Add(this.btEliminarProducto);
            this.Controls.Add(this.btAgregarProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txCodigoCliente);
            this.Controls.Add(this.btEliminarCliente);
            this.Controls.Add(this.btAgregarCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cblProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblClientes);
            this.Controls.Add(this.dgvPrecios);
            this.Name = "FrmPrecios";
            this.Text = "Editor de Precios";
            this.Load += new System.EventHandler(this.FrmPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.CheckedListBox cblClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblProductos;
        private System.Windows.Forms.Button btAgregarCliente;
        private System.Windows.Forms.Button btEliminarCliente;
        private System.Windows.Forms.TextBox txCodigoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEliminarProducto;
        private System.Windows.Forms.Button btAgregarProducto;
        private System.Windows.Forms.Button btGuardarPrecios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txCodigoProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txClaseProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txTallaProducto;
        private System.Windows.Forms.ComboBox cbEspecieProducto;
        private System.Windows.Forms.ComboBox cbTipoProducto;
    }
}