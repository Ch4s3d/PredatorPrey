# Prey-and-predator
Algorithmics project (In progress)

The objective is to create a project attached to reality for image processing, understanding the most important algorithms, with a focus on Dijkstra, understanding dynamic memory.

The Dijkstra algorithm, also called the least paths algorithm, is an algorithm for determining the shortest path, given an origin vertex,  towards the rest of the vertices in a graph that has weights on each edge. Its name alludes to Edsger Dijkstra, a computer scientist from the Netherlands who first described it in 1959.

Design a computer system that simulates the behavior of "prey" and "predatory" entities in an environment. Next, the rules that define the behavior of these entities are described, the scenario in which they develop will be represented by a graph, for the generation of the graph images (each pixel represents a meter) containing black circles (vertices of graph) and any number of obstacles that prevent one vertex from connecting with another. The vertices are "safe zones", in a vertex, the predator cannot attack the prey. The stages measure 1000 x 1300 pixels.

Prey.
Entity that seeks to reach an objective vertex. Multiple dams can exist in the same environment, if there is no target in the graph, the dams remain at one vertex and simulation (animation) cannot be performed.
The dam has a counter that indicates the resistance it has (mandatory variable in the implementation), starts at 2 and gains a counter each time it reaches a goal. Each time a predator reaches it, it has a counter left. If a prey is hit by a predator, its resistance counter decreases one by one, if the resistance counter is zero, the prey disappears.
The prey knows the whole graph and will try to go to the target using the shortest path (Dijkstra's algorithm), but if it is stalked, it will change its behavior to safeguard it. Prey can make decisions about where to go at any time, even while walking along a ridge. The prey knows when a predator is stalking it, it knows the predator, where it comes from and where it is going at every moment.

Predator
The objective of predators is to reach a prey, they know the prey that are in a maximum of r (mandatory variable in implementation) meters around it, but they can only stalk one, as long as it is not being stalked by another predator. The closer the predator is to the prey, the faster the predator will have (it is calculated at every moment). If a predator does not detect prey in its radius, it runs through the graph randomly. There may be multiple predators in the environment. A predator can only have one prey lurking. The predator knows the current position of the stalking prey. The predator can change its stalked prey at any time.
When a predator makes the decision to walk an edge, it must finish traveling it to make a new decision. The predator can choose to stay at a vertex. Each time a predator hits a prey, it takes a resistance counter from the prey.

Summary:

Ability to select the scene (image)
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
          
Show the image representing the graph
  
  pictureShowing.Image = lab.imageAsk();
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

Select the vertex where you want to place each prey and each predator

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

Initialize Prey and Predator Positions Randomly

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
        
Ability to select a “target” vertex (for dams)
    
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
            } …

Relationship “predator - stalked prey”, if one exists, dams in danger and predators stalking.

I created a class called "References", where the predator and prey in action are currently saved, then it is only necessary to update the letters in the richTextBox. Prey and predators are also updated so that their current status can be given (eg, endangered, stalking, safe, etc).

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

Graphic representation of the resistance counters of the dams.

    Al momento de hacer el update, se toma el valor de vidas de la presa y se escribe en un Graphics
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

![Imagen1](https://user-images.githubusercontent.com/74276682/130079907-6fa217ed-c93b-478c-8da9-3a0dfb6b98ea.png)

    
