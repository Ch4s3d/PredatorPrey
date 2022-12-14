using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VertexLocation
{
    public class ImageProcess
    {
        private Imagen imagen;
        private int centroides;

        private Vertex inicio;
        private Vertex final;
        private int contCirculos;

        public ImageProcess()
        {
            inicio = null;
            Final = null;
            contCirculos = 0;
        }
        internal Imagen Imagen { get => imagen; set => imagen = value; }
        public int Centroides { get => centroides; set => centroides = value; }
        internal Vertex Inicio { get => inicio; set => inicio = value; }
        public int ContCirculos { get => contCirculos; set => contCirculos = value; }
        public Vertex Final { get => final; set => final = value; }

        //

        public Bitmap imageAsk()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Abrir Imagen";
            dlg.Filter = "png files (*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                centroides = 0;
                imagen = new Imagen(dlg.FileName);
                FirstBackPoint();
                return imagen.ImgBitmap;
            }
            else return null;
        }
        private void FirstBackPoint()
        {
            for (int y = 0; y < imagen.ImgBitmap.Height; y++)
                for (int x = 0; x < imagen.ImgBitmap.Width; x++)
                {
                    Color pixel = imagen.ImgBitmap.GetPixel(x, y);
                    if (pixel.ToArgb().Equals(Color.Black.ToArgb()))
                    {
                        findCenter(x, y);
                        break;
                        //return;
                    }
                }
        }
        private void findCenter(int xi, int yi)
        {
            int centerX = ((LastBlackPointX(xi, yi) - xi) / 2) + xi;

            int centerY = ((LastBlackPointY(centerX, yi) - yi) / 2) + yi;

            radio(centerX, centerY);
        }
        private int LastBlackPointX(int x, int y)
        {
            int xf = x;

            while (xf < imagen.ImgBitmap.Width)
            {
                Color pixel = imagen.ImgBitmap.GetPixel(xf, y);
                if (!pixel.ToArgb().Equals(Color.Black.ToArgb()))
                {
                    break;
                }
                xf++;
            }

            return xf;
        }
        private int LastBlackPointY(int x, int y)
        {
            int yf = y;

            while (yf < imagen.ImgBitmap.Height)
            {
                Color pixel = imagen.ImgBitmap.GetPixel(x, yf);
                if (!pixel.ToArgb().Equals(Color.Black.ToArgb()))
                {
                    break;
                }
                yf++;
            }

            return yf;
        }
        private void radio(int x, int y)
        {
            int radioX = LastBlackPointX(x, y);
            int radioY = LastBlackPointY(x, y);

            radioX = radioX - x;
            radioY = radioY - y;

            int radioMayor = radioX;
            if (radioY > radioX)
                radioMayor = radioY;

            if ((radioX * 2) + 10 > (radioY * 2) && (radioY * 2) + 10 > (radioX * 2) && blanqueamEste(x, y, radioMayor))
            {
                Vertex nuevo = new Vertex(ContCirculos, radioX, radioY, x, y);
                addVertex(nuevo);
                dibujarCenter(x, y);
            }
            else noVertex(x, y);
        }
        private bool blanqueamEste(int x, int y, int radio)
        {
            if (x + radio + 5 > imagen.ImgBitmap.Width || y + radio + 5 > imagen.ImgBitmap.Height || x - radio - 5 < 0 || y - radio - 5 < 0)
            {
                return false;
            }

            int finalX = x + radio + 5;
            int finalY = y + radio + 5;

            for (int inicioY = y - radio - 5; inicioY < finalY; inicioY++)
                for (int inicioX = x - radio - 5; inicioX < finalX; inicioX++)
                {
                    Color pixel = imagen.ImgBitmap.GetPixel(inicioX, inicioY);
                    if (pixel.ToArgb().Equals(Color.Black.ToArgb()))
                        imagen.ImgBitmap.SetPixel(inicioX, inicioY, Color.DarkGray);
                }
            return true;
        }
        public void dibujarCenter(int x, int y)
        {
            for (int a = x - 5; a < x + 5; a++)
                for (int b = y - 5; b < y + 5; b++)
                    imagen.ImgBitmap.SetPixel(a, b, Color.Red);

            centroides++;

        }
        public void noVertex(int x, int y)
        {
            int radioX = LastBlackPointX(x, y) - x;
            int radioY = LastBlackPointY(x, y) - y;

            int xi = x - radioX;
            int xf = LastBlackPointX(x, y);
            int yi = y - radioY;
            int yf = LastBlackPointY(x, y);

            if (xi - 5 < 0)
                xi = 0;
            else xi -= 5;

            if (xf > imagen.ImgBitmap.Width)
                xf = imagen.ImgBitmap.Width - 1;
            else xf += 5;

            if (yi - 5 < 0)
                yi = 0;
            else yi -= 5;

            if (yf + 5 > imagen.ImgBitmap.Height)
                yf = imagen.ImgBitmap.Height - 1;
            else yf += 5;

            while (yi <= yf && yi < imagen.ImgBitmap.Height)
            {
                int auxX = xi;
                while (auxX <= xf && auxX < imagen.ImgBitmap.Width)
                {
                    Color pixel = imagen.ImgBitmap.GetPixel(auxX, yi);
                    if (pixel.ToArgb().Equals(Color.Black.ToArgb()))
                        imagen.ImgBitmap.SetPixel(auxX, yi, Color.Red);
                    auxX++;
                }
                yi++;
            }
        }
        public int euclidianDistance(int xo, int yo, int xf, int yf)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow((xf - xo), 2) + Math.Pow((yf - yo), 2)));
        }
        private void addVertex(Vertex nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                Final = nuevo;
            }

            else
            {
                Final.Sig = nuevo;
                nuevo.Ant = Final;
                Final = nuevo;
            }

            contCirculos++;
        }
        public Vertex getVertexAt(int i)
        {
            Vertex aux = inicio;
            for (int j=0; j<i && aux.Sig != null; i++)
            {
                aux = aux.Sig;
            }
            return aux;
        }

        public Vertex belongsTo(int x_k, int y_k)
        {
            if (inicio == null)
                return null;

            Vertex c_i;
            float x_0;
            float y_0;
            float r;
            float k = 5;
            float s;

            Vertex aux = inicio;

            while (aux != null)
            {
                c_i = aux;
                x_0 = c_i.XPos;
                y_0 = c_i.YPos;
                r = c_i.CircunferenciaX + k;
                s = (x_k - x_0) * (x_k - x_0) + (y_k - y_0) * (y_k - y_0) - r * r;
                if (s <= 0)
                    break;

                aux = aux.Sig;
            }
            return aux;
        }
    }
    public class Game
    {
        private Depredador inicioDepredador;
        private Depredador finalDepredador;
        private Presa inicioPresa;
        private Presa finalPresa;
        private Reference inicioReference;
        private Reference finalReference;

        private int contDepredadores;
        private int contPresas;
        private int vision;

        internal Depredador InicioDepredador { get => inicioDepredador; set => inicioDepredador = value; }
        internal Presa InicioPresa { get => inicioPresa; set => inicioPresa = value; }
        public Reference InicioReference { get => inicioReference; set => inicioReference = value; }

        public Game()
        {
            InicioDepredador = null;
            finalDepredador = null;
            InicioPresa = null;
            finalPresa = null;
            InicioReference = null;

            contDepredadores = 0;
            contPresas = 0;
        }

        public Depredador addDepredador(Vertex v, List<Point> l)
        {
            Depredador nuevo = new Depredador(v, contDepredadores++, l);

            if (InicioDepredador == null)
            {
                InicioDepredador = nuevo;
                finalDepredador = nuevo;
            }

            else
            {
                finalDepredador.Sig = nuevo;
                nuevo.Ant = finalDepredador;
                finalDepredador = nuevo;
            }
            return nuevo;
        }
        public Presa addPresa(Vertex v, List<Point> l)
        {
            Presa nuevo = new Presa(v, contPresas++, l);
            if (InicioPresa == null)
            {
                InicioPresa = nuevo;
                finalPresa = nuevo;
            }

            else
            {
                finalPresa.Sig = nuevo;
                nuevo.Ant = finalPresa;
                finalPresa = nuevo;
            }
            return nuevo;
        }
        public void setVision(int vision)
        {
            this.vision = vision;
        }
        public Reference addReference(Presa p, Depredador d)
        {
            Reference nuevo = new Reference(p, d);
            if (InicioReference == null)
            {
                InicioReference = nuevo;
                finalReference = nuevo;
            }

            else
            {
                finalReference.Sig = nuevo;
                nuevo.Ant = finalReference;
                finalReference= nuevo;
            }
            return nuevo;
        }
        public void deleteReference(Presa p, Depredador d)
        {
            Reference aux = InicioReference;
            while (aux != null)
            {
                if(aux.D == d && aux.P == p)
                {
                    aux.Ant.Sig = aux.Sig;
                    aux.Sig.Ant = aux.Ant;
                }
                aux = aux.Sig;
            }
        }
    }
    public class Depredador
    {
        private int ID;
        private int vel;
        private bool acechando;

        private int diametro;
        private int x;
        private int y;

        List<Point> line;
        int actualIndex;

        private Depredador sig;
        private Depredador ant;

        public Depredador(Vertex v, int ID, List<Point> l)
        {
            line = l;
            this.ID = ID;
            Diametro = v.CircunferenciaX;
            x = v.XPos;
            y = v.YPos;
            sig = null;
            vel = 1;
            actualIndex = 0;
        }

        public int Vel { get => vel; set => vel = value; }
        public bool Acechando { get => acechando; set => acechando = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Diametro { get => diametro; set => diametro = value; }
        public int ID1 { get => ID; set => ID = value; }
        internal Depredador Sig { get => sig; set => sig = value; }
        internal Depredador Ant { get => ant; set => ant = value; }
        public bool walk()
        {
            if (actualIndex + vel < line.Count)
            {
                actualIndex += vel;
                return true;
            }
            else
            {
                actualIndex = line.Count - 1;
                return false;
            }
        }
        public void setNewPath(List<Point> l)
        {
            actualIndex = 0;
            line = l;
        }
        public Point getPosition()
        {
            return new Point(line[actualIndex].X, line[actualIndex].Y);
        }

        public int getCont()
        {
            return line.Count;
        }

    }
    public class Presa
    {
        private int ID;
        private int life;
        private int x;
        private int y;
        private int diametro;
        private bool enPeligro;

        List<Point> line;
        int actualIndex;

        private Presa sig;
        private Presa ant;

        public Presa(Vertex v, int ID, List<Point> l)
        {
            line = l;
            this.ID = ID;
            Diametro = v.CircunferenciaX;
            sig = null;
            x = v.XPos;
            y = v.YPos;
            Life = 2;
            EnPeligro = false;

            line = l;
            actualIndex = 0;
        }

        public int Life { get => life; set => life = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Diametro { get => diametro; set => diametro = value; }
        public int ID1 { get => ID; set => ID = value; }
        internal Presa Sig { get => sig; set => sig = value; }
        internal Presa Ant { get => ant; set => ant = value; }
        public bool EnPeligro { get => enPeligro; set => enPeligro = value; }

        public void goal()
        {
            Life++;
        }
        public bool hit()
        {
            Life--;
            if (Life == 0)
                return false;
            return true;
        }
        public bool walk()
        {
            if (actualIndex + 1 < line.Count)
            {
                actualIndex += 1;
                return true;
            }
            else
            {
                actualIndex = line.Count - 1;
                return false;
            }
        }
        public void setNewPath(List<Point> l)
        {
            actualIndex = 0;
            line = l;
        }
        public Point getPosition()
        {
            return new Point(line[actualIndex].X, line[actualIndex].Y);
        }
        public int getCont()
        {
            return line.Count;
        }
        public int getActualIndex()
        {
            return actualIndex;
        }
        public Point getPositionAt(int n)
        {
            if (n == 0)
                return line[0];
            return line[line.Count - 1];
        }
    }

    public class Temporales
    {
        int pesoActual;
        Vertex v;
        Temporales previo; //apunta al que lo dejo venir xd

        Temporales sig;
        Temporales ant;

        public Temporales(Vertex v)
        {
            int pesoActual = -1;
            this.v = v;
            Sig = null;
            previo = null;
        }

        public int PA { get => pesoActual; set => pesoActual = value; }
        public Vertex V { get => v; set => v = value; }
        public Temporales Sig { get => sig; set => sig = value; }
        public Temporales Ant { get => ant; set => ant = value; }
        public Temporales Previo { get => previo; set => previo = value; }


    }
    public class Reference
    {
        Presa p;
        Depredador d;

        Reference sig;
        Reference ant;

        public Reference(Presa p, Depredador d)
        {
            this.D = d;
            this.P = p;
        }

        public Reference Sig { get => sig; set => sig = value; }
        public Reference Ant { get => ant; set => ant = value; }
        public Presa P { get => p; set => p = value; }
        public Depredador D { get => d; set => d = value; }
        public string toString()
        {
            return "El depredador " + d.ID1.ToString() + " acecha a " + p.ID1.ToString();
        }
    }
}
