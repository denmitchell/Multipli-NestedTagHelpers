using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-column-header", ParentTag = "my-row", Attributes = "id")]
    [HtmlTargetElement("my-column-header", ParentTag = "my-row", Attributes = "data")]
    public class MyColumnHeaderTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }

        [HtmlAttributeName("data")]
        public string Data { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            //use string builder to build output
            var sb = new StringBuilder();
            sb.Append($"        <th scope='col' id={Id}>{Data}");

            //add end tag
            sb.AppendLine($"</th>");

            //get reference to parent context, and append sb to the relevant builder
            var rowContext = context.Items[typeof(MyRowContext)] as MyRowContext;
            rowContext.ColumnHeaderBuilder.Append(sb.ToString());

            //suppress output (for any tag with a parent tag)
            output.SuppressOutput();
        }


    }
}
