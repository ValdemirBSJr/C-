namespace CHIPS_MULTI
{
    partial class frmClaro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaro));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtTempo = new System.Windows.Forms.DateTimePicker();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCHIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCHIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.btnbusca = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdChip = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(634, 251);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtIdChip);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dtTempo);
            this.tabPage1.Controls.Add(this.btnExcluir);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.btnEditar);
            this.tabPage1.Controls.Add(this.btnSalvar);
            this.tabPage1.Controls.Add(this.txtObs);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtAnexo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtCHIP);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbCHIP);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbStatus);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtOS);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtContrato);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(626, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtTempo
            // 
            this.dtTempo.Location = new System.Drawing.Point(21, 118);
            this.dtTempo.Name = "dtTempo";
            this.dtTempo.Size = new System.Drawing.Size(175, 20);
            this.dtTempo.TabIndex = 21;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(359, 17);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 19;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(267, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(173, 17);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(78, 17);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(21, 160);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(597, 48);
            this.txtObs.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Observações";
            // 
            // txtAnexo
            // 
            this.txtAnexo.Location = new System.Drawing.Point(359, 119);
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.Size = new System.Drawing.Size(259, 20);
            this.txtAnexo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Anexo";
            // 
            // txtCHIP
            // 
            this.txtCHIP.Location = new System.Drawing.Point(202, 119);
            this.txtCHIP.Name = "txtCHIP";
            this.txtCHIP.Size = new System.Drawing.Size(140, 20);
            this.txtCHIP.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Onde retirou o CHIP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data da entrega";
            // 
            // cbCHIP
            // 
            this.cbCHIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCHIP.FormattingEnabled = true;
            this.cbCHIP.Location = new System.Drawing.Point(359, 71);
            this.cbCHIP.Name = "cbCHIP";
            this.cbCHIP.Size = new System.Drawing.Size(99, 21);
            this.cbCHIP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de CHIP";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(230, 71);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(112, 21);
            this.cbStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status em sistema";
            // 
            // txtOS
            // 
            this.txtOS.Location = new System.Drawing.Point(117, 71);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(100, 20);
            this.txtOS.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contrato";
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(21, 71);
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(81, 20);
            this.txtContrato.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCon);
            this.tabPage2.Controls.Add(this.btnbusca);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(626, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(55, 9);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(100, 20);
            this.txtCon.TabIndex = 2;
            // 
            // btnbusca
            // 
            this.btnbusca.Location = new System.Drawing.Point(161, 7);
            this.btnbusca.Name = "btnbusca";
            this.btnbusca.Size = new System.Drawing.Size(75, 23);
            this.btnbusca.TabIndex = 1;
            this.btnbusca.Text = "BUSCAR";
            this.btnbusca.UseVisualStyleBackColor = true;
            this.btnbusca.Click += new System.EventHandler(this.btnbusca_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(614, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Id do Chip";
            // 
            // txtIdChip
            // 
            this.txtIdChip.Location = new System.Drawing.Point(474, 72);
            this.txtIdChip.Name = "txtIdChip";
            this.txtIdChip.Size = new System.Drawing.Size(144, 20);
            this.txtIdChip.TabIndex = 23;
            // 
            // frmClaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 277);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClaro";
            this.Text = "Acompanhamento CHIP COMBO MULTI";
            this.Load += new System.EventHandler(this.frmClaro_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContrato;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAnexo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCHIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCHIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.Button btnbusca;
        private System.Windows.Forms.DateTimePicker dtTempo;
        private System.Windows.Forms.TextBox txtIdChip;
        private System.Windows.Forms.Label label9;
    }
}

