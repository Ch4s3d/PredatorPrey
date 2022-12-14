using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VertexLocation
{
    public partial class MainForm : Form
    {
        ImageProcess lab;
        Font font;
        SolidBrush brusho;
        SolidBrush brushr;
        SolidBrush brushg;
        SolidBrush brushy;
        SolidBrush brushb;
        Brush VertexBrush;
        Vertex meta;
        bool ready;
        bool precionadoPresas;
        bool precionadoDepredadores;
        Game game;
        int inc = 5;
        Random rand = new Random();

        Temporales candidatos;
        public MainForm()
        {
            InitializeComponent();
            font = new Font("Arial", 16);
            brusho = new SolidBrush(Color.Orange);
            brushr = new SolidBrush(Color.Red);
            brushg = new SolidBrush(Color.Green);
            brushy = new SolidBrush(Color.Yellow);
            brushb = new SolidBrush(Color.Black);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inicializar
            lab = new ImageProcess();
            pictureShowing.Image = null;
            richResumen.Text = "";
            lab.Inicio = null;
            treeGrafo.Nodes.Clear();
            meta = null;
            ready = false;
            game = null;
            buttonsStage(1);

            //meter cosas
            pictureShowing.Image = lab.imageAsk();
            if (pictureShowing.Image != null)
            {
                richResumen.Text += "\n" + "Centroides: " + lab.Centroides + "\n\n";

                Vertex aux = lab.Inicio;
                lab.Imagen.ImgGpxIdentif = Graphics.FromImage(lab.Imagen.Img);

                while (aux != null)
                {
                    richResumen.Text += "Circulo " + aux.NumeroVertex + ": " + aux.readVertex() + "\n\n";
                    lab.Imagen.ImgGpxIdentif.DrawString(aux.NumeroVertex.ToString(), font, brushr, aux.XPos - 8, aux.YPos - 8);

                    aux = aux.Sig;
                }
                aux = lab.Inicio;

                for (int i = 0; aux != null; i++)
                {
                    Vertex aux2 = aux.Sig;

                    while (aux2 != null)
                    {
                        //Drawing

                        int peso = drawline(aux, aux2);
                        if (peso != -1)
                        {
                            lab.Imagen.ImgGpx.DrawLine(new Pen(Brushes.Green), aux.XPos, aux.YPos, aux2.XPos, aux2.YPos);
                            aux.addEdge(aux2, peso);
                        }
                        aux2 = aux2.Sig;
                    }
                    aux = aux.Sig;
                }
                buttonsStage(0);
                treeGrafo.Nodes.Add("Meta");
                treeGrafo.Nodes.Add("Depredadores");
                treeGrafo.Nodes.Add("Presa");
                treeGrafo.Nodes[0].Nodes.Add("No seleccionado");
                MessageBox.Show("Presiona el boton 'Presa' o 'Depredador' para entrar al modo selección, cuando termines de elegir preciona el mismo botón para salir");
                game = new Game();
                lab.Imagen.ImgBitmapGame = lab.Imagen.ImgBitmap.Clone(Rectangle.FromLTRB(0, 0, lab.Imagen.ImgBitmap.Width, lab.Imagen.ImgBitmap.Height), lab.Imagen.ImgBitmap.PixelFormat);
                lab.Imagen.G = Graphics.FromImage(lab.Imagen.ImgBitmapGame);
                pictureShowing.Image = lab.Imagen.ImgBitmapGame;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private int drawline(Vertex origen, Vertex destino)
        {
            int xo = origen.XPos, yo = origen.YPos, xf = destino.XPos, yf = destino.YPos;
            float m, b;
            if (xf - xo == 0)
                for (int yi = yo; yi < yf; yi++)
                {
                    Color pixel = lab.Imagen.ImgBitmapOrig.GetPixel(xo, yi);
                    //if (cont > origen.CircunferenciaX + 5 && cont < (lab.euclidianDistance(xo, yo, xf, yf) - (destino.CircunferenciaX - 5)) && !pixel.ToArgb().Equals(Color.White.ToArgb()))
                    if ((pixel.R > 200 && pixel.G < 50 && pixel.B < 50) || (pixel.G > 200 && pixel.B < 50 && pixel.R < 50) || (pixel.B > 200 && pixel.R < 50 && pixel.G < 50))
                        return -1;

                    //lab.Imagen.ImgBitmap.SetPixel(xo, yi, Color.Yellow);
                }
            else
            {
                m = ((float)yf - (float)yo) / ((float)xf - (float)xo);
                b = (float)yo - m * (float)xo;
                if (xf < xo)
                    for (float xi = xo, yi; xi >= xf; xi--)
                    {
                        yi = m * xi + b;
                        for (float aux = yi; aux <= (m * (xi - 1) + b) && aux <= yf; aux++)
                        {
                            Color pixel = lab.Imagen.ImgBitmapOrig.GetPixel((int)Math.Round(xi), (int)Math.Round(aux));
                            //if (cont > origen.CircunferenciaX + 5 && cont < (lab.euclidianDistance(xo, yo, xf, yf) - (destino.CircunferenciaX - 5)) && !pixel.ToArgb().Equals(Color.White.ToArgb()))
                            if ((pixel.R > 200 && pixel.G < 50 && pixel.B < 50) || (pixel.G > 200 && pixel.B < 50 && pixel.R < 50) || (pixel.B > 200 && pixel.R < 50 && pixel.G < 50))
                                return -1;

                            //lab.Imagen.ImgBitmap.SetPixel((int)Math.Round(xi), (int)Math.Round(aux), Color.Orange);
                        }
                    }

                else
                    for (float xi = xo, yi; xi <= xf; xi++)
                    {
                        yi = m * xi + b;
                        for (float aux = yi; aux <= (m * (xi + 1) + b) && aux <= yf; aux++)
                        {
                            Color pixel = lab.Imagen.ImgBitmapOrig.GetPixel((int)Math.Round(xi), (int)Math.Round(aux));
                            //if (cont > origen.CircunferenciaX + 5 && cont < (lab.euclidianDistance(xo, yo, xf, yf) - (destino.CircunferenciaX - 5)) && !pixel.ToArgb().Equals(Color.White.ToArgb()))
                            if ((pixel.R > 200 && pixel.G < 50 && pixel.B < 50) || (pixel.G > 200 && pixel.B < 50 && pixel.R < 50) || (pixel.B > 200 && pixel.R < 50 && pixel.G < 50))
                                return -1;

                            //lab.Imagen.ImgBitmap.SetPixel((int)Math.Round(xi), (int)Math.Round(aux), Color.Red);
                        }
                    }
            }
            return lab.euclidianDistance(xo, yo, xf, yf);
        }
        private void btnID_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (lab != null)
                if (lab.Imagen != null)
                    pictureShowing.Image = lab.Imagen.Img;
        }
        private void btnID_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (lab == null || lab.Imagen == null && lab.Imagen.ImgBitmap == null)
                return;

            pictureShowing.Image = lab.Imagen.ImgBitmap;

            if(game.InicioDepredador != null || game.InicioPresa != null)
                update();
        }
        Point PictureBox2bmpCoordinates(int x, int y, Bitmap bmp)
        {
            float w_p, h_p;
            float w_i, h_i;
            float x_p, y_p;
            float x_i, y_i;
            float k, k_2;
            float d_x, d_y;
            x_p = x;
            y_p = y;
            w_p = pictureShowing.Width;
            h_p = pictureShowing.Height;
            w_i = bmp.Width;
            h_i = bmp.Height;
            k = w_p / w_i;
            k_2 = h_p / h_i;
            if (k_2 < k)
                k = k_2;
            d_x = (w_p - k * w_i) / 2;
            d_y = (h_p - k * h_i) / 2;

            x_i = (x_p - d_x) / k;
            y_i = (y_p - d_y) / k;

            return new Point((int)Math.Round(x_i), (int)Math.Round(y_i));
        }
        private void btnPresas_Click(object sender, EventArgs e)
        {
            if(precionadoPresas == false)
            {
                precionadoPresas = true;
                btnDepredadores.Enabled = false;
            }
            else
            {
                precionadoPresas = false;
                btnDepredadores.Enabled = true; ;
            }
        }
        private void btnDepredadores_Click(object sender, EventArgs e)
        {
            if (precionadoDepredadores == false)
            {
                precionadoDepredadores = true;
                btnPresas.Enabled = false;
            }
            else
            {
                precionadoDepredadores = false;
                btnPresas.Enabled = true; ;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lab.Imagen.ImgBitmapGame = lab.Imagen.ImgBitmap.Clone(Rectangle.FromLTRB(0, 0, lab.Imagen.ImgBitmap.Width, lab.Imagen.ImgBitmap.Height), lab.Imagen.ImgBitmap.PixelFormat);
            pictureShowing.Image = lab.Imagen.ImgBitmapGame;
            treeGrafo.Nodes.Clear();
            game = new Game();
            treeGrafo.Nodes.Add("Meta");
            treeGrafo.Nodes.Add("Depredadores");
            treeGrafo.Nodes.Add("Presa");
            treeGrafo.Nodes[0].Nodes.Add("No seleccionado");
            precionadoDepredadores = false;
            precionadoPresas = false;
            buttonsStage(1);
        }
        private void btnManualSort_Click(object sender, EventArgs e)
        {
            btnManualSort.Enabled = false;
            btnAutoSort.Enabled = false;
            btnPresas.Enabled = true;
            btnDepredadores.Enabled = true;
        }
        private void buttonsStage(int op)
        {
            switch (op)
            {
                case 0:
                    numericVision.Enabled = true;
                    btnStart.Enabled = true;
                    btnID.Enabled = true;
                    btnManualSort.Enabled = true;
                    btnAutoSort.Enabled = true;
                    btnAutoSort.Enabled = true;
                    btnClear.Enabled = true;
                    break;
                case 1:
                    btnAutoSort.Enabled = true;
                    btnDepredadores.Enabled = false;
                    btnPresas.Enabled = false;
                    btnManualSort.Enabled = true;
                    break;
                case 2:
                    numericVision.Enabled = false;
                    btnID.Enabled = false;
                    btnManualSort.Enabled = false;
                    btnAutoSort.Enabled = false;
                    btnAutoSort.Enabled = false;
                    btnPresas.Enabled = false;
                    btnDepredadores.Enabled = false;
                    btnClear.Enabled = false;
                    break;
            }
        }
        private void numericVision_ValueChanged(object sender, EventArgs e)
        {
            update();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            precionadoPresas = false;
            precionadoDepredadores = false;
            if (!ready)
            {
                ready = true;
                btnStart.Text = "Stop";
                buttonsStage(2);
            }
            else
            {
                ready = false;
                btnStart.Text = "Start";
                buttonsStage(0);
            }
            //animacion
            Animation();
        }
        public List<Point> makeLine(int x, int y, Point p_0)
        {
            List<Point> line = new List<Point>();

            int xo = x, yo = y, xf = p_0.X, yf = p_0.Y;
            float m, b;
            if (xf - xo == 0)
                for (int yi = yo; yi < yf; yi++)
                    line.Add(new Point(xo, yi));
            else
            {
                m = ((float)yf - (float)yo) / ((float)xf - (float)xo);
                b = (float)yo - m * (float)xo;
                if (xf < xo)
                    for (float xi = xo, yi; xi >= xf; xi--)
                    {
                        yi = m * xi + b;
                        for (float aux = yi; aux <= (m * (xi - 1) + b) && aux <= yf; aux++)
                            line.Add(new Point((int)Math.Round(xi), (int)Math.Round(aux)));
                    }

                else
                    for (float xi = xo, yi; xi <= xf; xi++)
                    {
                        yi = m * xi + b;
                        for (float aux = yi; aux <= (m * (xi + 1) + b) && aux <= yf; aux++)
                        line.Add(new Point((int)Math.Round(xi), (int)Math.Round(aux)));
                    }
            }
            Console.WriteLine("Returned line cont: " + line.Count);
            return line;
        }
        private List<Vertex> Dijkstra(Presa p)
        {
            candidatos = null;
            List<Temporales> definitivos = new List<Temporales>();

            // 0.Crear la lista de candidatos

            Vertex no = lab.Inicio;
            while(no != null)
            {
                addCandidato(no);
                no = no.Sig;
            }

            // 1. Revisar si la presa está en un vertice o no y moverlo hacia el más cercano


            int aI = p.getActualIndex();

            Vertex aux = lab.belongsTo(p.getPosition().X, p.getPosition().Y);

            if (aux == null)
            {
                if (aI < p.getCont() / 2)
                    aux = lab.belongsTo(p.getPositionAt(0).X, p.getPositionAt(0).Y);
                else
                    aux = lab.belongsTo(p.getPositionAt(1).X, p.getPositionAt(1).Y);
            }

            //Actualizar el peso de los candidatos

            Edge f = aux.Inicio;
            while (f != null)
            {
                actualizarPesoCandidatos(f, 0);
                f = f.Sig;
            }

            //Remover Candidato

            definitivos.Add(buscarTemporal(aux));
            borrarCandidato(aux);

            // Inicio del bucle

            int pesoAcumulado = 0;
            while (!solucion(definitivos))
            {
                pesoAcumulado += smallestOnList().PA;
                Vertex e = smallestOnList().V;
                borrarCandidato(e);
                definitivos.Add(buscarTemporal(e));

                Edge g = aux.Inicio;
                while (g != null)
                {
                    actualizarPesoCandidatos(g, pesoAcumulado);
                    g = g.Sig;
                }

            }

            List<Vertex> sol = new List<Vertex>();
            Temporales aux2 = definitivos[definitivos.Count - 1];
            while (aux2 != null)
            { 
                sol.Add(aux2.V);
                aux2 = aux2.Previo;
            }

            return sol;
        }
        private Temporales smallestOnList()
        {
            Temporales list = candidatos.Sig;
            Temporales smallest = candidatos;
            while (list != null)
            {
                if (smallest.PA > list.PA)
                    smallest = list;
                list = list.Sig;
            }
            return smallest;
        }
        private bool solucion(List<Temporales> l)
        {
            for (int i = 0; i < l.Count; i++)
                if (l[i].V == meta)
                    return true;
            return false;
        }
        private void addCandidato(Vertex v)
        {
            Temporales nuevo = new Temporales(v);
            if (candidatos == null)
                candidatos = nuevo;
            else
            {
                Temporales aux = candidatos;
                while(aux.Sig != null)
                    aux = aux.Sig;
                aux.Sig = nuevo;
                nuevo.Ant = aux;
            }
        }
        private void borrarCandidato(Vertex v)
        {
            Temporales aux = candidatos;
            while (aux != null)
            {
                if(aux.V == v)
                {
                    v.Ant.Sig = v.Sig;
                    v.Sig.Ant = v.Ant;
                }
                aux = aux.Sig;
            }
        }
        private void actualizarPesoCandidatos(Edge e, int pesoAcumulado)
        {
            Temporales t = candidatos;
            while (t != null)
            {
                if(t.V == e.Actual) //si el que te llegas es mas grande no lo tomes, si si cambia el previo y el peso;
                {
                    t.PA = e.Peso + pesoAcumulado;
                    //t.Previo = e.Ant;
                }
                t = t.Sig;
            }
        }
        private Temporales buscarTemporal(Vertex v)
        {
            Temporales aux = candidatos;
            while (aux != null)
            {
                if (aux.V == v)
                    return aux;
                aux = aux.Sig;
            }
            return null;
        }

        private void pictureShowing_MouseClick(object sender, MouseEventArgs e)
        {
            if (lab == null || pictureShowing.Image == null)
                return;

            if (ready)
            {
                game.setVision((int)numericVision.Value);

                Point p = PictureBox2bmpCoordinates(e.X, e.Y, lab.Imagen.ImgBitmap);
                Vertex v = lab.belongsTo(p.X, p.Y);
                meta = v;

                VertexBrush = brushy;
                Vertex v_o;
                Vertex c_o;
                int r_o, x_o, y_o;
                int inc = 5;
                v_o = meta;
                c_o = v_o;
                if (c_o == null)
                {
                    meta = null;
                    return;
                }

                r_o = (int)c_o.CircunferenciaX;
                x_o = (int)c_o.XPos;
                y_o = (int)c_o.YPos;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                treeGrafo.Nodes[0].Nodes[0].Text = "Vertice " + v.NumeroVertex.ToString();

                pictureShowing.Refresh();
            }
            else if(precionadoPresas)
            {

                Point p = PictureBox2bmpCoordinates(e.X, e.Y, lab.Imagen.ImgBitmap);
                Vertex v = lab.belongsTo(p.X, p.Y);
                if (v == null)
                    return;

                VertexBrush = brushg;
                Vertex v_o;
                Vertex c_o;
                int r_o, x_o, y_o;
                int inc = 5;
                v_o = v;
                c_o = v_o;
                r_o = (int)c_o.CircunferenciaX;
                x_o = (int)c_o.XPos;
                y_o = (int)c_o.YPos;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                List<Point> points = new List<Point>();
                points.Add(new Point(x_o, y_o));
                Presa g = game.addPresa(v, points);
                VertexBrush = brushb;
                lab.Imagen.G.DrawString(g.Life.ToString(), font, VertexBrush, g.getPosition().X - (g.Diametro), g.getPosition().Y - (g.Diametro));
                treeGrafo.Nodes[2].Nodes.Add(g.ID1.ToString());

                pictureShowing.Refresh();
            }
            else if (precionadoDepredadores)
            {

                Point p = PictureBox2bmpCoordinates(e.X, e.Y, lab.Imagen.ImgBitmap);
                Vertex v = lab.belongsTo(p.X, p.Y);
                if (v == null)
                    return;

                VertexBrush = brushr;
                Vertex v_o;
                Vertex c_o;
                int r_o, x_o, y_o;
                int inc = 5;
                v_o = v;
                c_o = v_o;
                r_o = (int)c_o.CircunferenciaX;
                x_o = (int)c_o.XPos;
                y_o = (int)c_o.YPos;
                VertexBrush = brusho;
                int a = (int)numericVision.Value;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc - a, y_o - r_o - inc - a, 2 * (r_o + inc + a), 2 * (r_o + inc + a));
                VertexBrush = brushr;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));

                List<Point> points = new List<Point>();
                points.Add(new Point(x_o, y_o));
                Depredador g = game.addDepredador(v, points);
                treeGrafo.Nodes[1].Nodes.Add(g.ID1.ToString());

                pictureShowing.Refresh();
            }
        }
        private void btnAutoSort_Click(object sender, EventArgs e)
        {
            int mitad = lab.ContCirculos / 2;
            int numeroDePresas = rand.Next(1, mitad);
            int numeroDeDepredadores = rand.Next(1, mitad);

            Vertex v;
            Vertex v_o;
            Vertex c_o;

            for (int i=0; i<numeroDePresas; i++)
            {
                v = lab.getVertexAt(rand.Next(0, lab.ContCirculos-1));
                VertexBrush = brushg;
                int r_o, x_o, y_o;
                int inc = 5;
                v_o = v;
                c_o = v_o;
                r_o = (int)c_o.CircunferenciaX;
                x_o = (int)c_o.XPos;
                y_o = (int)c_o.YPos;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                List<Point> points = new List<Point>();
                points.Add(new Point(x_o, y_o));
                Presa g = game.addPresa(v, points);
                treeGrafo.Nodes[2].Nodes.Add(g.ID1.ToString());
                VertexBrush = brushb;
                lab.Imagen.G.DrawString(g.Life.ToString(), font, VertexBrush, g.getPosition().X - (g.Diametro), g.getPosition().Y - (g.Diametro));

                pictureShowing.Refresh();
            }

            for (int i = 0; i < numeroDeDepredadores; i++)
            {
                v = lab.getVertexAt(rand.Next(0, lab.ContCirculos - 1));
                VertexBrush = brushr;
                int r_o, x_o, y_o;
                int inc = 5;
                v_o = v;
                c_o = v_o;
                r_o = (int)c_o.CircunferenciaX;
                x_o = (int)c_o.XPos;
                y_o = (int)c_o.YPos;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                List<Point> points = new List<Point>();
                points.Add(new Point(x_o, y_o));
                Depredador g = game.addDepredador(v, points);
                treeGrafo.Nodes[2].Nodes.Add(g.ID1.ToString());

                pictureShowing.Refresh();
            }
        }
        public void update()
        {
            if (game.InicioDepredador == null)
                return;

            lab.Imagen.ImgBitmapGame.Dispose();
            lab.Imagen.ImgBitmapGame = lab.Imagen.ImgBitmap.Clone(Rectangle.FromLTRB(0, 0, lab.Imagen.ImgBitmap.Width, lab.Imagen.ImgBitmap.Height), lab.Imagen.ImgBitmap.PixelFormat);
            lab.Imagen.G.Dispose();
            lab.Imagen.G = Graphics.FromImage(lab.Imagen.ImgBitmapGame);
            pictureShowing.Image = lab.Imagen.ImgBitmapGame;

            Depredador d = game.InicioDepredador;
            Presa z = game.InicioPresa;

            int r_o, x_o, y_o;

            if(meta != null)
            {
                r_o = meta.CircunferenciaX;
                x_o = meta.XPos;
                y_o = meta.YPos;
                VertexBrush = brushy;
                lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));

                //pictureShowing.Refresh();
            }

            while (d != null)
            {
                    x_o = (int)d.getPosition().X;
                    y_o = (int)d.getPosition().Y;
                    r_o = (int)d.Diametro;

                    VertexBrush = brusho;
                    int a = (int)numericVision.Value;
                    lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc - a, y_o - r_o - inc - a, 2 * (r_o + inc + a), 2 * (r_o + inc + a));
                    VertexBrush = brushr;
                    lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                    d = d.Sig;

                    //pictureShowing.Refresh();
                
            }

            while (z != null)
            {
                    x_o = (int)z.getPosition().X;
                    y_o = (int)z.getPosition().Y;
                    r_o = (int)z.Diametro;

                    int a = (int)numericVision.Value;
                    VertexBrush = brushg;
                    lab.Imagen.G.FillEllipse(VertexBrush, x_o - r_o - inc, y_o - r_o - inc, 2 * (r_o + inc), 2 * (r_o + inc));
                VertexBrush = brushb;
                lab.Imagen.G.DrawString(z.Life.ToString(), font, VertexBrush, z.getPosition().X - (z.Diametro), z.getPosition().Y - (z.Diametro));
                    z = z.Sig;


                    //pictureShowing.Refresh();
                
            }
            pictureShowing.Refresh();
        }
        public void Animation()
        {
            //Depredador a = game.InicioDepredador;

            //while (true /*Alguna presa siga viva*/)
            //{

            //    while (a != null)
            //    {
            //        Vertex b = lab.belongsTo(a.getPosition().X, a.getPosition().Y);
            //        //Vertex y = lab.belongsTo(x.getPosition().X, x.getPosition().Y);

            //        if (b != null)
            //        {
            //            Edge e = b.getEdgeAt(rand.Next(0, b.EdgeCont));
            //            a.setNewPath(makeLine(a.getPosition().X, a.getPosition().Y, new Point(e.Actual.XPos, e.Actual.YPos)));
            //            if (!a.Acechando)
            //            {
            //                Presa p = game.InicioPresa;
            //                while (p != null)
            //                {
            //                    if (lab.euclidianDistance(a.getPosition().X, a.getPosition().Y, p.getPosition().X, p.getPosition().Y) < (int)numericVision.Value && a.Acechando == false)
            //                    {
            //                        p.EnPeligro = true;
            //                        a.Acechando = true;
            //                        game.addReference(p, a);
            //                        updateReferences();
            //                    }
            //                    p = p.Sig;
            //                }
            //            }
            //        }
            //        if (a.getCont() > 1)
            //            a.walk();
            //        a = a.Sig;
            //    }
            //    while (x != null)
            //    {
            //        if (y != null)
            //        {
            //            x.setNewPath(makeLine(x.getPosition().X, x.getPosition().Y, new Point(y.Inicio.Actual.XPos, y.Inicio.Actual.YPos)));
            //            x.walk();
            //        }
            //        x = x.Sig;
            //    }
            //    update();
            //}

            Depredador a = game.InicioDepredador;
            Vertex b = lab.belongsTo(a.getPosition().X, a.getPosition().Y);
            while (b.Inicio != null)
            {

                a.setNewPath(makeLine(a.getPosition().X, a.getPosition().Y, new Point(b.Inicio.Actual.XPos, b.Inicio.Actual.YPos)));
                

                for (int j = 0; j < a.getCont(); j++)
                {
                    a.walk();
                    update();
                }
                b = lab.belongsTo(a.getPosition().X, a.getPosition().Y);
            }
    }
    private void updateReferences()
        {
            richResumen.Text = "";
            Reference aux = game.InicioReference;
            Presa p = game.InicioPresa;
            Depredador d = game.InicioDepredador;

            while (p != null)
            {
                richResumen.Text = "Presa " + p.ID1.ToString() + "Estado: ";
                if (p.EnPeligro)
                    richResumen.Text += "En peligro";
                else richResumen.Text += "A salvo";
                richResumen.Text += "\n";
                p = p.Sig;
            }

            while (d != null)
            {
                richResumen.Text = "Depredador " + d.ID1.ToString() + "Estado: ";
                if (d.Acechando)
                    richResumen.Text += "Acechando";
                else richResumen.Text += "Chillin";
                richResumen.Text += "\n";
                d = d.Sig;
            }

            while (aux != null)
            {
                richResumen.Text += aux.toString();
                aux = aux.Sig;
            }
        }
    }
}