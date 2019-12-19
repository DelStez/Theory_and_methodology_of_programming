using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab_Work5
{
    public partial class Form1 : Form
    {
        //
        
        DrawGraph G;
        List<Vertex> Vertexlist = new List<Vertex>();
        List<Edge> Edgelist;
        int[,] AMatrix;
        int w;

        int selected1;
        int selected2;

        public Form1()
        {
            InitializeComponent();
             
            G = new DrawGraph(workSpace.Width, workSpace.Height);
            Edgelist = new List<Edge>();
            workSpace.Image = G.GetMap();

        }
         
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(Vertexlist, Edgelist);
            workSpace.Image = G.GetMap();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(Vertexlist, Edgelist);
            workSpace.Image = G.GetMap();
            selected1 = -1;
            selected2 = -1;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(Vertexlist, Edgelist);
            workSpace.Image = G.GetMap();
        }
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            Vertexlist.Clear();
            Edgelist.Clear();
            G.clearSheet();
            workSpace.Image = G.GetMap();
            
        }
       

        private void getData_Click(object sender, EventArgs e)
        {
            // white = 0 grey = 1 black =2
            AMatrix = new int[Vertexlist.Count, Vertexlist.Count];
            listPaths.Items.Clear();
            listMatrix.Items.Clear();
            string sOut = "    ";
            G.fillAdjacencyMatrix(Vertexlist.Count, Edgelist, AMatrix);
            int[] status = new int[Vertexlist.Count];
            for (int k = 0; k < Vertexlist.Count; k++)
                status[k] = 0;
            foreach (Vertex q in Vertexlist)
            {
                //if(q)
            }
            //for (int i = 0; i < V.Count; i++)
            //{
            //    string s = "";
            //    w = 0;
            //    if (color[i] == 0)
            //        if (DFS(i, E, color,s))
            //        {

            //            listPaths.Items.Add(s);
            //        }
            //}
            for (int i = 0; i < Vertexlist.Count; i++)
                sOut += (i + 1) + " ";
            for (int i = 0; i < Vertexlist.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < Vertexlist.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listMatrix.Items.Add(sOut);
            }
        }
        private void DFS(int u, List<Edge> E, int[] color, string s)
        {
          
            //if (u != endV)
                
            //else
            //{
            //    listPaths.Items.Add(s);
            //    return;
            //}
            //for (int w = 0; w < E.Count; w++)
            //{
            //    if (color[E[w].Vertex2] != 2 && E[w].Vertex1 == u)
            //    {
            //        DFSchain(E[w].Vertex2, endV, E, color, s + "-" + (E[w].Vertex2 + 1).ToString());
            //        color[E[w].Vertex2] = 1;

            //    }
            //    else if (color[E[w].Vertex1] != 2 && E[w].Vertex2 == u)
            //    {
            //        DFSchain(E[w].Vertex1, endV, E, color, s + "-" + (E[w].Vertex1 + 1).ToString());
            //        color[E[w].Vertex1] = 1;
            //    }
            //}
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (drawVertexButton.Enabled == false)
            {
                Vertexlist.Add(new Vertex(e.X, e.Y));
                G.DrawVertex(e.X, e.Y, Vertexlist.Count.ToString());
                workSpace.Image = G.GetMap();
            }
            
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < Vertexlist.Count; i++)
                    {
                        if (Math.Pow((Vertexlist[i].x - e.X), 2) + Math.Pow((Vertexlist[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(Vertexlist[i].x, Vertexlist[i].y);
                                selected1 = i;
                                workSpace.Image = G.GetMap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(Vertexlist[i].x, Vertexlist[i].y);
                                selected2 = i;
                                Edgelist.Add(new Edge(selected1, selected2));
                                G.DrawEdge(Vertexlist[selected1], Vertexlist[selected2], Edgelist[Edgelist.Count - 1], Edgelist.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                workSpace.Image = G.GetMap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((Vertexlist[selected1].x - e.X), 2) + Math.Pow((Vertexlist[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.DrawVertex(Vertexlist[selected1].x, Vertexlist[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        workSpace.Image = G.GetMap();
                    }
                }
            }
            if (deleteButton.Enabled == false)
            {
                bool flag = false;
                for (int i = 0; i < Vertexlist.Count; i++)
                {
                    if (Math.Pow((Vertexlist[i].x - e.X), 2) + Math.Pow((Vertexlist[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < Edgelist.Count; j++)
                        {
                            if ((Edgelist[j].Vertex1 == i) || (Edgelist[j].Vertex2 == i))
                            {
                                Edgelist.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (Edgelist[j].Vertex1 > i) Edgelist[j].Vertex1--;
                                if (Edgelist[j].Vertex2 > i) Edgelist[j].Vertex2--;
                            }
                        }
                        Vertexlist.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                
                if (!flag)
                {
                    for (int i = 0; i < Edgelist.Count; i++)
                    {
                        if (Edgelist[i].Vertex1 == Edgelist[i].Vertex2)
                        {
                            if ((Math.Pow((Vertexlist[Edgelist[i].Vertex1].x - G.R - e.X), 2) + Math.Pow((Vertexlist[Edgelist[i].Vertex1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((Vertexlist[Edgelist[i].Vertex1].x - G.R - e.X), 2) + Math.Pow((Vertexlist[Edgelist[i].Vertex1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                Edgelist.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else
                        {
                            if (((e.X - Vertexlist[Edgelist[i].Vertex1].x) * (Vertexlist[Edgelist[i].Vertex2].y - Vertexlist[Edgelist[i].Vertex1].y) / (Vertexlist[Edgelist[i].Vertex2].x - Vertexlist[Edgelist[i].Vertex1].x) + Vertexlist[Edgelist[i].Vertex1].y) <= (e.Y + 4) &&
                                ((e.X - Vertexlist[Edgelist[i].Vertex1].x) * (Vertexlist[Edgelist[i].Vertex2].y - Vertexlist[Edgelist[i].Vertex1].y) / (Vertexlist[Edgelist[i].Vertex2].x - Vertexlist[Edgelist[i].Vertex1].x) + Vertexlist[Edgelist[i].Vertex1].y) >= (e.Y - 4))
                            {
                                if ((Vertexlist[Edgelist[i].Vertex1].x <= Vertexlist[Edgelist[i].Vertex2].x && Vertexlist[Edgelist[i].Vertex1].x <= e.X && e.X <= Vertexlist[Edgelist[i].Vertex2].x) ||
                                    (Vertexlist[Edgelist[i].Vertex1].x >= Vertexlist[Edgelist[i].Vertex2].x && Vertexlist[Edgelist[i].Vertex1].x >= e.X && e.X >= Vertexlist[Edgelist[i].Vertex2].x))
                                {
                                    Edgelist.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(Vertexlist, Edgelist);
                    workSpace.Image = G.GetMap();
                }
            }
        }

        
    }
}
