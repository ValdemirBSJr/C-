namespace catapora_bkp
{
    partial class catapora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(catapora));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.gpbEmail = new System.Windows.Forms.GroupBox();
            this.btnAbrirEmail = new System.Windows.Forms.Button();
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.pctEmail = new System.Windows.Forms.PictureBox();
            this.gpbPrint = new System.Windows.Forms.GroupBox();
            this.btnAbrirPrint = new System.Windows.Forms.Button();
            this.btnAddPrint = new System.Windows.Forms.Button();
            this.pctPrint = new System.Windows.Forms.PictureBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExecutor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtNodesSaturados = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpbEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmail)).BeginInit();
            this.gpbPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 385);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnApagar);
            this.tabPage1.Controls.Add(this.btnEditar);
            this.tabPage1.Controls.Add(this.btnSalvar);
            this.tabPage1.Controls.Add(this.btnNovo);
            this.tabPage1.Controls.Add(this.gpbEmail);
            this.tabPage1.Controls.Add(this.gpbPrint);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtExecutor);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.txtNodesSaturados);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(844, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(266, 15);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(82, 23);
            this.btnApagar.TabIndex = 15;
            this.btnApagar.Text = "APAGAR";
            this.btnApagar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(185, 15);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "&EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(104, 15);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "&SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(23, 15);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 12;
            this.btnNovo.Text = "&NOVO";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // gpbEmail
            // 
            this.gpbEmail.Controls.Add(this.btnAbrirEmail);
            this.gpbEmail.Controls.Add(this.btnAddEmail);
            this.gpbEmail.Controls.Add(this.pctEmail);
            this.gpbEmail.Location = new System.Drawing.Point(654, 15);
            this.gpbEmail.Name = "gpbEmail";
            this.gpbEmail.Size = new System.Drawing.Size(167, 212);
            this.gpbEmail.TabIndex = 11;
            this.gpbEmail.TabStop = false;
            this.gpbEmail.Text = "Email";
            // 
            // btnAbrirEmail
            // 
            this.btnAbrirEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirEmail.Image")));
            this.btnAbrirEmail.Location = new System.Drawing.Point(112, 168);
            this.btnAbrirEmail.Name = "btnAbrirEmail";
            this.btnAbrirEmail.Size = new System.Drawing.Size(37, 33);
            this.btnAbrirEmail.TabIndex = 3;
            this.btnAbrirEmail.UseVisualStyleBackColor = true;
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmail.Image")));
            this.btnAddEmail.Location = new System.Drawing.Point(19, 168);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(37, 33);
            this.btnAddEmail.TabIndex = 3;
            this.btnAddEmail.UseVisualStyleBackColor = true;
            // 
            // pctEmail
            // 
            this.pctEmail.Location = new System.Drawing.Point(6, 21);
            this.pctEmail.Name = "pctEmail";
            this.pctEmail.Size = new System.Drawing.Size(155, 141);
            this.pctEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctEmail.TabIndex = 1;
            this.pctEmail.TabStop = false;
            this.pctEmail.MouseHover += new System.EventHandler(this.pctEmail_MouseHover);
            // 
            // gpbPrint
            // 
            this.gpbPrint.Controls.Add(this.btnAbrirPrint);
            this.gpbPrint.Controls.Add(this.btnAddPrint);
            this.gpbPrint.Controls.Add(this.pctPrint);
            this.gpbPrint.Location = new System.Drawing.Point(480, 15);
            this.gpbPrint.Name = "gpbPrint";
            this.gpbPrint.Size = new System.Drawing.Size(168, 212);
            this.gpbPrint.TabIndex = 10;
            this.gpbPrint.TabStop = false;
            this.gpbPrint.Text = "Print";
            // 
            // btnAbrirPrint
            // 
            this.btnAbrirPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirPrint.Image")));
            this.btnAbrirPrint.Location = new System.Drawing.Point(111, 168);
            this.btnAbrirPrint.Name = "btnAbrirPrint";
            this.btnAbrirPrint.Size = new System.Drawing.Size(37, 33);
            this.btnAbrirPrint.TabIndex = 2;
            this.btnAbrirPrint.UseVisualStyleBackColor = true;
            // 
            // btnAddPrint
            // 
            this.btnAddPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPrint.Image")));
            this.btnAddPrint.Location = new System.Drawing.Point(19, 168);
            this.btnAddPrint.Name = "btnAddPrint";
            this.btnAddPrint.Size = new System.Drawing.Size(37, 33);
            this.btnAddPrint.TabIndex = 1;
            this.btnAddPrint.UseVisualStyleBackColor = true;
            this.btnAddPrint.Click += new System.EventHandler(this.btnAddPrint_Click);
            // 
            // pctPrint
            // 
            this.pctPrint.Location = new System.Drawing.Point(6, 21);
            this.pctPrint.Name = "pctPrint";
            this.pctPrint.Size = new System.Drawing.Size(155, 141);
            this.pctPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPrint.TabIndex = 0;
            this.pctPrint.TabStop = false;
            this.pctPrint.MouseHover += new System.EventHandler(this.pctPrint_MouseHover);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(29, 145);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(306, 22);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.Value = new System.DateTime(2015, 6, 27, 9, 51, 38, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data de tratamento";
            // 
            // txtExecutor
            // 
            this.txtExecutor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExecutor.Enabled = false;
            this.txtExecutor.Location = new System.Drawing.Point(104, 323);
            this.txtExecutor.Name = "txtExecutor";
            this.txtExecutor.Size = new System.Drawing.Size(100, 15);
            this.txtExecutor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Executor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nodes Saturados. Liste os nodes separados por vírgula...";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 93);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(306, 22);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2015, 6, 27, 9, 51, 38, 0);
            // 
            // txtNodesSaturados
            // 
            this.txtNodesSaturados.Location = new System.Drawing.Point(29, 233);
            this.txtNodesSaturados.Multiline = true;
            this.txtNodesSaturados.Name = "txtNodesSaturados";
            this.txtNodesSaturados.Size = new System.Drawing.Size(494, 74);
            this.txtNodesSaturados.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data de cadastro";
            // 
            // tabPage2
            // 
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(844, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // catapora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(852, 385);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "catapora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Catapora";
            this.Load += new System.EventHandler(this.catapora_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gpbEmail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctEmail)).EndInit();
            this.gpbPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtNodesSaturados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExecutor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpbEmail;
        private System.Windows.Forms.PictureBox pctEmail;
        private System.Windows.Forms.GroupBox gpbPrint;
        private System.Windows.Forms.PictureBox pctPrint;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAbrirEmail;
        private System.Windows.Forms.Button btnAddEmail;
        private System.Windows.Forms.Button btnAbrirPrint;
        private System.Windows.Forms.Button btnAddPrint;




    }
}

