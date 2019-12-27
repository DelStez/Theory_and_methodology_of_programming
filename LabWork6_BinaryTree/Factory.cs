using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork6_BinaryTree
{
    class Factory
    {
        public static Tree CreateOrganizedTree(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            var list = values.ToList();
            list.Sort();
            Tree tree = new Tree();
            CreateOrganizedNode(list.ToArray(), 0, list.Count - 1, null, tree);
            return tree;
        }
        private static Node CreateOrganizedNode(int[] a, int left, int right, Node parrent, Tree tree)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;
                Node node = tree.Add(a[middle]);
                CreateOrganizedNode(a, left, middle - 1, node, tree);
                CreateOrganizedNode(a, middle + 1, right, node, tree);
                return node;
            }
            else
            {
                return null;
            }
        }
    }
}
