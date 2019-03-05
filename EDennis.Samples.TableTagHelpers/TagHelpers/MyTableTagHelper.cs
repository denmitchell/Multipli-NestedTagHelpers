using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EDennis.Samples.TableTagHelpers.TagHelpers {

    [HtmlTargetElement("my-table", Attributes ="id")]
    [RestrictChildren("my-table-body","my-table-header")]
    public class MyTableTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";

            //create context for this tag helper
            var tagHelperOutputContext = new TagHelperOutputContext { TagHelperOutput = output };
            context.Items.Add(typeof(TagHelperOutputContext), tagHelperOutputContext);
#if DEBUG
            context.Items.Add(context.UniqueId, context.TagName);
#endif
            void w(string c, int t = 0) => output.Write(c, t);

            w("<br/>");
            w($"<table class='table' id={Id}>",1);
            await output.GetChildContentAsync();
            w($"</table>",1);
              
        }


    }
}
