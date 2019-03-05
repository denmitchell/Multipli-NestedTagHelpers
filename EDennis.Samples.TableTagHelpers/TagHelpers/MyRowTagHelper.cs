using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EDennis.Samples.TableTagHelpers.TagHelpers {

    [HtmlTargetElement("my-row", Attributes ="id")]
    [RestrictChildren("my-column", "my-column-header")]
    public class MyRowTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            var output2 = context.Items[typeof(TagHelperOutputContext)] as TagHelperOutputContext;
            void w(string c, int t = 0) => output2.TagHelperOutput.Write(c, t);
#if DEBUG
            context.Items.Add(context.UniqueId, context.TagName);
#endif
            w($"<tr id='{Id}'>",2);
            await output.GetChildContentAsync();
            w($"</tr>",2);

        }


    }
}
