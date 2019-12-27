using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork6_BinaryTree
{
    public class TreeDraw
    {
        
            private double factor;
            private int size;
            
            private int marginTop = 50;
            private int marginLeft = 10;
            Font fo;

            public TreeDraw(double scale)
            {
                factor = scale;
                size = (int)(10 * factor);
                fo = new Font("Aerie", (int)(5 * factor));
            }
            public Bitmap DrawTree(Tree tree, List<int> NodeList)
            {
                Bitmap img = new Bitmap(ImageWidth(tree), ImageHeight(tree));
                Graphics gr = Graphics.FromImage(img);
                gr.Clear(Color.White);
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                Node root = tree.Root;
                int startPos = ((int)Math.Pow(2, tree.Deepth) * size) - size;
                DrawNode(root, startPos, gr, tree.Deepth);
               
                gr.Dispose();
                return img;
            }

            private int ImageHeight(Tree tree)
            {
                return (tree.Deepth + 1) * size + (marginTop * 2);
            }

            private int ImageWidth(Tree tree)
            {
                return (int)(Math.Pow(2, tree.Deepth) * 2 * size) + marginLeft;
            }

            private void DrawNode(Node node, int x, Graphics gr, int maxDepth)
            {
                if (node != null)
                {
                    int y = node.Deepth * size + 1 + marginTop;
                    int margin = ((int)Math.Pow(2, (maxDepth - node.Deepth)) * (size / 2));
               
                if(node.RightNode != null) gr.DrawLine(new Pen(Color.Black), x + 20, y+10, x+25+margin, y+25);
                if (node.LeftNode != null) gr.DrawLine(new Pen(Color.Black), x + 20, y + 10, x + 25 -margin, y + 25);
                CreateNode(node, gr, x, y);
                    DrawNode(node.LeftNode, x - margin, gr, maxDepth);
                   
                    DrawNode(node.RightNode, x + margin, gr, maxDepth);
                }
            }

     
        private void CreateNode(Node node, Graphics gr, int x, int y)
            {
            gr.FillEllipse(Brushes.White, x + marginLeft, y, size, size);
            gr.DrawEllipse(new Pen(Color.Black, (float)(1 * factor)), x + marginLeft, y, size, size);
                Rectangle rectangle = new Rectangle(x + marginLeft, y, size, size);
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(node.KeyValue.ToString(), fo, Brushes.Black, rectangle, sf);
                

        }
        
    }
}
