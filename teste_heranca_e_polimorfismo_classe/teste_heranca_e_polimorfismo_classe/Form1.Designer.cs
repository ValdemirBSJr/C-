namespace teste_heranca_e_polimorfismo_classe
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.CPF = new System.Windows.Forms.Label();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFormacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.lstLeitura = new System.Windows.Forms.ListBox();
            this.rptRelatorio = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProfessorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProfessorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(167, 130);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(93, 63);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 25);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 2;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(15, 74);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 4;
            // 
            // CPF
            // 
            this.CPF.AutoSize = true;
            this.CPF.Location = new System.Drawing.Point(12, 58);
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(27, 13);
            this.CPF.TabIndex = 3;
            this.CPF.Text = "CPF";
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(15, 126);
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(100, 20);
            this.txtFone.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fone";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(15, 173);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo";
            // 
            // txtFormacao
            // 
            this.txtFormacao.Location = new System.Drawing.Point(15, 222);
            this.txtFormacao.Name = "txtFormacao";
            this.txtFormacao.Size = new System.Drawing.Size(100, 20);
            this.txtFormacao.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Formação";
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(185, 219);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnRelatorio.TabIndex = 11;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // lstLeitura
            // 
            this.lstLeitura.FormattingEnabled = true;
            this.lstLeitura.Location = new System.Drawing.Point(152, 25);
            this.lstLeitura.Name = "lstLeitura";
            this.lstLeitura.Size = new System.Drawing.Size(234, 95);
            this.lstLeitura.TabIndex = 12;
            // 
            // rptRelatorio
            // 
            this.rptRelatorio.LocalReport.ReportEmbeddedResource = "teste_heranca_e_polimorfismo_classe.Report1.rdlc";
            this.rptRelatorio.Location = new System.Drawing.Point(412, 3);
            this.rptRelatorio.Name = "rptRelatorio";
            this.rptRelatorio.Size = new System.Drawing.Size(396, 246);
            this.rptRelatorio.TabIndex = 13;
            // 
            // ProfessorBindingSource
            // 
            this.ProfessorBindingSource.DataSource = typeof(teste_heranca_e_polimorfismo_classe.Professor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 261);
            this.Controls.Add(this.rptRelatorio);
            this.Controls.Add(this.lstLeitura);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.txtFormacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.CPF);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCadastrar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProfessorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label CPF;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.ListBox lstLeitura;
        private Microsoft.Reporting.WinForms.ReportViewer rptRelatorio;
        private System.Windows.Forms.BindingSource ProfessorBindingSource;
    }
}

