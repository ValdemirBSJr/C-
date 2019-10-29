using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace exibe
{
    public partial class fim : Form
    {
        public fim()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//Funciona!
        { 
               if ((keyData == Keys.Enter) || (keyData == Keys.Space))
               {
                   Application.Exit();

                   //Pode usar tbm Environment.Exit(0);
               }
            
            
            return base.ProcessCmdKey(ref msg, keyData); 
        }//fim do capta botoes




        
        

        }
    }

