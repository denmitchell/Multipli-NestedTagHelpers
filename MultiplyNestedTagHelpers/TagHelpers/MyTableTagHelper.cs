using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {

    [HtmlTargetElement("my-table", Attributes ="id")]
    [RestrictChildren("my-table-header","my-table-body")]
    public class MyTableTagHelper : TagHelper {


        [HtmlAttributeName("id")]
        public string Id { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output) {

            //suppress normal tag output (handle below)
            output.TagName = "";

            //create context for this tag helper
            var tableContext = new MyTableContext();
            context.Items.Add(typeof(MyTableContext), tableContext);

            //use string builder to build output
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"<table class='table' id={Id}>");

            //retrieve the child output and append it to sb
            await output.GetChildContentAsync();
            sb.Append(tableContext.TableHeaderBuilder.ToString());
            sb.Append(tableContext.TableBodyBuilder.ToString());

            //add end tag
            sb.AppendLine($"</table>");

            //output the context
            //note: only use output.Content with top-level tag
            output.Content.AppendHtml(sb.ToString());
              
        }


    }
}
