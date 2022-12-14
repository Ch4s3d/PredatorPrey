using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexLocation
{
    public class Vertex
    {
        private int numeroVertex;
        private int circunferenciaX;
        private int circunferenciaY;
        private int xPos;
        private int yPos;

        private Vertex ant;
        private Vertex sig;

        //Edge

        Edge inicio;
        Edge final;
        int edgeCont = 0;

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        internal Vertex Sig { get => sig; set => sig = value; }
        public int CircunferenciaX { get => circunferenciaX; set => circunferenciaX = value; }
        public int CircunferenciaY { get => circunferenciaY; set => circunferenciaY = value; }
        public int EdgeCont { get => edgeCont; set => edgeCont = value; }
        internal Edge Inicio { get => inicio; set => inicio = value; }
        public Edge Final { get => final; set => final = value; }
        public Vertex Ant { get => ant; set => ant = value; }
        public int NumeroVertex { get => numeroVertex; set => numeroVertex = value; }
        public Vertex(int numeroVertex, int circunferenciaX, int circunferenciaY, int xPos, int yPos)
        {
            this.numeroVertex = numeroVertex;
            this.CircunferenciaX = circunferenciaX;
            this.CircunferenciaY = circunferenciaY;

            this.xPos = xPos;
            this.yPos = yPos;

            this.sig = null;
        }
        public string readVertex()
        {
            string circulo = "[" + this.XPos + ", " + this.YPos + ", Radio(x, y): " + this.circunferenciaX.ToString() + ", " + this.circunferenciaY.ToString() + "]";
            return circulo;
        }
        public void addEdge(Vertex agregar, int peso)
        {
            Edge nuevo = new Edge(agregar, peso, this);

            if (inicio == null)
            {
                inicio = nuevo;
                final = nuevo;
            }

            else
            {
                final.Sig = nuevo;
                final = nuevo;
            }
            EdgeCont++;
        }
        public Edge getEdge(int i)
        {
            Edge aux = inicio;
            int cont = 0;

            while (aux != null || cont <= i)
            {
                cont++;
                aux = aux.Sig;
            }

            return aux;
        }
        public Edge getEdgeAt(int n)
        {
            Edge aux = inicio;
            for (int j = 0; j < n && aux.Sig != null; n++)
                aux = aux.Sig;
            return aux;

        }
    }
    public class Edge
    {
        private Vertex ant;
        private Vertex actual;
        private Edge sig;
        private int peso = -1;

        public Edge(Vertex actual, int peso, Vertex ant)
        {
            sig = null;
            this.ant = ant;
            this.actual = actual;
            this.peso = peso;
        }
        public int Peso { get => peso; set => peso = value; }
        public Vertex Ant { get => ant; set => ant = value; }
        internal Vertex Actual { get => actual; set => actual = value; }
        internal Edge Sig { get => sig; set => sig = value; }
    }
}
