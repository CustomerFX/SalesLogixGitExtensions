using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Controls
{
    public partial class TextBoxExtended : TextBox
    {
        private string watermark;
        private Color watermarkColor = Color.Silver;
        private Color foreColor = SystemColors.ControlText;
        private bool ispassword = false;
        private bool empty;

        public TextBoxExtended()
        {
            empty = true;
            foreColor = ForeColor;
        }

        public Color WatermarkColor
        {
            get { return watermarkColor; }
            set
            {
                watermarkColor = value;
                if (empty)
                {
                    base.ForeColor = watermarkColor;
                }
            }
        }

        public string WatermarkText
        {
            get { return watermark; }
            set
            {
                watermark = value;
                if (empty)
                {
                    base.Text = watermark;
                    base.ForeColor = watermarkColor;
                }
            }
        }

        public new Color ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                if (!empty)
                    base.ForeColor = value;
            }
        }

        public override string Text
        {
            get
            {
                if (empty) return "";
                return base.Text;
            }
            set
            {
                if (value == "")
                {
                    empty = true;
                    base.ForeColor = watermarkColor;
                    base.Text = watermark;
                    //if (this.Handle != IntPtr.Zero) base.UseSystemPasswordChar = false;
                }
                else
                {
                    empty = false;
                    base.ForeColor = foreColor;
                    base.Text = value;
                    //if (this.Handle != IntPtr.Zero) base.UseSystemPasswordChar = ispassword;
                }
            }
        }

        public bool IsPassword
        {
            get { return this.ispassword; }
            set
            {
                this.ispassword = value;
                //if (this.Handle != IntPtr.Zero) base.UseSystemPasswordChar = (ispassword && !empty);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (empty)
            {
                empty = false;
                base.ForeColor = foreColor;
                base.Text = "";
                //if (this.Handle != IntPtr.Zero) base.UseSystemPasswordChar = ispassword;
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (base.Text == "")
            {
                empty = true;
                base.ForeColor = watermarkColor;
                base.Text = watermark;
                //if (this.Handle != IntPtr.Zero) base.UseSystemPasswordChar = false;
            }
            else
                empty = false;
        }
    }
}
