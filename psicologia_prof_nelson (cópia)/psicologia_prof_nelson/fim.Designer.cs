namespace exibe
{
    partial class fim
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
            this.lblMensagemFinal = new System.Windows.Forms.Label();
            this.lblPressione = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMensagemFinal
            // 
            this.lblMensagemFinal.AutoSize = true;
            this.lblMensagemFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemFinal.ForeColor = System.Drawing.Color.White;
            this.lblMensagemFinal.Location = new System.Drawing.Point(12, 50);
            this.lblMensagemFinal.Name = "lblMensagemFinal";
            this.lblMensagemFinal.Size = new System.Drawing.Size(995, 37);
            this.lblMensagemFinal.TabIndex = 0;
            this.lblMensagemFinal.Text = "O QUESTIONÁRIO TERMINOU. OBRIGADO POR PARTICIPAR!";
            this.lblMensagemFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPressione
            // 
            this.lblPressione.AutoSize = true;
            this.lblPressione.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressione.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPressione.Location = new System.Drawing.Point(227, 154);
            this.lblPressione.Name = "lblPressione";
            this.lblPressione.Size = new System.Drawing.Size(535, 29);
            this.lblPressione.TabIndex = 1;
            this.lblPressione.Text = "Pressione \"Enter\" ou \"Espaço\" para terminar.";
            // 
            // fim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1011, 487);
            this.Controls.Add(this.lblPressione);
            this.Controls.Add(this.lblMensagemFinal);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensagemFinal;
        private System.Windows.Forms.Label lblPressione;
    }
}