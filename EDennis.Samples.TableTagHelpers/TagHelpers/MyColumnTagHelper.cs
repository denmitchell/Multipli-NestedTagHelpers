using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EDennis.Samples.TableTagHelpers.TagHelpers {

    [HtmlTargetElement("my-column", ParentTag = "my-row", Attributes = "id")]
    [HtmlTargetElement("my-column", ParentTag = "my-row", Attributes = "data")]
    public class MyColumnTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }

        [HtmlAttributeName("data")]
        public string Data { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            var output2 = context.Items[typeof(TagHelperOutputContext)] as TagHelperOutputContext;
            void w(string c, int t = 0) => output2.TagHelperOutput.Write(c, t);
#if DEBUG
            context.Items.Add(context.UniqueId, context.TagName);
#endif

            w($"<td id='{Id}'>{Data}",3);
            w($"</td>",3);

        }


    }
}
