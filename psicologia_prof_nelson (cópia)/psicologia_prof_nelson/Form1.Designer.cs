namespace exibe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblAlegria1 = new System.Windows.Forms.Label();
            this.lblMensagemInicial = new System.Windows.Forms.Label();
            this.IniciaMensagem = new System.Windows.Forms.Timer(this.components);
            this.lblRaiva2 = new System.Windows.Forms.Label();
            this.lblMedo3 = new System.Windows.Forms.Label();
            this.lblTristeza4 = new System.Windows.Forms.Label();
            this.ImgVisualiza = new System.Windows.Forms.PictureBox();
            this.marcador = new System.Windows.Forms.Timer(this.components);
            this.lblMarcador = new System.Windows.Forms.Label();
            this.lbltempo = new System.Windows.Forms.Label();
            this.mostramarcador = new System.Windows.Forms.Timer(this.components);
            this.lblFinal = new System.Windows.Forms.Label();
            this.lstresultados = new System.Windows.Forms.ListBox();
            this.lblArrayCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgVisualiza)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAlegria1
            // 
            this.lblAlegria1.AutoSize = true;
            this.lblAlegria1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlegria1.ForeColor = System.Drawing.Color.Yellow;
            this.lblAlegria1.Location = new System.Drawing.Point(200, 218);
            this.lblAlegria1.Name = "lblAlegria1";
            this.lblAlegria1.Size = new System.Drawing.Size(130, 25);
            this.lblAlegria1.TabIndex = 1;
            this.lblAlegria1.Text = "1-ALEGRIA";
            this.lblAlegria1.Visible = false;
            // 
            // lblMensagemInicial
            // 
            this.lblMensagemInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemInicial.ForeColor = System.Drawing.Color.White;
            this.lblMensagemInicial.Location = new System.Drawing.Point(21, 9);
            this.lblMensagemInicial.Name = "lblMensagemInicial";
            this.lblMensagemInicial.Size = new System.Drawing.Size(1110, 127);
            this.lblMensagemInicial.TabIndex = 2;
            this.lblMensagemInicial.Text = resources.GetString("lblMensagemInicial.Text");
            this.lblMensagemInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IniciaMensagem
            // 
            this.IniciaMensagem.Interval = 500;
            this.IniciaMensagem.Tick += new System.EventHandler(this.IniciaMensagem_Tick);
            // 
            // lblRaiva2
            // 
            this.lblRaiva2.AutoSize = true;
            this.lblRaiva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiva2.ForeColor = System.Drawing.Color.Yellow;
            this.lblRaiva2.Location = new System.Drawing.Point(200, 247);
            this.lblRaiva2.Name = "lblRaiva2";
            this.lblRaiva2.Size = new System.Drawing.Size(100, 25);
            this.lblRaiva2.TabIndex = 3;
            this.lblRaiva2.Text = "2-RAIVA";
            this.lblRaiva2.Visible = false;
            // 
            // lblMedo3
            // 
            this.lblMedo3.AutoSize = true;
            this.lblMedo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedo3.ForeColor = System.Drawing.Color.Yellow;
            this.lblMedo3.Location = new System.Drawing.Point(200, 275);
            this.lblMedo3.Name = "lblMedo3";
            this.lblMedo3.Size = new System.Drawing.Size(100, 25);
            this.lblMedo3.TabIndex = 4;
            this.lblMedo3.Text = "3-MEDO";
            this.lblMedo3.Visible = false;
            // 
            // lblTristeza4
            // 
            this.lblTristeza4.AutoSize = true;
            this.lblTristeza4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTristeza4.ForeColor = System.Drawing.Color.Yellow;
            this.lblTristeza4.Location = new System.Drawing.Point(200, 298);
            this.lblTristeza4.Name = "lblTristeza4";
            this.lblTristeza4.Size = new System.Drawing.Size(142, 25);
            this.lblTristeza4.TabIndex = 5;
            this.lblTristeza4.Text = "4-TRISTEZA";
            this.lblTristeza4.Visible = false;
            // 
            // ImgVisualiza
            // 
            this.ImgVisualiza.Location = new System.Drawing.Point(573, 90);
            this.ImgVisualiza.Name = "ImgVisualiza";
            this.ImgVisualiza.Size = new System.Drawing.Size(558, 635);
            this.ImgVisualiza.TabIndex = 6;
            this.ImgVisualiza.TabStop = false;
            this.ImgVisualiza.Visible = false;
            // 
            // marcador
            // 
            this.marcador.Interval = 500;
            this.marcador.Tick += new System.EventHandler(this.marcador_Tick);
            // 
            // lblMarcador
            // 
            this.lblMarcador.AutoSize = true;
            this.lblMarcador.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcador.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcador.ForeColor = System.Drawing.Color.Blue;
            this.lblMarcador.Location = new System.Drawing.Point(815, 341);
            this.lblMarcador.Name = "lblMarcador";
            this.lblMarcador.Size = new System.Drawing.Size(101, 108);
            this.lblMarcador.TabIndex = 7;
            this.lblMarcador.Text = "+";
            // 
            // lbltempo
            // 
            this.lbltempo.AutoSize = true;
            this.lbltempo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltempo.Location = new System.Drawing.Point(115, 136);
            this.lbltempo.Name = "lbltempo";
            this.lbltempo.Size = new System.Drawing.Size(35, 13);
            this.lbltempo.TabIndex = 8;
            this.lbltempo.Text = "label1";
            this.lbltempo.Visible = false;
            // 
            // mostramarcador
            // 
            this.mostramarcador.Interval = 1000;
            this.mostramarcador.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFinal.Location = new System.Drawing.Point(118, 165);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(35, 13);
            this.lblFinal.TabIndex = 9;
            this.lblFinal.Text = "label1";
            this.lblFinal.Visible = false;
            // 
            // lstresultados
            // 
            this.lstresultados.FormattingEnabled = true;
            this.lstresultados.Location = new System.Drawing.Point(55, 190);
            this.lstresultados.Name = "lstresultados";
            this.lstresultados.Size = new System.Drawing.Size(120, 108);
            this.lstresultados.TabIndex = 10;
            this.lstresultados.Visible = false;
            // 
            // lblArrayCount
            // 
            this.lblArrayCount.AutoSize = true;
            this.lblArrayCount.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblArrayCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblArrayCount.Location = new System.Drawing.Point(55, 165);
            this.lblArrayCount.Name = "lblArrayCount";
            this.lblArrayCount.Size = new System.Drawing.Size(35, 13);
            this.lblArrayCount.TabIndex = 11;
            this.lblArrayCount.Text = "label1";
            this.lblArrayCount.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1143, 780);
            this.Controls.Add(this.lblArrayCount);
            this.Controls.Add(this.lstresultados);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.lbltempo);
            this.Controls.Add(this.lblMarcador);
            this.Controls.Add(this.ImgVisualiza);
            this.Controls.Add(this.lblTristeza4);
            this.Controls.Add(this.lblMedo3);
            this.Controls.Add(this.lblRaiva2);
            this.Controls.Add(this.lblMensagemInicial);
            this.Controls.Add(this.lblAlegria1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgVisualiza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlegria1;
        private System.Windows.Forms.Label lblMensagemInicial;
        private System.Windows.Forms.Timer IniciaMensagem;
        private System.Windows.Forms.Label lblRaiva2;
        private System.Windows.Forms.Label lblMedo3;
        private System.Windows.Forms.Label lblTristeza4;
        private System.Windows.Forms.PictureBox ImgVisualiza;
        private System.Windows.Forms.Timer marcador;
        private System.Windows.Forms.Label lblMarcador;
        private System.Windows.Forms.Label lbltempo;
        private System.Windows.Forms.Timer mostramarcador;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.ListBox lstresultados;
        private System.Windows.Forms.Label lblArrayCount;

    }
}

