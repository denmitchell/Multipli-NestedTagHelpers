using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-table-body", ParentTag = "my-table", Attributes ="id")]
    [RestrictChildren("my-row")]
    public class MyTableBodyTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";

            //create context for this tag helper
            var tableBodyContext = new MyTableBodyContext();
            context.Items.Add(typeof(MyTableBodyContext), tableBodyContext);

            //use string builder to build output
            var sb = new StringBuilder();
            sb.AppendLine($"    <tbody id={Id}>");

            //retrieve the child output and append it to sb
            await output.GetChildContentAsync();
            sb.Append(tableBodyContext.RowBuilder.ToString());

            //add end tag
            sb.AppendLine($"    </tbody>");

            //get reference to parent context, and append sb to the relevant builder
            var tableContext = context.Items[typeof(MyTableContext)] as MyTableContext;
            tableContext.TableBodyBuilder.Append(sb.ToString());

            //suppress output (for any tag with a parent tag)
            output.SuppressOutput();
              
        }


    }
}
