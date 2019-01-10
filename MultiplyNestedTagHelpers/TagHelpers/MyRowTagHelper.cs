using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-row", Attributes ="id")]
    [RestrictChildren("my-column-header","my-column")]
    public class MyRowTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            //create context for this tag helper
            var rowContext = new MyRowContext();
            context.Items.Add(typeof(MyRowContext), rowContext);

            //use string builder to build output
            var sb = new StringBuilder();
            sb.AppendLine($"      <tr id={Id}>");

            //retrieve the child output and append it to sb
            await output.GetChildContentAsync();
            sb.Append(rowContext.ColumnHeaderBuilder.ToString());
            sb.Append(rowContext.ColumnBuilder.ToString());

            //add end tag
            sb.AppendLine($"      </tr>");

            //get reference to parent context, and append sb to the relevant builder
            //note that my-row has two candidate parent contexts; so,
            //  we use the presence of a column header or regular column
            //  to determine which parent is appropriate here
            if (rowContext.ColumnHeaderBuilder.ToString().Length > 0) {
                var tableHeaderContext = context.Items[typeof(MyTableHeaderContext)] as MyTableHeaderContext;
                tableHeaderContext.RowBuilder.Append(sb.ToString());
            } else {
                var tableBodyContext = context.Items[typeof(MyTableBodyContext)] as MyTableBodyContext;
                tableBodyContext.RowBuilder.Append(sb.ToString());
            }

            //suppress output (for any tag with a parent tag)
            output.SuppressOutput();
        }


    }
}
