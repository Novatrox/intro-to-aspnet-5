using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Framework.Configuration;

namespace AspNet5Demo.Web.TagHelpers
{
    [TargetElement("GoogleMap")]
    public class GoogleMapTagHelper : TagHelper
    {
        private readonly IConfiguration _configuration;

        public GoogleMapTagHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "iframe";
            output.Attributes.Clear();
            output.Attributes.Add("width", Width);
            output.Attributes.Add("height", Height);
            output.Attributes.Add("frameborder", "0");
            output.Attributes.Add("style", "border:0;");
            output.Attributes.Add("src", $"https://www.google.com/maps/embed/v1/place?key={_configuration["GoogleMap.Key"]}&q={Query}");
        }

        [HtmlAttributeName("query")]
        public string Query { get; set; }

        [HtmlAttributeName("width")]
        public string Width { get; set; }

        [HtmlAttributeName("height")]
        public string Height { get; set; }
    }
}
