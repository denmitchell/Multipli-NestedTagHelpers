using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapNavbar.TagHelpers {

    [HtmlTargetElement("menu-item", Attributes = "caption")]
    [HtmlTargetElement("menu-item", Attributes = "link")]
    [HtmlTargetElement("menu-item", Attributes = "active")]
    [RestrictChildren("menu-item")]
    public class MenuItemTagHelper : TagHelper {

        [HtmlAttributeName("caption")]
        public string Caption {get; set;}

        [HtmlAttributeName("link")]
        public string Link { get; set; }

        [HtmlAttributeName("active")]
        public bool Active { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";

            var output2 = context.Items[typeof(TagHelperOutputContext)] as TagHelperOutputContext;
            void w(string c, int t = 0) => output2.TagHelperOutput.Write(c, t);


            var menuDepth = context.Items.Where(x => 
                x.Value.ToString().StartsWith("menu-item")).Count();

            context.Items.Add(context.UniqueId, $"{context.TagName}({Caption})-{menuDepth}");


            var tabs = 4 + menuDepth * 2;

            if (!string.IsNullOrEmpty(Link)) {
                if (menuDepth == 0) {
                    w($"<li class=\"nav-item{(Active ? " active" : "")}\">", tabs);
                    w($"<a class=\"nav-link\" href=\"{Link}\">{Caption}</a>", tabs + 1);
                } else {
                    w("<li>", tabs);
                    w($"<a class=\"dropdown-item\" href=\"{Link}\">{Caption}</a>", tabs + 1);
                }
            } else {
                if (menuDepth == 0) {
                    w("<li class=\"nav-item dropdown\">", tabs);
                    w($"<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"dropdown-{context.UniqueId}\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">{Caption}</a>", tabs + 1);
                } else {
                    w("<li class=\"dropdown-submenu\">", tabs);
                    w($"<a class=\"dropdown-item dropdown-toggle\" href=\"#\" id=\"dropdown-{context.UniqueId}\">{Caption}</a>", tabs + 1);
                }
                w($"<ul class=\"dropdown-menu\" aria-labelledby=\"dropdown-{context.UniqueId}\">", tabs + 1);
                await output.GetChildContentAsync();
                w("</ul>", tabs + 1);
            }
            w("</li>", tabs);
        }

    }
}
