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
            private int marginTop = 10;
            private int marginLeft = 10;
            Font fo;

            public TreeDraw(double scale)
            {
                factor = scale;
                size = (int)(10 * factor);
                fo = new Font("Aerie", (int)(5 * factor));
            }
            public Bitmap DrawTree(Tree tree)
            {
                Bitmap img = new Bitmap(ImageWidth(tree), ImageHeight(tree));
                //img.SetResolution(1000,1000);
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
                    System.Diagnostics.Trace.WriteLine(String.Format("Key: {0}, Depth: {1},  X: {2}, Margin: {3}", node.KeyValue, node.Deepth, x, margin));
                    CreateNode(node, gr, x, y);
                    DrawNode(node.LeftNode, x - margin, gr, maxDepth);
                    DrawNode(node.RightNode, x + margin, gr, maxDepth);
                }
            }

            private void CreateNode(Node node, Graphics gr, int x, int y)
            {
                gr.DrawEllipse(new Pen(Color.Black, (float)(1 * factor)), x + marginLeft, y, size, size);
                Rectangle rectangle = new Rectangle(x + marginLeft, y, size, size);
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(node.KeyValue.ToString("00"), fo, Brushes.Black, rectangle, sf);
                
            }
        
    }
}
