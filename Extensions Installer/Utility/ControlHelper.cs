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
using System.Windows.Forms;
using System.Drawing;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Utility
{
    public delegate void SetControlTextDelegate(Control control, string text);
    public delegate void SetControlTagDelegate(Control control, object tag);
    public delegate void SetControlSizeDelegate(Control control, Size size);
    public delegate void SetPictureBoxImageDelegate(PictureBox control, Image image);
    public delegate void SetPictureBoxImageLocationDelegate(PictureBox control, string imageurl);
    public delegate void SetControlVisibleDelegate(Control Control, bool Visible);
    public delegate void SetControlBackColorHandler(Control control, Color backcolor);
    public delegate void SetControlEnabledHandler(Control control, bool enabled);
    public delegate void SetControlTooltipHandler(Control control, System.Windows.Forms.ToolTip toolTip, string tip);
    public delegate void SetControlDockDelegate(Control control, DockStyle dockstyle);
    public delegate void AddControlDelegate(Control parentcontrol, Control childcontrol);
    public delegate void ClearControlsDelegate(Control parentcontrol);
    public delegate void RemoveControlDelegate(Control parentcontrol, Control childcontrol);
    public delegate void CloseFormDelegate(Form form);

    public delegate void SetControlToolTipDelegate(Control control, string tooltip);

    public class ControlHelper
    {
        private ControlHelper() { }

        public static void SetControlText(Control control, string text)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlTextDelegate(SetControlText), new object[] { control, text });
            else
                control.Text = text;
        }

        public static void SetControlTag(Control control, object tag)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlTagDelegate(SetControlTag), new object[] { control, tag });
            else
                control.Tag = tag;
        }

        public static void SetControlVisible(Control control, bool visible)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlVisibleDelegate(SetControlVisible), new object[] { control, visible });
            else
                control.Visible = visible;
        }

        public static void SetControlSize(Control control, Size size)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlSizeDelegate(SetControlSize), new object[] { control, size });
            else
                control.Size = size;
        }

        public static void SetControlEnabled(Control control, bool enabled)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlEnabledHandler(SetControlEnabled), new object[] { control, enabled });
            else
                control.Enabled = enabled;
        }

        public static void SetControlBackColor(Control control, Color backcolor)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlBackColorHandler(SetControlBackColor), new object[] { control, backcolor });
            else
                control.BackColor = backcolor;
        }

        public static void SetPictureBoxImage(PictureBox control, Image image)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetPictureBoxImageDelegate(SetPictureBoxImage), new object[] { control, image });
            else
                control.Image = image;
        }

        public static void SetPictureBoxImageLocation(PictureBox control, string imageurl)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetPictureBoxImageLocationDelegate(SetPictureBoxImageLocation), new object[] { control, imageurl });
            else
                control.ImageLocation = imageurl;
        }

        public static void SetControlTooltip(Control control, System.Windows.Forms.ToolTip toolTip, string tip)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlTooltipHandler(SetControlTooltip), new object[] { control, toolTip, tip });
            else
                toolTip.SetToolTip(control, tip);
        }

        public static void AddControl(Control parentcontrol, Control childcontrol)
        {
            if (parentcontrol.InvokeRequired)
                parentcontrol.Invoke(new AddControlDelegate(AddControl), new object[] { parentcontrol, childcontrol });
            else
                parentcontrol.Controls.Add(childcontrol);
        }

        public static void RemoveControl(Control parentcontrol, Control childcontrol)
        {
            if (parentcontrol.InvokeRequired)
                parentcontrol.Invoke(new RemoveControlDelegate(RemoveControl), new object[] { parentcontrol, childcontrol });
            else
                parentcontrol.Controls.Remove(childcontrol);
        }

        public static void ClearControls(Control parentcontrol)
        {
            if (parentcontrol.InvokeRequired)
                parentcontrol.Invoke(new ClearControlsDelegate(ClearControls), new object[] { parentcontrol });
            else
                parentcontrol.Controls.Clear();
        }

        public static void SetControlDock(Control control, DockStyle dockstyle)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlDockDelegate(SetControlDock), new object[] { control, dockstyle });
            else
                control.Dock = dockstyle;
        }

        public static void CloseForm(Form form)
        {
            if (form.InvokeRequired)
                form.Invoke(new CloseFormDelegate(CloseForm), new object[] { form });
            else
                form.Close();
        }
    }
}
