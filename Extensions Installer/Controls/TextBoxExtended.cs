/* 

    Git Extensions for SalesLogix
    Copyright (C) 2009  Customer FX Corporation - http://customerfx.com/

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

    Contact Information:
    
    Ryan Farley 
    Customer FX Corporation
    http://customerfx.com/
    2324 University Avenue West, Suite 115
    Saint Paul, Minnesota 55114
    Tel: 651.646.7777  Fax: 651.846.5185
    
    This copyright must remain intact
    
*/

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
