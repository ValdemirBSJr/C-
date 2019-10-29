using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesativaProtecaoTela
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDesativa_Click(object sender, EventArgs e)
        {
            DesativaProtetor();
            MessageBox.Show("Protetor Desativado");
        }
        public static void DesativaProtetor()
        {
            SetThreadExecutionState(
                EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }
        public static void AtivaProtetor()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        private void btnAtiva_Click(object sender, EventArgs e)
        {
            AtivaProtetor();
            MessageBox.Show("Protetor ativado");
        }
    }
}
