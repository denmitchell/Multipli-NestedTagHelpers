using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EDennis.Samples.TableTagHelpers.TagHelpers {

    [HtmlTargetElement("my-table-body", Attributes ="id")]
    [RestrictChildren("my-row")]
    public class MyTableBodyTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            var output2 = context.Items[typeof(TagHelperOutputContext)] as TagHelperOutputContext;
            void w(string c, int t = 0) => output2.TagHelperOutput.Write(c, t);


            w($"<tbody id='{Id}'>",2);

            await output.GetChildContentAsync();

            w($"</tbody>",2);


        }


    }
}
