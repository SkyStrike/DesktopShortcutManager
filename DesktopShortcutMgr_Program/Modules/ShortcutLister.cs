using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopShortcutMgr.Modules
{
    /// <summary>
    /// This class contains functions which can be used in the application
    /// </summary>
    public class ShortcutLister
    {
        Control ctlControlToGenerate = null;

        /// <summary>
        /// Get shortcuts with option to select to save it to somewhere
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="sb"></param>
        /// <param name="ctlEventControl"></param>
        public void GetShortcuts(Control ctl, Control ctlEventControl)
        {
            ctlControlToGenerate = ctl;
            ctlEventControl.Click += new EventHandler(_GetShortcuts_Click);
        }

        /// <summary>
        /// Get shortcuts with option to select to save it to somewhere
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="ctlEventControl"></param>
        public void GetShortcuts(Control ctl, ToolStripItem ctlEventControl)
        {
            ctlControlToGenerate = ctl;
            ctlEventControl.Click += new EventHandler(_GetShortcuts_Click);
        }

        /// <summary>
        /// Event for _GetShortcut_Click
        /// Used by 
        ///     GetShortcuts(Control ctl, Control ctlEventControl)
        ///     GetShortcuts(Control ctl, ToolStripItem ctlEventControl)
        ///     
        /// These methods will add a click event to the control passed in as 
        /// such when the button is clicked, it will get all the shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _GetShortcuts_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt)|*.txt";
            sfd.Title = "Save shortcuts to";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                GetShortcuts(ctlControlToGenerate, ref sb);

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                {
                    sw.WriteLine(sb.ToString());
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets all shortcuts in the control and write it to the stringbuilder which is passed in byref
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="sb"></param>
        public void GetShortcuts(Control ctl, ref StringBuilder sb)
        {
            //Checks for ContextMenu
            if (ctl.ContextMenuStrip != null)
            {
                StringBuilder sbTmp = new StringBuilder();
                GetShortcuts((ToolStrip)ctl.ContextMenuStrip, ref sbTmp);

                if (!string.IsNullOrEmpty(sbTmp.ToString()))
                {
                    sb
                       .AppendLine()
                       .AppendLine(
                            string.Format(
                                "\nContext Menu [{0}]", 
                                (string.IsNullOrEmpty(ctl.Text) ? ctl.Name : ctl.Text) + 
                                "." + 
                                ctl.ContextMenuStrip.Name)
                            )
                       .AppendLine(sbTmp.ToString());
                }
            }

            if (ctl is ToolStrip)
            {
                //ToolStrip
                StringBuilder sbTmp = new StringBuilder();
                GetShortcuts((ToolStrip)ctl, ref sbTmp);

                if (!string.IsNullOrEmpty(sbTmp.ToString()))
                {
                    sb
                       .AppendLine()
                       .AppendLine(string.Format("\n Menu [{0}]", ctl.Name))
                       .AppendLine(sbTmp.ToString());
                }
            }

            foreach (Control c in ctl.Controls)
            {
                if (c.Controls != null)
                {
                    GetShortcuts(c, ref sb);
                }
            }
        }

        /// <summary>
        /// Gets all shortcuts in the ToolStrip and write it to the stringbuilder which is passed in byref
        /// to be used by the parent method
        /// - GetShortcuts(Control ctl, ref StringBuilder sb)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sb"></param>
        public void GetShortcuts(ToolStrip t, ref StringBuilder sb)
        {
            if (t.Items != null && t.Items.Count > 0)
            {
                foreach (ToolStripItem i in t.Items)
                {
                    if (i is ToolStripDropDownItem)
                    {
                        GetShortcuts((ToolStripDropDownItem)i, ref sb);
                    }
                    else if (i is ToolStripMenuItem)
                    {
                        GetShortcuts((ToolStripMenuItem)i, ref sb);
                    }
                }
            }
        }

        /// <summary>
        /// Gets all shortcuts in the ToolStripMenuItem and write it to the stringbuilder which is passed in byref
        /// to be used by the parent method
        /// - GetShortcuts(Control ctl, ref StringBuilder sb)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sb"></param>
        public void GetShortcuts(ToolStripMenuItem t, ref StringBuilder sb)
        {
            if (t.DropDownItems != null && t.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem i in t.DropDownItems)
                {
                    if (i is ToolStripMenuItem)
                    {
                        GetShortcuts((ToolStripMenuItem)i, ref sb);
                    }
                    else
                    {
                        AppendShortcut(t.ShortcutKeys.ToString(), t.Text, ref sb);
                    }
                }
            }
            else
            {
                AppendShortcut(t.ShortcutKeys.ToString(), t.Text, ref sb);
            }
        }

        /// <summary>
        /// Gets all shortcuts in the ToolStripDropDownItem and write it to the stringbuilder which is passed in byref
        /// to be used by the parent method
        /// - GetShortcuts(Control ctl, ref StringBuilder sb)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sb"></param>
        public void GetShortcuts(ToolStripDropDownItem t, ref StringBuilder sb)
        {
            if (t.DropDownItems != null && t.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem i in t.DropDownItems)
                {
                    if (i is ToolStripMenuItem)
                    {
                        GetShortcuts((ToolStripMenuItem)i, ref sb);
                    }
                }
            }
            else
            {
                if (t is ToolStripMenuItem)
                {
                    GetShortcuts((ToolStripMenuItem)t, ref sb);
                }
            }
        }

        /// <summary>
        /// Append shortcut to string builder. with some checking to ignore those without shortcuts
        /// </summary>
        /// <param name="strShortcut"></param>
        /// <param name="strText"></param>
        /// <param name="sb"></param>
        private void AppendShortcut(string strShortcut, string strText, ref StringBuilder sb)
        {
            if (strShortcut != "None")
            {
                sb.AppendLine(FormatShortcutString(strShortcut, strText));
            }
        }

        /// <summary>
        /// Format the shortcut to be easily understandable. 
        /// e.g. change D1 to 1, Oemtilde to ~
        /// </summary>
        /// <param name="shortcut"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public string FormatShortcutString(string shortcut, string text)
        {

            List<string> l = new List<string>();
            string[] strAry = shortcut.Split(',');

            foreach (string s in strAry)
                l.Add(s.Trim());


            string strResult = "";
            if (l.Contains("Control"))
            {
                l.Remove("Control");
                strResult = "Ctl + ";
            }

            if (l.Contains("Alt"))
            {
                l.Remove("Alt");
                strResult += "Alt + ";
            }

            if (l.Contains("Shift"))
            {
                l.Remove("Shift");
                strResult += "Shift + ";
            }

            foreach (string s in l)
            {
                switch (s.Trim())
                {
                    case "Oemtilde":
                        strResult += "~";
                        break;

                    case "D0":
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9":
                        strResult += s.Replace("D", "");
                        break;

                    default:
                        strResult += s;
                        break;
                }
            }

            return string.Format("{0} \t\t==> {1}", strResult, text);
        }

    }
}
