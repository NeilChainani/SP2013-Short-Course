using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CSU.SharePoint.Demo.ServerSideWebParts.Utilities;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.ProviderWebPart
{
    [ToolboxItemAttribute(false)]
    public sealed class ProviderWebPart : WebPart, IDemoWebPartConnection
    {
        TextBox _textBox;
        Button _button;

        private string _parameter1 = "";
        public string Parameter1
        {
            get { return _parameter1; }
        }

        [ConnectionProvider("Parameter1 Provider", "Parameter1 Provider")]
        public IDemoWebPartConnection ConnectionInterface()
        {
            return this;
        }

        public ProviderWebPart()
        {
            Title = "Provider WebPart";
            ExportMode = WebPartExportMode.All;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            var tbl = new Table();
            var row = new TableRow();
            var cell = new TableCell
                {
                    ColumnSpan = 2,
                    VerticalAlign = VerticalAlign.Middle,
                    HorizontalAlign = HorizontalAlign.Center
                };

            var lblTitle = new Label {Text = "This WebPart will send a parameter to a consumer:"};
            cell.Controls.Add(lblTitle);
            row.Controls.Add(cell);
            tbl.Controls.Add(row);

            row = new TableRow();
            cell = new TableCell {VerticalAlign = VerticalAlign.Middle, HorizontalAlign = HorizontalAlign.Center};
            _textBox = new TextBox {Text = "", Width = Unit.Pixel(120)};
            cell.Controls.Add(_textBox);
            row.Controls.Add(cell);
            cell = new TableCell {VerticalAlign = VerticalAlign.Middle, HorizontalAlign = HorizontalAlign.Center};
            _button = new Button {Text = "Send..."};
            _button.Click += btn_Click;
            cell.Controls.Add(_button);
            row.Controls.Add(cell);
            tbl.Controls.Add(row);

            Controls.Add(tbl);
        }

        void btn_Click(object sender, EventArgs e)
        {
            _parameter1 = _textBox.Text;
        }
    }
}
