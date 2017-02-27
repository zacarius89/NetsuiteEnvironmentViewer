using System.Drawing;
using System.Windows.Forms;

namespace NetsuiteEnvironmentViewer
{
    public class richTextBoxColor
    {
        public int start;
        public int length;
        public Color color;
    }

    public class commonClient
    {
        public Color insertedColor = Color.Green;
        public Color imaginaryColor = Color.Gray;
        public Color deletedColor = Color.Red;
        public Color modifiedColor = Color.Orange;

        public int findMaxLength(int length1, int length2)
        {
            int maxLength = 0;

            if (length1 >= length2)
            {
                maxLength = length1;
            }
            else
            {
                maxLength = length2;
            }

            return maxLength;
        }

        public TreeNode addNode(TreeNode treeNode, string nodeValue)
        {
            return treeNode.Nodes.Add(nodeValue);
        }

        public TreeNode getNodeFromPath(TreeNode node, string path)
        {
            TreeNode foundNode = null;

            if (node.FullPath == path)
            {
                return node;
            }

            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.FullPath == path)
                {
                    return tn;
                }
                else if (tn.Nodes.Count > 0)
                {
                    foundNode = getNodeFromPath(tn, path);
                }
                if (foundNode != null)
                    return foundNode;
            }
            return null;
        }

        public void checkNodeColor(TreeNode treeNode1, TreeNode treeNode2, Color color)
        {
            if (treeNode1.Text != treeNode2.Text)
            {
                setNodeColor(treeNode1, color);
                setNodeColor(treeNode2, color);
            }
        }

        public void setNodeColor(TreeNode treeNode, Color color)
        {
            // Color Hierarchy: errorColor, warningColor, infoColor, newColor

            if (treeNode != null)
            {
                if (treeNode.ForeColor == deletedColor)
                {
                    // Do Nothing; node is set to the highest level
                }
                else if (treeNode.ForeColor == modifiedColor)
                {
                    if (color == deletedColor)
                    {
                        treeNode.ForeColor = color;
                        setNodeColor(treeNode.Parent, color);
                    }
                }
                else if (treeNode.ForeColor == insertedColor || treeNode.ForeColor == imaginaryColor)
                {
                    if (color == deletedColor || color == modifiedColor)
                    {
                        treeNode.ForeColor = color;
                        setNodeColor(treeNode.Parent, color);
                    }
                }
                else
                {
                    treeNode.ForeColor = color;
                    setNodeColor(treeNode.Parent, color);
                }
            }
        }
    }
}
