using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CSU.SharePoint.Demo.ServerSideWebParts.Utilities;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.ConsumerWebPart
{
    [ToolboxItemAttribute(false)]
    public sealed class ConsumerWebPart : WebPart
    {
        Label _lblTitle;
        Label _lblResult;

        IDemoWebPartConnection _connectionInterface;
        [ConnectionConsumer("Parameter1 Consumer", "Parameter1 Consumer")]
        public void GetConnectionInterface(IDemoWebPartConnection dataInterface)
        {
            _connectionInterface = dataInterface;
        }

        public ConsumerWebPart()
        {
            Title = "Consumer WebPart";
            ExportMode = WebPartExportMode.All;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            var tbl = new Table();
            var row = new TableRow();
            var cell = new TableCell {VerticalAlign = VerticalAlign.Middle, HorizontalAlign = HorizontalAlign.Center};

            _lblTitle = new Label {Text = "This WebPart will recieve a parameter from a provider:"};
            cell.Controls.Add(_lblTitle);
            row.Controls.Add(cell);
            tbl.Controls.Add(row);

            row = new TableRow();
            cell = new TableCell {VerticalAlign = VerticalAlign.Middle, HorizontalAlign = HorizontalAlign.Center};
            _lblResult = new Label();

            if (_connectionInterface != null)
            {
                _lblResult.Text = _connectionInterface.Parameter1 + " is recieved!";
            }
            else
            {
                _lblResult.Text = "nothing is recieved!";
            }

            cell.Controls.Add(_lblResult);
            row.Controls.Add(cell);
            tbl.Controls.Add(row);

            Controls.Add(tbl);
        }
    }
}
