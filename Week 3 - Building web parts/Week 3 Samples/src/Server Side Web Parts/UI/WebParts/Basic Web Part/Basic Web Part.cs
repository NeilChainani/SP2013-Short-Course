using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.BasicWebPart
{
    [ToolboxItemAttribute(false)]
    public class BasicWebPart : WebPart
    {
        protected Literal DisplayTime = new Literal();
        protected Button UpdateTimeButton = new Button();

        protected override void CreateChildControls()
        {
            DisplayTime.Text = DateTime.Now.ToLongTimeString();

            UpdateTimeButton.Text = "Refresh time";
            UpdateTimeButton.Click += UpdateTimeButton_Click;

            Controls.Add(DisplayTime);
            Controls.Add(UpdateTimeButton);
        }

        void UpdateTimeButton_Click(object sender, EventArgs e)
        {
            DisplayTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
