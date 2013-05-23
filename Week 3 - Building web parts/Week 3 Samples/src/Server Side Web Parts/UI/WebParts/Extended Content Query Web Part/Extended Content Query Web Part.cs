using System.ComponentModel;
using Microsoft.SharePoint.Publishing.WebControls;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.ExtendedContentQueryWebPart
{
    [ToolboxItemAttribute(false)]
    public class ExtendedContentQueryWebPart : ContentByQueryWebPart
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write("<p>This comes before the web part</p>");
            base.Render(writer);
            writer.Write("<p>This comes after the web part</p>");
        }
    }
}
