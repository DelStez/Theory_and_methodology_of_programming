using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work5
{
    class Vertex
    {
        public int x, y;
        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Edge
    {
        public int Vertex1, Vertex2;
        public Edge(int Vertex1, int Vertex2)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
        }

    }
    class DrawGraph 
    {
        Bitmap map;
        Pen MainBlackPen, AddonRedPen, PathDarkBlue;
        Graphics graphsM;
        Font VertexName;
        Brush br;
        PointF point;
        public int R = 15;
        public DrawGraph(int Widht, int Height)
        {
            map = new Bitmap(Widht, Height);
            graphsM = Graphics.FromImage(map);
            clearSheet();
            MainBlackPen = new Pen(Color.Black); MainBlackPen.Width = 2;
            AddonRedPen = new Pen(Color.Red); AddonRedPen.Width = 2;
            PathDarkBlue = new Pen(Color.DarkBlue); PathDarkBlue.Width = 2;
            VertexName = new Font("Arial", 11);
            br = Brushes.Black;

        }
        public void drawSelectedVertex(int x, int y)
        {
            graphsM.DrawEllipse(AddonRedPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        public Bitmap GetMap()
        {
            return map;
        }
        public void clearSheet()
        {
            Color c = Color.FromArgb(235, 237, 236);   
            graphsM.Clear(c);
        }
        
        public void DrawVertex(int x, int y, string number)
        {
            graphsM.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            graphsM.DrawEllipse(MainBlackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF((x-R)+5, (y-R)+5);
            graphsM.DrawString(number, VertexName, br, point);
        }
        public  void DrawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            if (E.Vertex1 == E.Vertex2)
            {
                graphsM.DrawArc(PathDarkBlue, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));

                DrawVertex(V1.x, V1.y, (E.Vertex1 + 1).ToString());
            }
            else
            {
                graphsM.DrawLine(PathDarkBlue, V1.x, V1.y, V2.x, V2.y);
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                DrawVertex(V1.x, V1.y, (E.Vertex1 + 1).ToString());
                DrawVertex(V2.x, V2.y, (E.Vertex2 + 1).ToString());
            }
        }
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].Vertex1, E[i].Vertex2] = 1;
                matrix[E[i].Vertex2, E[i].Vertex1] = 1;
            }
        }
        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].Vertex1 == E[i].Vertex2)
                {
                    graphsM.DrawArc(PathDarkBlue, (V[E[i].Vertex1].x - 2 * R), (V[E[i].Vertex1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].Vertex1].y - (int)(2.75 * R), V[E[i].Vertex1].y - (int)(2.75 * R));
                }
                else
                {
                    graphsM.DrawLine(PathDarkBlue, V[E[i].Vertex1].x, V[E[i].Vertex1].y, V[E[i].Vertex2].x, V[E[i].Vertex2].y);
                    point = new PointF((V[E[i].Vertex1].x + V[E[i].Vertex2].x) / 2, (V[E[i].Vertex1].y + V[E[i].Vertex2].y) / 2);
                }
            }
            for (int i = 0; i < V.Count; i++)
            {
                DrawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }
    }

}
