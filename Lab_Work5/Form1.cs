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
        
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        int[,] AMatrix;
        int w;

        int selected1;
        int selected2;

        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(workSpace.Width, workSpace.Height);
            E = new List<Edge>();
            workSpace.Image = G.GetMap();

        }
         
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            workSpace.Image = G.GetMap();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
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
            G.drawALLGraph(V, E);
            workSpace.Image = G.GetMap();
        }
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            V.Clear();
            E.Clear();
            G.clearSheet();
            workSpace.Image = G.GetMap();
            
        }
       

        private void getData_Click(object sender, EventArgs e)
        {
            AMatrix = new int[V.Count, V.Count];
            listPaths.Items.Clear();
            listMatrix.Items.Clear();
            string sOut = "    ";
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            int[] color = new int[V.Count];
            for (int k = 0; k < V.Count; k++)
                color[k] = 0;
            for (int i = 0; i < V.Count; i++)
            {
                string s = "";
                w = 0;
                if (color[i] == 0)
                    if (DFS(i, E, color,s))
                    {
                        
                        listPaths.Items.Add(s);
                    }
            }
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            for (int i = 0; i < V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listMatrix.Items.Add(sOut);
            }
        }
        private bool DFS(int u, List<Edge> E, int[] color, string s)
        {
            color[u] = 1;
            // white = 0; grey = 1; black = 2
            for (w = 0; w < E.Count; w++)
            {

                if(color[E[w].Vertex2] == 1) s += u.ToString() + "-" + (E[w].Vertex2 + 1).ToString();
                if (color[E[w].Vertex2] == 1 && (DFS(u, E, color, s) == true)) return true; 
            }
            color[u] = 2;
            return false;
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
                V.Add(new Vertex(e.X, e.Y));
                G.DrawVertex(e.X, e.Y, V.Count.ToString());
                workSpace.Image = G.GetMap();
            }
            
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                workSpace.Image = G.GetMap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                G.DrawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
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
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.DrawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        workSpace.Image = G.GetMap();
                    }
                }
            }
            if (deleteButton.Enabled == false)
            {
                bool flag = false;
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].Vertex1 == i) || (E[j].Vertex2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].Vertex1 > i) E[j].Vertex1--;
                                if (E[j].Vertex2 > i) E[j].Vertex2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].Vertex1 == E[i].Vertex2)
                        {
                            if ((Math.Pow((V[E[i].Vertex1].x - G.R - e.X), 2) + Math.Pow((V[E[i].Vertex1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].Vertex1].x - G.R - e.X), 2) + Math.Pow((V[E[i].Vertex1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else
                        {
                            if (((e.X - V[E[i].Vertex1].x) * (V[E[i].Vertex2].y - V[E[i].Vertex1].y) / (V[E[i].Vertex2].x - V[E[i].Vertex1].x) + V[E[i].Vertex1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].Vertex1].x) * (V[E[i].Vertex2].y - V[E[i].Vertex1].y) / (V[E[i].Vertex2].x - V[E[i].Vertex1].x) + V[E[i].Vertex1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].Vertex1].x <= V[E[i].Vertex2].x && V[E[i].Vertex1].x <= e.X && e.X <= V[E[i].Vertex2].x) ||
                                    (V[E[i].Vertex1].x >= V[E[i].Vertex2].x && V[E[i].Vertex1].x >= e.X && e.X >= V[E[i].Vertex2].x))
                                {
                                    E.RemoveAt(i);
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
                    G.drawALLGraph(V, E);
                    workSpace.Image = G.GetMap();
                }
            }
        }

        
    }
}
