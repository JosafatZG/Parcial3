using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Parcial3
{
    class CArista
    {
        public CVertice nDestino;
        public int peso;
        public float grosor_flecha;
        public Color color;
        // Métodos
        public CArista(CVertice destino) : this(destino, 1)
        {
            this.nDestino = destino;
        }
        public CArista(CVertice destino, int peso)
        {
            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 1;
            this.color = Color.Black;
        }
    }
}
