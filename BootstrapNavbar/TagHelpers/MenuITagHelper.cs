using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapNavbar.TagHelpers {

    [HtmlTargetElement("menu", Attributes = "icon")]
    [RestrictChildren("menu-item")]
    public class MenuITagHelper : TagHelper {

        [HtmlAttributeName("icon")]
        public string Icon { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";

            //create context for this tag helper
            var tagHelperOutputContext = new TagHelperOutputContext { TagHelperOutput = output };
            context.Items.Add(typeof(TagHelperOutputContext), tagHelperOutputContext);
            context.Items.Add(context.UniqueId, context.TagName);

            void w(string c, int t = 0) => output.Write(c, t);

            w("<br/>");
            w("<nav class=\"navbar navbar-expand-md navbar-dark bg-dark fixed-top\">",1);
            w($"<a class=\"navbar-brand\" href=\"#\"><img class=\"pull-left navbar-icon\" src=\"{Icon}\" alt = \"Icon\"",2);

            w("<button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#menu-body\" aria-controls=\"menu\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">",2);
            w($"<span class=\"navbar-toggler-icon\"></span>", 3);
            w($"</button>", 3);

            w($"<div class=\"collapse navbar-collapse\" id=\"menu-body\">",2);
            w("<ul class=\"navbar-nav mr-auto\">", 3);

            await output.GetChildContentAsync();

            w("</ul>", 3);
            w("</div>", 2);
            w("</nav>", 1);

        }

    }
}
