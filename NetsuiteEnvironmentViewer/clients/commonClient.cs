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
        public Color newColor = Color.Green;
        public Color errorColor = Color.Red;
        public Color warningColor = Color.Orange;

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
                if (treeNode.ForeColor == errorColor)
                {
                    // Do Nothing; node is set to the highest level
                }
                else if (treeNode.ForeColor == warningColor)
                {
                    if (color == errorColor)
                    {
                        treeNode.ForeColor = color;
                        setNodeColor(treeNode.Parent, color);
                    }
                }
                else if (treeNode.ForeColor == newColor)
                {
                    if (color == errorColor || color == warningColor)
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
