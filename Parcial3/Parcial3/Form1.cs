using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Parcial3
{
    public partial class Form1 : Form
    {
        private CGrafo grafo; // instanciamos la clase CGrafo
        private CVertice nuevoNodo; // instanciamos la clase CVertice
        private CVertice NodoOrigen; // instanciamos la clase CVertice
        private CVertice NodoDestino; // instanciamos la clase CVertice
        private int var_control = 0; // la utilizaremos para determinar el estado en la panel1:
        // 0 -> sin acción, 1 -> Dibujando arco, 2 -> Nuevo vértice
        private int ctrl = 1;//Para saber si se esta seleccionando el nodo origen o el destino. 1=origen, 2=destino


        // variables para el control de ventanas modales
        private NuevoVértice ventanaVertice; // ventana para agregar los vértices
        private NuevaArista ventanaArista; // ventana para agregar las aristas
        List<CVertice> nodosRuta; // Lista de nodos utilizada para almacenar la ruta
        List<CVertice> nodosOrdenados; // Lista de nodos ordenadas a partir del nodo origen
        bool buscarRuta = false, nuevoVertice = false, nuevaArissta = false;
        double peso = 0.0;
        bool profundidad = false, anchura = false, nodoEncontrado = false;
        Queue cola = new Queue(); //para el recorrido de anchura
        private string destino = "", origen = "";
        private int distancia = 0;

        public Form1()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new NuevoVértice();
            nodosRuta = new List<CVertice>();
            nodosOrdenados = new List<CVertice>();
            ventanaArista = new NuevaArista();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);

                if (nuevoVertice)
                {
                    cmbvertice.Items.Clear();
                    cmbvertice.SelectedIndex = -1;


                    cmbinicio.Items.Clear();
                    cmbinicio.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        cmbvertice.Items.Add(nodo.Valor);

                        cmbinicio.Items.Add(nodo.Valor);
                    }

                    nuevoVertice = false;
                }
                if (nuevaArissta)
                {
                    cmbarista.Items.Clear();
                    cmbarista.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        foreach (CArista arco in nodo.ListaAdyacencia)
                            cmbarista.Items.Add("[" + nodo.Valor + "," + arco.nDestino.Valor + "] peso: " + arco.peso);
                    }
                    nuevaArissta = false;
                }
                if (buscarRuta)
                {
                    foreach (CVertice nodo in nodosRuta)
                    {
                        nodo.colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    buscarRuta = false;
                }
                if (profundidad)
                {
                    //ordenando los nodos desde el que indica el usuario
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado)
                            recorridoProfundidad(nodo, e.Graphics);
                    }
                    profundidad = false;
                    //reestablecer los valroes
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;

                }
                if (anchura)
                {
                    distancia = 0;
                    //ordenando los nodos desde el que indica el usuario
                    cola = new Queue();
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado && !nodoEncontrado)
                            recorridoAnchura(nodo, e.Graphics, destino.ToString());
                    }
                    anchura = false;
                    nodoEncontrado = false;
                    //reestablecer los valroes
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnvertice_Click(object sender, EventArgs e)
        {
            if (cmbvertice.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    if (nodo.Valor == cmbvertice.SelectedItem.ToString())
                    {
                        grafo.nodos.Remove(nodo);
                        //Borrar las aristas que posea el nodo eliminado
                        nodo.ListaAdyacencia = new List<CArista>();
                        break;
                    }

                }
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArista arco in nodo.ListaAdyacencia)
                    {
                        if (arco.nDestino.Valor == cmbvertice.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevaArissta = true;
                nuevoVertice = true;
                cmbvertice.SelectedIndex = -1;
                panel1.Refresh();
            }
            else
            {

                MessageBox.Show("Seleccione un nodo", "NODO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnarista_Click(object sender, EventArgs e)
        {
            if (cmbarista.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArista arco in nodo.ListaAdyacencia)
                    {
                        if ("[" + nodo.Valor + "," + arco.nDestino.Valor + "] peso: " + arco.peso == cmbarista.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoVertice = true;
                nuevaArissta = true;
                cmbarista.SelectedIndex = -1;
                panel1.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione una arista", "ARISTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //Este evento sirve para que se refresque el panel y sucede cuando el puntero sale del panel
            panel1.Refresh();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: // Dibujando arco
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArista.Visible = false;
                        ventanaArista.control = false;
                        ventanaArista.ShowDialog();
                        if (ventanaArista.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino, ventanaArista.valor)) //Se procede a crear la arista
                            {
                                int distancia = ventanaArista.valor;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                            nuevaArissta = true;

                        }

                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    panel1.Refresh();
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (cmbinicio.SelectedIndex > -1)
            {
                profundidad = true;
                origen = cmbinicio.SelectedItem.ToString();
                panel1.Refresh();
                cmbinicio.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un nodo de inicio", "NODO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (cmbinicio.SelectedIndex > -1)
            {
                origen = cmbinicio.SelectedItem.ToString();
                anchura = true;
                panel1.Refresh();
                cmbinicio.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un nodo inicial", "NODO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtvertice.Text.Trim() != "")
            {
                if (grafo.BuscarVertice(txtvertice.Text) != null)
                {
                    MessageBox.Show("Vértice " + txtvertice.Text + " encontrado", "VÉRTICE ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vértice " + txtvertice.Text + " no encontrado", "VÉRTICE NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void nuevoVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2; // recordemos que es usado para indicar el estado en la pizarra: 0 ->
            // sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: // Dibujar arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    panel1.Refresh();
                    panel1.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    { CustomEndCap = bigArrow },
                       NodoOrigen.Posicion, e.Location);
                    break;

                case 2: //Creando nuevo nodo
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;
                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if (posX > panel1.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = panel1.Size.Width - nuevoNodo.Dimensiones.Width / 2;
                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > panel1.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                            posY = panel1.Size.Height - nuevoNodo.Dimensiones.Width / 2;
                        nuevoNodo.Posicion = new Point(posX, posY);
                        panel1.Refresh();
                        nuevoNodo.DibujarVertice(panel1.CreateGraphics());
                    }
                    break;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) // Si se ha presionado el botón
                                                                    // izquierdo del mouse
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1; // recordemos que es usado para indicar el estado en la panel1:
                                     // 0 -> sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
                }
                if (nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    ventanaVertice.ShowDialog();
                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.valor) == null)
                        {
                            grafo.AgregarVertice(nuevoNodo);
                            nuevoNodo.Valor = ventanaVertice.valor;
                        }
                        else
                        {
                            MessageBox.Show("Nodo " + ventanaVertice.valor + " ya existente", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    nuevoNodo = null;
                    nuevoVertice = true;
                    var_control = 0;
                    panel1.Refresh();
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right) // Si se ha presionado el botón
            // derecho del mouse
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        nuevoVérticeToolStripMenuItem.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                        panel1.ContextMenuStrip = this.contextMenuStrip1;
                }
            }
        }

        public void ordenarNodos()
        {
            nodosOrdenados = new List<CVertice>();
            bool est = false;
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen.ToString())
                {
                    nodosOrdenados.Add(nodo);
                    est = true;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen.ToString())
                {
                    est = false;
                    break;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
        }

        private void recorridoProfundidad(CVertice vertice, Graphics g)
        {
            vertice.Visitado = true;
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            foreach (CArista adya in vertice.ListaAdyacencia)
            {
                if (!adya.nDestino.Visitado)
                {
                    /**************
                    **************/
                    listBox1.Items.Add(adya.nDestino.Valor);
                    recorridoProfundidad(adya.nDestino, g);
                }
            }
        }

        private void recorridoAnchura(CVertice vertice, Graphics g, string destino)
        {
            vertice.Visitado = true;
            cola.Enqueue(vertice);
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);

            if (vertice.Valor == destino)
            {
                nodoEncontrado = true;
                return;
            }
            while (cola.Count > 0)
            {
                CVertice aux = (CVertice)cola.Dequeue();
                foreach (CArista adya in aux.ListaAdyacencia)
                {

                    if (!adya.nDestino.Visitado)
                    {
                        if (!nodoEncontrado)
                        {
                            adya.nDestino.Visitado = true;
                            adya.nDestino.colorear(g);
                            /**************
                            **************/
                            listBox1.Items.Add(adya.nDestino.Valor);
                            Thread.Sleep(1000);
                            adya.nDestino.DibujarVertice(g);
                            adya.nDestino.DibujarArco(g);
                            if (destino != "")
                                distancia += adya.peso;

                            cola.Enqueue(adya.nDestino);
                            if (adya.nDestino.Valor == destino)
                            {
                                nodoEncontrado = true;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
