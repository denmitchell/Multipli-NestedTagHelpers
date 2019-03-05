using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDennis.Samples.TableTagHelpers.TagHelpers {
    public static class TagHelperExtensions {
        public static TagHelperOutput Write(
            this TagHelperOutput output, 
            string content, int tab = 0) {

            for (int i = 0; i <= tab; i++)
                output.Content.Append(" ");
            output.Content.AppendHtmlLine(content);

            return output;
        }

    }
}
