﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace AspNet5Demo.Web.TagHelpers
{
    [TargetElement("cite")]
    public class CiteTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.Append("\"");
            output.PostContent.Append("\"");
        }
    }
}
