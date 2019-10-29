namespace WindowsFormsApplication1
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
            this.lstVetor = new System.Windows.Forms.ListBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnListaA = new System.Windows.Forms.Button();
            this.btnListas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMostraRandom = new System.Windows.Forms.ListBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnArrayss = new System.Windows.Forms.Button();
            this.lstArrayConvertidoDeLista = new System.Windows.Forms.ListBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstVetor
            // 
            this.lstVetor.FormattingEnabled = true;
            this.lstVetor.Location = new System.Drawing.Point(12, 9);
            this.lstVetor.Name = "lstVetor";
            this.lstVetor.Size = new System.Drawing.Size(178, 238);
            this.lstVetor.TabIndex = 0;
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(197, 12);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "RANDOM";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnListaA
            // 
            this.btnListaA.Location = new System.Drawing.Point(197, 56);
            this.btnListaA.Name = "btnListaA";
            this.btnListaA.Size = new System.Drawing.Size(75, 23);
            this.btnListaA.TabIndex = 2;
            this.btnListaA.Text = "ARRAY";
            this.btnListaA.UseVisualStyleBackColor = true;
            this.btnListaA.Click += new System.EventHandler(this.btnListaA_Click);
            // 
            // btnListas
            // 
            this.btnListas.Location = new System.Drawing.Point(306, 9);
            this.btnListas.Name = "btnListas";
            this.btnListas.Size = new System.Drawing.Size(75, 23);
            this.btnListas.TabIndex = 3;
            this.btnListas.Text = "LISTA";
            this.btnListas.UseVisualStyleBackColor = true;
            this.btnListas.Click += new System.EventHandler(this.btnListas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResultado);
            this.groupBox1.Controls.Add(this.lstMostraRandom);
            this.groupBox1.Location = new System.Drawing.Point(197, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 162);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lstMostraRandom
            // 
            this.lstMostraRandom.FormattingEnabled = true;
            this.lstMostraRandom.Location = new System.Drawing.Point(6, 48);
            this.lstMostraRandom.Name = "lstMostraRandom";
            this.lstMostraRandom.Size = new System.Drawing.Size(188, 108);
            this.lstMostraRandom.TabIndex = 4;
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(107, 21);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(69, 20);
            this.txtResultado.TabIndex = 5;
            // 
            // btnArrayss
            // 
            this.btnArrayss.Location = new System.Drawing.Point(306, 51);
            this.btnArrayss.Name = "btnArrayss";
            this.btnArrayss.Size = new System.Drawing.Size(75, 23);
            this.btnArrayss.TabIndex = 5;
            this.btnArrayss.Text = "Array List";
            this.btnArrayss.UseVisualStyleBackColor = true;
            this.btnArrayss.Click += new System.EventHandler(this.btnArrayss_Click);
            // 
            // lstArrayConvertidoDeLista
            // 
            this.lstArrayConvertidoDeLista.FormattingEnabled = true;
            this.lstArrayConvertidoDeLista.Location = new System.Drawing.Point(403, 133);
            this.lstArrayConvertidoDeLista.Name = "lstArrayConvertidoDeLista";
            this.lstArrayConvertidoDeLista.Size = new System.Drawing.Size(120, 108);
            this.lstArrayConvertidoDeLista.TabIndex = 6;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(403, 9);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 7;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 261);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lstArrayConvertidoDeLista);
            this.Controls.Add(this.btnArrayss);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnListas);
            this.Controls.Add(this.btnListaA);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.lstVetor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstVetor;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnListaA;
        private System.Windows.Forms.Button btnListas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstMostraRandom;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnArrayss;
        private System.Windows.Forms.ListBox lstArrayConvertidoDeLista;
        private System.Windows.Forms.Button btnLimpar;
    }
}

