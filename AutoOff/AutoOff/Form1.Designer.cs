namespace AutoOff
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
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtMinuto = new System.Windows.Forms.TextBox();
            this.txtSegundo = new System.Windows.Forms.TextBox();
            this.Comecar = new System.Windows.Forms.Button();
            this.lblcontador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.horaMenos = new System.Windows.Forms.PictureBox();
            this.horaMais = new System.Windows.Forms.PictureBox();
            this.minutoMais = new System.Windows.Forms.PictureBox();
            this.minutoMenos = new System.Windows.Forms.PictureBox();
            this.segundoMais = new System.Windows.Forms.PictureBox();
            this.segundoMenos = new System.Windows.Forms.PictureBox();
            this.btnParar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.horaMenos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horaMais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutoMais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutoMenos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segundoMais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segundoMenos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(56, 63);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(50, 38);
            this.txtHora.TabIndex = 0;
            this.txtHora.TextChanged += new System.EventHandler(this.txtHora_TextChanged);
            // 
            // txtMinuto
            // 
            this.txtMinuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinuto.Location = new System.Drawing.Point(172, 63);
            this.txtMinuto.Name = "txtMinuto";
            this.txtMinuto.Size = new System.Drawing.Size(50, 38);
            this.txtMinuto.TabIndex = 1;
            this.txtMinuto.TextChanged += new System.EventHandler(this.txtMinuto_TextChanged);
            // 
            // txtSegundo
            // 
            this.txtSegundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegundo.Location = new System.Drawing.Point(284, 63);
            this.txtSegundo.Name = "txtSegundo";
            this.txtSegundo.Size = new System.Drawing.Size(50, 38);
            this.txtSegundo.TabIndex = 2;
            this.txtSegundo.TextChanged += new System.EventHandler(this.txtSegundo_TextChanged);
            // 
            // Comecar
            // 
            this.Comecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comecar.Location = new System.Drawing.Point(95, 124);
            this.Comecar.Name = "Comecar";
            this.Comecar.Size = new System.Drawing.Size(75, 67);
            this.Comecar.TabIndex = 3;
            this.Comecar.Text = "Começar";
            this.Comecar.UseVisualStyleBackColor = true;
            this.Comecar.Click += new System.EventHandler(this.Comecar_Click);
            // 
            // lblcontador
            // 
            this.lblcontador.AutoSize = true;
            this.lblcontador.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontador.Location = new System.Drawing.Point(217, 205);
            this.lblcontador.Name = "lblcontador";
            this.lblcontador.Size = new System.Drawing.Size(135, 33);
            this.lblcontador.TabIndex = 4;
            this.lblcontador.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minuto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(261, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Segundo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Contador Regressivo:";
            // 
            // horaMenos
            // 
            this.horaMenos.Image = ((System.Drawing.Image)(resources.GetObject("horaMenos.Image")));
            this.horaMenos.Location = new System.Drawing.Point(112, 85);
            this.horaMenos.Name = "horaMenos";
            this.horaMenos.Size = new System.Drawing.Size(16, 16);
            this.horaMenos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.horaMenos.TabIndex = 12;
            this.horaMenos.TabStop = false;
            this.horaMenos.Click += new System.EventHandler(this.horaMenos_Click);
            // 
            // horaMais
            // 
            this.horaMais.Image = ((System.Drawing.Image)(resources.GetObject("horaMais.Image")));
            this.horaMais.Location = new System.Drawing.Point(112, 63);
            this.horaMais.Name = "horaMais";
            this.horaMais.Size = new System.Drawing.Size(16, 16);
            this.horaMais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.horaMais.TabIndex = 13;
            this.horaMais.TabStop = false;
            this.horaMais.Click += new System.EventHandler(this.horaMais_Click);
            // 
            // minutoMais
            // 
            this.minutoMais.Image = ((System.Drawing.Image)(resources.GetObject("minutoMais.Image")));
            this.minutoMais.Location = new System.Drawing.Point(228, 63);
            this.minutoMais.Name = "minutoMais";
            this.minutoMais.Size = new System.Drawing.Size(16, 16);
            this.minutoMais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minutoMais.TabIndex = 15;
            this.minutoMais.TabStop = false;
            this.minutoMais.Click += new System.EventHandler(this.minutoMais_Click);
            // 
            // minutoMenos
            // 
            this.minutoMenos.Image = ((System.Drawing.Image)(resources.GetObject("minutoMenos.Image")));
            this.minutoMenos.Location = new System.Drawing.Point(228, 85);
            this.minutoMenos.Name = "minutoMenos";
            this.minutoMenos.Size = new System.Drawing.Size(16, 16);
            this.minutoMenos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minutoMenos.TabIndex = 14;
            this.minutoMenos.TabStop = false;
            this.minutoMenos.Click += new System.EventHandler(this.minutoMenos_Click);
            // 
            // segundoMais
            // 
            this.segundoMais.Image = ((System.Drawing.Image)(resources.GetObject("segundoMais.Image")));
            this.segundoMais.Location = new System.Drawing.Point(340, 63);
            this.segundoMais.Name = "segundoMais";
            this.segundoMais.Size = new System.Drawing.Size(16, 16);
            this.segundoMais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.segundoMais.TabIndex = 17;
            this.segundoMais.TabStop = false;
            this.segundoMais.Click += new System.EventHandler(this.segundoMais_Click);
            // 
            // segundoMenos
            // 
            this.segundoMenos.Image = ((System.Drawing.Image)(resources.GetObject("segundoMenos.Image")));
            this.segundoMenos.Location = new System.Drawing.Point(340, 85);
            this.segundoMenos.Name = "segundoMenos";
            this.segundoMenos.Size = new System.Drawing.Size(16, 16);
            this.segundoMenos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.segundoMenos.TabIndex = 16;
            this.segundoMenos.TabStop = false;
            this.segundoMenos.Click += new System.EventHandler(this.segundoMenos_Click);
            // 
            // btnParar
            // 
            this.btnParar.Enabled = false;
            this.btnParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParar.Location = new System.Drawing.Point(223, 125);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(82, 65);
            this.btnParar.TabIndex = 18;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 261);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.segundoMais);
            this.Controls.Add(this.segundoMenos);
            this.Controls.Add(this.minutoMais);
            this.Controls.Add(this.minutoMenos);
            this.Controls.Add(this.horaMais);
            this.Controls.Add(this.horaMenos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblcontador);
            this.Controls.Add(this.Comecar);
            this.Controls.Add(this.txtSegundo);
            this.Controls.Add(this.txtMinuto);
            this.Controls.Add(this.txtHora);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AutoOff";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.horaMenos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horaMais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutoMais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutoMenos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segundoMais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segundoMenos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtMinuto;
        private System.Windows.Forms.TextBox txtSegundo;
        private System.Windows.Forms.Button Comecar;
        private System.Windows.Forms.Label lblcontador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox horaMenos;
        private System.Windows.Forms.PictureBox horaMais;
        private System.Windows.Forms.PictureBox minutoMais;
        private System.Windows.Forms.PictureBox minutoMenos;
        private System.Windows.Forms.PictureBox segundoMais;
        private System.Windows.Forms.PictureBox segundoMenos;
        private System.Windows.Forms.Button btnParar;
    }
}

