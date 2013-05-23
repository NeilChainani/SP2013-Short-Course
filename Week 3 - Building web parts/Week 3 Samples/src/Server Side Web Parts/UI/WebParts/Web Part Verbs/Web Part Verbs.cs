using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.WebPartVerbs
{
    [ToolboxItemAttribute(false)]
    public class WebPartVerbs : WebPart
    {
        protected override void CreateChildControls()
        {
            Controls.Add(new LiteralControl("<p>Test this for verbs</p>"));
        }

        public override WebPartVerbCollection Verbs
        {
            get 
            { 
                var verbs = new List<WebPartVerb>
                    {
                        new WebPartVerb(ID + "_ClientSideVerb", "alert('This is a client side verb!')")
                            {
                                Description = "This is an example of a client side verb",
                                Text = "Client side demo"
                            },
                        new WebPartVerb(ID + "_ServerSideVerb", ServerClickHandler)
                            {
                                Description = "This is an example of a server side verb",
                                Text = "Server side demo"
                            }
                    };
                return new WebPartVerbCollection(base.Verbs, verbs);
            }
        }

        private void ServerClickHandler(object sender, WebPartEventArgs webPartEventArgs)
        {
            Controls.Add(new LiteralControl("<p>You clicked me and I ran server side code!</p>"));
        }
    }
}
