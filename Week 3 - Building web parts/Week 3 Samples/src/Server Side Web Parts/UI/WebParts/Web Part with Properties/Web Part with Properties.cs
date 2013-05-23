using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using Microsoft.SharePoint.WebPartPages;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace CSU.SharePoint.Demo.ServerSideWebParts.UI.WebParts.WebPartwithProperties
{
    [ToolboxItemAttribute(false)]
    public class WebPartWithProperties : WebPart
    {
        const string DefaultString = "Sample String";
        const bool DefaultBool = false;
        const int DefaultInt = 20;
        public enum FarmObject
        {
            Barn,
            Tractor,
            Hay,
            Pitchfork
        };
        protected FarmObject FarmEnum;

        private string _myString;
        private bool _myBool;
        private int _myInt;
        private DateTime _myDateTime;
        private KnownColor _myColor = KnownColor.Red;

        [Category("Custom Properties")]
        [DefaultValue(DefaultString)]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDisplayName("Custom String")]
        public string MyString
        {
            get
            {
                return _myString;
            }
            set
            {
                _myString = value;
            }
        }

        [Category("Custom Properties")]
        [DefaultValue(DefaultBool)]
        [WebDisplayName("Custom Boolean")]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        public bool MyBool
        {
            get
            {
                return _myBool;
            }
            set
            {
                _myBool = value;
            }
        }

        [Category("Custom Properties")]
        [DefaultValue(DefaultInt)]
        [WebDisplayName("Custom Integer")]
        [Description("Type an integer value.")]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        public int MyInt
        {
            get
            {
                return _myInt;
            }
            set
            {
                _myInt = value;
            }
        }

        [Category("Custom Properties")]
        [WebDisplayName("Custom Date Time")]
        [Description("Type a DateTime value.")]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        public DateTime MyDateTime
        {
            get
            {
                return _myDateTime;
            }
            set
            {
                _myDateTime = value;
            }
        }

        public bool ShouldSerializeMyDateTime()
        {
            return true;
        }

        [Category("Custom Properties")]
        [DefaultValue(FarmObject.Hay)]
        [WebDisplayName("Custom Enum")]
        [Description("Select a value from the dropdown list.")]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        public FarmObject MyEnum
        {
            get
            {
                return FarmEnum;
            }
            set
            {
                FarmEnum = value;
            }
        }

        [Category("Custom Properties")]
        [WebDisplayName("Custom Color")]
        [Description("Select a color from the dropdown list.")]
        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.Shared)]
        public KnownColor MyColor
        {
            get
            {
                return _myColor;
            }
            set
            {
                _myColor = value;
            }
        }

        public bool ShouldSerializeMyColor()
        {
            return true;
        }

        protected override void CreateChildControls()
        {
        }
    }
}
