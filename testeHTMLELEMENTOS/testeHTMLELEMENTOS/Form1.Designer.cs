namespace testeHTMLELEMENTOS
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnNavegar = new System.Windows.Forms.Button();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSalvarPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 49);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(864, 417);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnNavegar
            // 
            this.btnNavegar.Location = new System.Drawing.Point(420, 10);
            this.btnNavegar.Name = "btnNavegar";
            this.btnNavegar.Size = new System.Drawing.Size(75, 23);
            this.btnNavegar.TabIndex = 1;
            this.btnNavegar.Text = "Navegar";
            this.btnNavegar.UseVisualStyleBackColor = true;
            this.btnNavegar.Click += new System.EventHandler(this.btnNavegar_Click);
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Location = new System.Drawing.Point(501, 10);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(75, 23);
            this.btnRetroceder.TabIndex = 2;
            this.btnRetroceder.Text = "Retornar";
            this.btnRetroceder.UseVisualStyleBackColor = true;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(582, 10);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 3;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(663, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(32, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(383, 20);
            this.txtURL.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(744, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(825, 9);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(57, 23);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSalvarPDF
            // 
            this.btnSalvarPDF.Location = new System.Drawing.Point(2, 10);
            this.btnSalvarPDF.Name = "btnSalvarPDF";
            this.btnSalvarPDF.Size = new System.Drawing.Size(24, 23);
            this.btnSalvarPDF.TabIndex = 8;
            this.btnSalvarPDF.Text = "S";
            this.btnSalvarPDF.UseVisualStyleBackColor = true;
            this.btnSalvarPDF.Click += new System.EventHandler(this.btnSalvarPDF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 466);
            this.Controls.Add(this.btnSalvarPDF);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnNavegar);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnNavegar;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSalvarPDF;
    }
}

