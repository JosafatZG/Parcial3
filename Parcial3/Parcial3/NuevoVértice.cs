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
    public partial class NuevoVértice : Form
    {
        public bool control;
        public string valor; // el valor del vértice

        public NuevoVértice()
        {
            InitializeComponent();
            control = false;
            valor = "";
        }

        private void NuevoVértice_Load(object sender, EventArgs e)
        {
            txtnuevo.Clear(); 
            this.CenterToScreen();
            txtnuevo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor = txtnuevo.Text.Trim();

            if ((valor == "") || (valor == " "))
            {
                MessageBox.Show("Debes ingresar un valor", "Error", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
            }
            else if (valor.Length > 1)
            {
                valor = valor.Substring(0, 1);
                MessageBox.Show("Se toma solo un carácter");
                control = true;
                Hide();
            }
            else
            {
                control = true;
                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control = true;
            Hide();
        }

        private void NuevoVértice_FormClosing(object sender, FormClosingEventArgs e)
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
