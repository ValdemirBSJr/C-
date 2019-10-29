namespace Login_PREPARA_PORTIFOLIO_3P
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.mskSenha = new System.Windows.Forms.MaskedTextBox();
            this.lnkLembrar = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImagem = new System.Windows.Forms.PictureBox();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.mskConfirma = new System.Windows.Forms.MaskedTextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.txtCNH = new System.Windows.Forms.TextBox();
            this.lblCNH = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(76, 20);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // mskSenha
            // 
            this.mskSenha.Location = new System.Drawing.Point(76, 57);
            this.mskSenha.Name = "mskSenha";
            this.mskSenha.PasswordChar = '#';
            this.mskSenha.Size = new System.Drawing.Size(100, 20);
            this.mskSenha.TabIndex = 3;
            // 
            // lnkLembrar
            // 
            this.lnkLembrar.AutoSize = true;
            this.lnkLembrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLembrar.LinkColor = System.Drawing.Color.Navy;
            this.lnkLembrar.Location = new System.Drawing.Point(86, 89);
            this.lnkLembrar.Name = "lnkLembrar";
            this.lnkLembrar.Size = new System.Drawing.Size(188, 13);
            this.lnkLembrar.TabIndex = 4;
            this.lnkLembrar.TabStop = true;
            this.lnkLembrar.Text = "Deseja se cadastrar ou apagar?";
            this.lnkLembrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLembrar_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha:";
            // 
            // btnImagem
            // 
            this.btnImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnImagem.Image")));
            this.btnImagem.Location = new System.Drawing.Point(195, 21);
            this.btnImagem.Name = "btnImagem";
            this.btnImagem.Size = new System.Drawing.Size(79, 34);
            this.btnImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImagem.TabIndex = 7;
            this.btnImagem.TabStop = false;
            this.btnImagem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.btnImagem.MouseEnter += new System.EventHandler(this.btnImagem_MouseEnter);
            this.btnImagem.MouseLeave += new System.EventHandler(this.btnImagem_MouseLeave);
            // 
            // lblConfirma
            // 
            this.lblConfirma.AutoSize = true;
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(18, 89);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(111, 16);
            this.lblConfirma.TabIndex = 9;
            this.lblConfirma.Text = "Repetir Senha:";
            this.lblConfirma.Visible = false;
            // 
            // mskConfirma
            // 
            this.mskConfirma.Enabled = false;
            this.mskConfirma.Location = new System.Drawing.Point(76, 108);
            this.mskConfirma.Name = "mskConfirma";
            this.mskConfirma.PasswordChar = '#';
            this.mskConfirma.Size = new System.Drawing.Size(100, 20);
            this.mskConfirma.TabIndex = 8;
            this.mskConfirma.Visible = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.Red;
            this.btnCadastrar.Enabled = false;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCadastrar.Location = new System.Drawing.Point(195, 105);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(78, 28);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(279, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 27);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.BackColor = System.Drawing.Color.Red;
            this.btnApagar.Enabled = false;
            this.btnApagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagar.ForeColor = System.Drawing.Color.White;
            this.btnApagar.Location = new System.Drawing.Point(194, 20);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(80, 35);
            this.btnApagar.TabIndex = 12;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = false;
            this.btnApagar.Visible = false;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(18, 134);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(74, 16);
            this.lblTel.TabIndex = 14;
            this.lblTel.Text = "Telefone:";
            this.lblTel.Visible = false;
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(98, 133);
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(78, 20);
            this.txtFone.TabIndex = 15;
            this.txtFone.Visible = false;
            // 
            // txtCNH
            // 
            this.txtCNH.Location = new System.Drawing.Point(68, 156);
            this.txtCNH.Name = "txtCNH";
            this.txtCNH.Size = new System.Drawing.Size(100, 20);
            this.txtCNH.TabIndex = 17;
            this.txtCNH.Visible = false;
            // 
            // lblCNH
            // 
            this.lblCNH.AutoSize = true;
            this.lblCNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNH.Location = new System.Drawing.Point(18, 160);
            this.lblCNH.Name = "lblCNH";
            this.lblCNH.Size = new System.Drawing.Size(44, 16);
            this.lblCNH.TabIndex = 16;
            this.lblCNH.Text = "CNH:";
            this.lblCNH.Visible = false;
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(232, 137);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(114, 20);
            this.txtRG.TabIndex = 19;
            this.txtRG.Visible = false;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRG.Location = new System.Drawing.Point(192, 138);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(34, 16);
            this.lblRG.TabIndex = 18;
            this.lblRG.Text = "RG:";
            this.lblRG.Visible = false;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(213, 163);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(131, 20);
            this.txtCPF.TabIndex = 21;
            this.txtCPF.Visible = false;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(173, 164);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(41, 16);
            this.lblCPF.TabIndex = 20;
            this.lblCPF.Text = "CPF:";
            this.lblCPF.Visible = false;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(95, 189);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(251, 20);
            this.txtEndereco.TabIndex = 23;
            this.txtEndereco.Visible = false;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.Location = new System.Drawing.Point(16, 189);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(83, 16);
            this.lblEndereco.TabIndex = 22;
            this.lblEndereco.Text = "Endereço::";
            this.lblEndereco.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 211);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.lblRG);
            this.Controls.Add(this.txtCNH);
            this.Controls.Add(this.lblCNH);
            this.Controls.Add(this.txtFone);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblConfirma);
            this.Controls.Add(this.mskConfirma);
            this.Controls.Add(this.btnImagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkLembrar);
            this.Controls.Add(this.mskSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LOGIN SISTEMA LOCADORA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.MaskedTextBox mskSenha;
        private System.Windows.Forms.LinkLabel lnkLembrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnImagem;
        private System.Windows.Forms.Label lblConfirma;
        private System.Windows.Forms.MaskedTextBox mskConfirma;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.TextBox txtCNH;
        private System.Windows.Forms.Label lblCNH;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
    }
}

