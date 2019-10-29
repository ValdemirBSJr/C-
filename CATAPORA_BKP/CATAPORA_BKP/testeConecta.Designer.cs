namespace CATAPORA_BKP
{
    partial class testeConecta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testeConecta));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPasta = new System.Windows.Forms.Label();
            this.btnPasta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Hostname = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lsbEquipamentos = new System.Windows.Forms.ListBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label1, resources.GetString("label1.HelpString"));
            this.label1.Location = new System.Drawing.Point(31, 24);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta padrão da aplicação:";
            // 
            // lblPasta
            // 
            this.lblPasta.AutoSize = true;
            this.helpProvider1.SetHelpString(this.lblPasta, resources.GetString("lblPasta.HelpString"));
            this.lblPasta.Location = new System.Drawing.Point(175, 24);
            this.lblPasta.Name = "lblPasta";
            this.helpProvider1.SetShowHelp(this.lblPasta, true);
            this.lblPasta.Size = new System.Drawing.Size(35, 13);
            this.lblPasta.TabIndex = 1;
            this.lblPasta.Text = "label2";
            // 
            // btnPasta
            // 
            this.helpProvider1.SetHelpString(this.btnPasta, resources.GetString("btnPasta.HelpString"));
            this.btnPasta.Location = new System.Drawing.Point(34, 51);
            this.btnPasta.Name = "btnPasta";
            this.helpProvider1.SetShowHelp(this.btnPasta, true);
            this.btnPasta.Size = new System.Drawing.Size(75, 23);
            this.btnPasta.TabIndex = 2;
            this.btnPasta.Text = "Alterar";
            this.btnPasta.UseVisualStyleBackColor = true;
            this.btnPasta.Click += new System.EventHandler(this.btnPasta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.Hostname);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.btnIncluir);
            this.groupBox1.Controls.Add(this.lsbEquipamentos);
            this.groupBox1.Location = new System.Drawing.Point(13, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup";
            // 
            // Hostname
            // 
            this.Hostname.AutoSize = true;
            this.Hostname.Location = new System.Drawing.Point(234, 20);
            this.Hostname.Name = "Hostname";
            this.Hostname.Size = new System.Drawing.Size(68, 13);
            this.Hostname.TabIndex = 5;
            this.Hostname.Text = "HOSTNAME";
            // 
            // txtHost
            // 
            this.helpProvider1.SetHelpString(this.txtHost, "Aqui você salvará os equipamentos que serão feitos bkp, serve para comparação e s" +
                    "inalização, caso o BKP não seja de todos os equipamentos necessários. Verifica s" +
                    "e o processo está aderente.");
            this.txtHost.Location = new System.Drawing.Point(234, 39);
            this.txtHost.Name = "txtHost";
            this.helpProvider1.SetShowHelp(this.txtHost, true);
            this.txtHost.Size = new System.Drawing.Size(124, 20);
            this.txtHost.TabIndex = 4;
            // 
            // btnExcluir
            // 
            this.helpProvider1.SetHelpString(this.btnExcluir, "Aqui você salvará os equipamentos que serão feitos bkp, serve para comparação e s" +
                    "inalização, caso o BKP não seja de todos os equipamentos necessários. Verifica s" +
                    "e o processo está aderente.");
            this.btnExcluir.Location = new System.Drawing.Point(374, 55);
            this.btnExcluir.Name = "btnExcluir";
            this.helpProvider1.SetShowHelp(this.btnExcluir, true);
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnIncluir
            // 
            this.helpProvider1.SetHelpString(this.btnIncluir, "Aqui você salvará os equipamentos que serão feitos bkp, serve para comparação e s" +
                    "inalização, caso o BKP não seja de todos os equipamentos necessários. Verifica s" +
                    "e o processo está aderente.");
            this.btnIncluir.Location = new System.Drawing.Point(374, 26);
            this.btnIncluir.Name = "btnIncluir";
            this.helpProvider1.SetShowHelp(this.btnIncluir, true);
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 1;
            this.btnIncluir.Text = "Adicionar";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // lsbEquipamentos
            // 
            this.lsbEquipamentos.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.lsbEquipamentos, "Aqui você salvará os equipamentos que serão feitos bkp, serve para comparação e s" +
                    "inalização, caso o BKP não seja de todos os equipamentos necessários. Verifica s" +
                    "e o processo está aderente.");
            this.lsbEquipamentos.Location = new System.Drawing.Point(6, 19);
            this.lsbEquipamentos.Name = "lsbEquipamentos";
            this.helpProvider1.SetShowHelp(this.lsbEquipamentos, true);
            this.lsbEquipamentos.Size = new System.Drawing.Size(210, 108);
            this.lsbEquipamentos.TabIndex = 0;
            this.lsbEquipamentos.SelectedValueChanged += new System.EventHandler(this.lsbEquipamentos_SelectedValueChanged);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(333, 114);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(209, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Powered by N5669203 for Datacenter JPA";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.DoubleClick += new System.EventHandler(this.linkLabel1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // testeConecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPasta);
            this.Controls.Add(this.lblPasta);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "testeConecta";
            this.Text = "Configurações da Pasta Padrão";
            this.Load += new System.EventHandler(this.testeConecta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPasta;
        private System.Windows.Forms.Button btnPasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Hostname;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.ListBox lsbEquipamentos;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ImageList imageList1;


    }
}

