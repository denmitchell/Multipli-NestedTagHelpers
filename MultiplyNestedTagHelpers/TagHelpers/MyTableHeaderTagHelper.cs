using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-table-header", ParentTag = "my-table", Attributes ="id")]
    [RestrictChildren("my-row")]
    public class MyTableHeaderTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            //create context for this tag helper
            var tableHeaderContext = new MyTableHeaderContext();
            context.Items.Add(typeof(MyTableHeaderContext), tableHeaderContext);

            //use string builder to build output
            var sb = new StringBuilder();
            sb.AppendLine($"    <thead id={Id}>");

            //retrieve the child output and append it to sb
            await output.GetChildContentAsync();
            sb.Append(tableHeaderContext.RowBuilder.ToString());

            //add end tag
            sb.AppendLine($"    </thead>");

            //get reference to parent context, and append sb to the relevant builder
            var tableContext = context.Items[typeof(MyTableContext)] as MyTableContext;
            tableContext.TableHeaderBuilder.Append(sb.ToString());

            //suppress output (for any tag with a parent tag)
            output.SuppressOutput();
        }


    }
}
