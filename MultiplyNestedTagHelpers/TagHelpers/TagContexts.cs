using System.Text;

namespace MultiplyNestedTagHelpers.TagHelpers {
    
    /// <summary>
    /// Holds builders for child tags of my-table
    /// </summary>
    public class MyTableContext{
        public StringBuilder TableHeaderBuilder { get; set; } = new StringBuilder();
        public StringBuilder TableBodyBuilder { get; set; } = new StringBuilder();
    }

    /// <summary>
    /// Holds builders for child tags of my-table-header
    /// </summary>
    public class MyTableHeaderContext {
        public StringBuilder RowBuilder { get; set; } = new StringBuilder();
    }

    /// <summary>
    /// Holds builders for child tags of my-table-body
    /// </summary>
    public class MyTableBodyContext {
        public StringBuilder RowBuilder { get; set; } = new StringBuilder();
    }

    /// <summary>
    /// Holds builders for child tags of my-row
    /// </summary>
    public class MyRowContext {
        public StringBuilder ColumnHeaderBuilder { get; set; } = new StringBuilder();
        public StringBuilder ColumnBuilder { get; set; } = new StringBuilder();
    }

}
