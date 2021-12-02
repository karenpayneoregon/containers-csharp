namespace ExcelSpreadSheetLiteConsoleApp.Classes
{
    /// <summary>
    /// mutable 
    /// </summary>
    public class FoundItem
    {
        public int RowIndex { get; set; }
        public string Column { get; set; }
        public int ColumnIndex { get; set; }
        public override string ToString()
        {
            return $"[{Column}:{RowIndex}]";
        }
    }

    /// <summary>
    /// immutable 
    /// </summary>
    public class FoundItemImmutable
    {
        public int RowIndex { get; init; }
        public string Column { get; init; }
        public int ColumnIndex { get; init; }

        public FoundItemImmutable(int rowIndex, int columnIndex, string column)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Column = column;

        }
        public override string ToString()
        {
            return $"[{Column}:{RowIndex}]";
        }
    }
}