using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial3
{
    public partial class NuevaArista : Form
    {
        public bool control;
        public int valor; // el valor de la arista
        public NuevaArista()
        {
            InitializeComponent();
            control = false;
            valor = 0;
        }

        private void NuevaArista_Load(object sender, EventArgs e)
        {
            txtnuevo.Clear();
            this.CenterToScreen();
            txtnuevo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                valor = Convert.ToInt16(txtnuevo.Text.Trim());

                if (valor < 0)
                {
                    MessageBox.Show("Debes ingresar un valor positivo", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                }
                else
                {
                    control = true;
                    Hide();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Debes ingresar un valor numerico");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control = false;
            Hide();
        }

        private void NuevaArista_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void txtnuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
