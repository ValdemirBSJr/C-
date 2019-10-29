namespace DesativaProtecaoTela
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
            this.btnDesativa = new System.Windows.Forms.Button();
            this.btnAtiva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDesativa
            // 
            this.btnDesativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesativa.Location = new System.Drawing.Point(41, 37);
            this.btnDesativa.Name = "btnDesativa";
            this.btnDesativa.Size = new System.Drawing.Size(188, 63);
            this.btnDesativa.TabIndex = 0;
            this.btnDesativa.Text = "Desativar Protetor de Tela";
            this.btnDesativa.UseVisualStyleBackColor = true;
            this.btnDesativa.Click += new System.EventHandler(this.btnDesativa_Click);
            // 
            // btnAtiva
            // 
            this.btnAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtiva.Location = new System.Drawing.Point(41, 106);
            this.btnAtiva.Name = "btnAtiva";
            this.btnAtiva.Size = new System.Drawing.Size(188, 63);
            this.btnAtiva.TabIndex = 1;
            this.btnAtiva.Text = "Ativa Protetor de Tela";
            this.btnAtiva.UseVisualStyleBackColor = true;
            this.btnAtiva.Click += new System.EventHandler(this.btnAtiva_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 187);
            this.Controls.Add(this.btnAtiva);
            this.Controls.Add(this.btnDesativa);
            this.Name = "Form1";
            this.Text = "Desativa Protetor de Tela";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDesativa;
        private System.Windows.Forms.Button btnAtiva;
    }
}

