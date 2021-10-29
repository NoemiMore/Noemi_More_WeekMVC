using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Noemi_More_WeekMVC.TagHelper
{
    public class EMailTagHelper: TagHelper
    {
        public string ToUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("Mandami e-mail");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");


        }      }
}
