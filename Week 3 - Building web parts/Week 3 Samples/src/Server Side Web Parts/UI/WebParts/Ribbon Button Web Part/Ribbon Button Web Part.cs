using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using Microsoft.SharePoint.WebControls;
using Microsoft.Web.CommandUI;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.RibbonButtonWebPart
{
    [ToolboxItemAttribute(false)]
    public class RibbonButtonWebPart : WebPart, IWebPartPageComponentProvider
    {
        private string _contextualTab = @"
   <ContextualGroup Color=""Magenta""
     Command=""CustomContextualTab.EnableContextualGroup""
     Id=""Ribbon.CustomContextualTabGroup""
     Title=""Custom Contextual Tab Group""
     Sequence=""502""
     ContextualGroupId=""CustomContextualTabGroup"">
          <Tab
              Id=""Ribbon.CustomTabExample""
              Title=""My Custom Tab""
              Description=""This holds my custom commands!""
              Command=""CustomContextualTab.EnableCustomTab""
              Sequence=""501"">
            <Scaling
              Id=""Ribbon.CustomTabExample.Scaling"">
              <MaxSize
                Id=""Ribbon.CustomTabExample.MaxSize""
                GroupId=""Ribbon.CustomTabExample.CustomGroupExample""
                Size=""OneLargeTwoMedium""/>
              <Scale
                Id=""Ribbon.CustomTabExample.Scaling.CustomTabScaling""
                GroupId=""Ribbon.CustomTabExample.CustomGroupExample""
                Size=""OneLargeTwoMedium"" />
            </Scaling>
            <Groups Id=""Ribbon.CustomTabExample.Groups"">
              <Group
                Id=""Ribbon.CustomTabExample.CustomGroupExample""
                Description=""This is a custom group!""
                Title=""Custom Group""
                Command=""CustomContextualTab.EnableCustomGroup""
                Sequence=""52""
                Template=""Ribbon.Templates.CustomTemplateExample"">
                <Controls
                  Id=""Ribbon.CustomTabExample.CustomGroupExample.Controls"">
                  <Button
                    Id=""Ribbon.CustomTabExample.CustomGroupExample.HelloWorld""
                    Command=""CustomContextualTab.HelloWorldCommand""
                    Sequence=""15""
                    Description=""Says hello to the World!""
                    LabelText=""Hello, World!""
                    TemplateAlias=""cust1""/>
                  <Button
                    Id=""Ribbon.CustomTabExample.CustomGroupExample.GoodbyeWorld""
                    Command=""CustomContextualTab.GoodbyeWorldCommand""
                    Sequence=""17""
                    Description=""Says good-bye to the World!""
                    LabelText=""Good-bye, World!""
                    TemplateAlias=""cust2""/>
                </Controls>
              </Group>
            </Groups>
          </Tab>
   </ContextualGroup>";

        private string _contextualTabTemplate = @"
          <GroupTemplate Id=""Ribbon.Templates.CustomTemplateExample"">
            <Layout
              Title=""OneLargeTwoMedium"" LayoutTitle=""OneLargeTwoMedium"">
              <Section Alignment=""Top"" Type=""OneRow"">
                <Row>
                  <ControlRef DisplayMode=""Large"" TemplateAlias=""cust1"" />
                </Row>
              </Section>
              <Section Alignment=""Top"" Type=""TwoRow"">
                <Row>
                  <ControlRef DisplayMode=""Medium"" TemplateAlias=""cust2"" />
                </Row>
                <Row>
                  <ControlRef DisplayMode=""Medium"" TemplateAlias=""cust3"" />
                </Row>
              </Section>
            </Layout>
          </GroupTemplate>";

        public string DelayScript
        {
            get
            {
                string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                return @"
<script type=""text/javascript"">
//<![CDATA[
 
            function _addCustomPageComponent()
            {
                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('" + webPartPageComponentId + @"');
                SP.Ribbon.PageManager.get_instance().addPageComponent(_customPageComponent);
            }
 
            function _registerCustomPageComponent()
            {
                SP.SOD.registerSod(""CustomContextualTabPageComponent.js"", ""\/_layouts\/15\/CSU\/CustomContextualTabPageComponent.js"");
                SP.SOD.executeFunc(""CustomContextualTabPageComponent.js"", ""ContextualWebPart.CustomPageComponent"", _addCustomPageComponent);
            }
            SP.SOD.executeOrDelayUntilScriptLoaded(_registerCustomPageComponent, ""sp.ribbon.js"");
//]]>
</script>";
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Add(new LiteralControl("<p>Click somewhere around here to see the tab!</p>"));
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            AddContextualTab();
            var clientScript = Page.ClientScript;
            clientScript.RegisterClientScriptBlock(GetType(), "ContextualTabWebPart", DelayScript);
        }

        private void AddContextualTab()
        {
            Ribbon ribbon = SPRibbon.GetCurrent(Page);
            var ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(_contextualTab);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");
            ribbonExtensions.LoadXml(_contextualTabTemplate);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                var info = new WebPartContextualInfo();
                var contextualGroup = new WebPartRibbonContextualGroup();
                var ribbonTab = new WebPartRibbonTab();

                contextualGroup.Id = "Ribbon.CustomContextualTabGroup";
                contextualGroup.Command = "CustomContextualTab.EnableContextualGroup";
                contextualGroup.VisibilityContext = "CustomContextualTab.CustomVisibilityContext";

                ribbonTab.Id = "Ribbon.CustomTabExample";
                ribbonTab.VisibilityContext = "CustomContextualTab.CustomVisibilityContext";

                info.ContextualGroups.Add(contextualGroup);
                info.Tabs.Add(ribbonTab);
                info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return info;
            }
        }
    }
}
