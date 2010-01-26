using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FX.SalesLogix.Modules.GitExtensions.UI
{
    public partial class FeedbackDialog : Form
    {
        public FeedbackDialog()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textMessage.Text.Trim() == string.Empty)
            {
                errorProvider1.SetIconAlignment(textMessage, ErrorIconAlignment.TopRight);
                errorProvider1.SetError(textMessage, "Text cannot be blank");
                return;
            }
            else
                errorProvider1.SetError(textMessage, string.Empty);

            try
            {
                var svc = new FeedbackService.Feedback();
                svc.Url = "http://www.cfxconnect.com/GitExtensionsFeedback/Feedback.asmx";
                svc.SubmitFeedback(textName.Text, textEmail.Text, textMessage.Text);

                MessageBox.Show("Feedback submitted. Thank you.", "Git Extensions for SalesLogix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feedback could not be submitted. " + ex.Message, "Git Extensions for SalesLogix", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
