namespace threadingEStatusBar
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.btnRodarProcesso = new System.Windows.Forms.Button();
            this.btnIndeterminado = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // bgWorkerIndeterminado
            // 
            this.bgWorkerIndeterminado.WorkerSupportsCancellation = true;
            this.bgWorkerIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerIndeterminado_DoWork);
            this.bgWorkerIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerIndeterminado_RunWorkerCompleted);
            // 
            // btnRodarProcesso
            // 
            this.btnRodarProcesso.Location = new System.Drawing.Point(32, 27);
            this.btnRodarProcesso.Name = "btnRodarProcesso";
            this.btnRodarProcesso.Size = new System.Drawing.Size(126, 34);
            this.btnRodarProcesso.TabIndex = 0;
            this.btnRodarProcesso.Text = "Rodar Processo";
            this.btnRodarProcesso.UseVisualStyleBackColor = true;
            this.btnRodarProcesso.Click += new System.EventHandler(this.btnRodarProcesso_Click);
            // 
            // btnIndeterminado
            // 
            this.btnIndeterminado.Location = new System.Drawing.Point(197, 27);
            this.btnIndeterminado.Name = "btnIndeterminado";
            this.btnIndeterminado.Size = new System.Drawing.Size(126, 34);
            this.btnIndeterminado.TabIndex = 1;
            this.btnIndeterminado.Text = "Rodar processo com tempo indeterminado";
            this.btnIndeterminado.UseVisualStyleBackColor = true;
            this.btnIndeterminado.Click += new System.EventHandler(this.btnIndeterminado_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(356, 27);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 34);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(450, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 118);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIndeterminado);
            this.Controls.Add(this.btnRodarProcesso);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker bgWorkerIndeterminado;
        private System.Windows.Forms.Button btnRodarProcesso;
        private System.Windows.Forms.Button btnIndeterminado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

