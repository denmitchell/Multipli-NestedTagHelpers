using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-column", ParentTag = "my-row", Attributes = "id")]
    [HtmlTargetElement("my-column", ParentTag = "my-row", Attributes = "data")]
    public class MyColumnTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }

        [HtmlAttributeName("data")]
        public string Data { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            //use string builder to build output
            var sb = new StringBuilder();
            sb.Append($"        <td id={Id}>{Data}");

            //add end tag
            sb.AppendLine($"</td>");

            //get reference to parent context, and append sb to the relevant builder
            var rowContext = context.Items[typeof(MyRowContext)] as MyRowContext;
            rowContext.ColumnBuilder.Append(sb.ToString());

            //suppress output (for any tag with a parent tag)
            output.SuppressOutput();
        }


    }
}
