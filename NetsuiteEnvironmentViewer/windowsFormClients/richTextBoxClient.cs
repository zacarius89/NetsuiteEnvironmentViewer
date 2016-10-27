using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NetsuiteEnvironmentViewer
{
    //http://stackoverflow.com/questions/6442911/how-do-i-sync-scrolling-in-2-treeviews-using-the-slider
    public partial class MyRichTextBox : RichTextBox
    {
        public MyRichTextBox() : base()
        {
        }

        private List<MyRichTextBox> linkedRichTextBoxes = new List<MyRichTextBox>();

        public void AppendText(string text, Color color)
        {
            this.SelectionStart = this.TextLength;
            this.SelectionLength = 0;

            this.SelectionColor = color;
            this.AppendText(text);
            this.SelectionColor = this.BackColor;
        }

        /// <summary>
        /// Links the specified rich text box to this rich text box.  Whenever either richtextbox
        /// scrolls, the other will scroll too.
        /// </summary>
        /// <param name="richTextBox">The RichTextBox to link.</param>
        public void AddLinkedRichTextBox(MyRichTextBox richTextBox)
        {
            if (richTextBox == this)
                throw new ArgumentException("Cannot link a RichTextBox to itself!", "richTextBox");

            if (!linkedRichTextBoxes.Contains(richTextBox))
            {
                //add the richtextbox to our list of linked richtextboxes
                linkedRichTextBoxes.Add(richTextBox);
                //add this to the richtextbox's list of linked richtextboxes
                richTextBox.AddLinkedRichTextBox(this);

                //make sure the RichTextBox is linked to all of the other RichTextBoxes that this RichTextBox is linked to
                for (int i = 0; i < linkedRichTextBoxes.Count; i++)
                {
                    //get the linked richtextbox
                    var linkedRichTextBox = linkedRichTextBoxes[i];
                    //link the richtextboxes together
                    if (linkedRichTextBox != richTextBox)
                        linkedRichTextBox.AddLinkedRichTextBox(richTextBox);
                }
            }
        }

        /// <summary>
        /// Sets the destination's scroll positions to that of the source.
        /// </summary>
        /// <param name="source">The source of the scroll positions.</param>
        /// <param name="dest">The destinations to set the scroll positions for.</param>
        private void SetScrollPositions(MyRichTextBox source, MyRichTextBox dest)
        {
            //get the scroll positions of the source
            int horizontal = User32.GetScrollPos(source.Handle, Orientation.Horizontal);
            int vertical = User32.GetScrollPos(source.Handle, Orientation.Vertical);
            //set the scroll positions of the destination
            User32.SetScrollPos(dest.Handle, Orientation.Horizontal, horizontal, true);
            User32.SetScrollPos(dest.Handle, Orientation.Vertical, vertical, true);
        }

        protected override void WndProc(ref Message m)
        {
            //process the message
            base.WndProc(ref m);

            //pass scroll messages onto any linked rich text boxes
            if (m.Msg == User32.WM_VSCROLL || m.Msg == User32.WM_MOUSEWHEEL)
            {
                foreach (var linkedRichTextBox in linkedRichTextBoxes)
                {
                    //set the scroll positions of the linked rich text box
                    SetScrollPositions(this, linkedRichTextBox);
                    //copy the windows message
                    Message copy = new Message
                    {
                        HWnd = linkedRichTextBox.Handle,
                        LParam = m.LParam,
                        Msg = m.Msg,
                        Result = m.Result,
                        WParam = m.WParam
                    };
                    //pass the message onto the linked rich text box
                    linkedRichTextBox.ReceiveWndProc(ref copy);
                }
            }
        }

        /// <summary>
        /// Receives a WndProc message without passing it onto any linked richtextboxes.  This is useful to avoid infinite loops.
        /// </summary>
        /// <param name="m">The windows message.</param>
        private void ReceiveWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        /// <summary>
        /// Imported functions from the User32.dll
        /// </summary>
        private class User32
        {
            public const int WM_VSCROLL = 0x115;
            public const int WM_MOUSEWHEEL = 0x020A;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int GetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar);

            [DllImport("user32.dll")]
            public static extern int SetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar, int nPos, bool bRedraw);
        }
    }
}