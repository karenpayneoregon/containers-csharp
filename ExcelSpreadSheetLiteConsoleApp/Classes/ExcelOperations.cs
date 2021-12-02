using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SpreadsheetLight;

namespace ExcelSpreadSheetLiteConsoleApp.Classes
{
    public class ExcelOperations
    {
        /// <summary>
        /// Locate text in used cells
        /// </summary>
        /// <param name="searchItem"><seealso cref="SearchItem"/></param>
        /// <returns>Named value tuple list of <seealso cref="FoundItemImmutable"/> and <seealso cref="Exception"/></returns>
        /// <remarks>
        /// Optional, add logic for like/contains
        /// </remarks>
        public static (IReadOnlyList<FoundItemImmutable> items, Exception exception) FindText(SearchItem searchItem)
        {
            var foundList = new List<FoundItemImmutable>();

            try
            {
                using (var document = new SLDocument(searchItem.FileName, searchItem.SheetName))
                {

                    var stats = document.GetWorksheetStatistics();

                    for (int columnIndex = 1; columnIndex < stats.EndColumnIndex + 1; columnIndex++)
                    {

                        for (int rowIndex = 1; rowIndex < stats.EndRowIndex + 1; rowIndex++)
                        {
                            if (document.GetCellValueAsString(rowIndex, columnIndex).Equals(searchItem.Token, searchItem.StringComparison))
                            {
                                foundList.Add(new FoundItemImmutable(rowIndex, columnIndex, SLConvert.ToColumnName(columnIndex)));
                            }
                        }
                    }

                }

                return (foundList, null);

            }
            catch (Exception exception)
            {
                return (foundList, exception);
            }

        }

        /// <summary>
        /// Locate text in used cells
        /// </summary>
        /// <param name="searchItem"><seealso cref="SearchItem"/></param>
        /// <returns>Named value tuple list of <seealso cref="FoundItem"/> and <seealso cref="Exception"/></returns>
        /// <remarks>
        /// Optional, add logic for like/contains
        /// </remarks>        
        public static (IReadOnlyList<FoundItem> items, Exception exception) FindUsual(SearchItem searchItem)
        {
            List<FoundItem> foundList = new();


            try
            {
                using (var document = new SLDocument(searchItem.FileName, searchItem.SheetName))
                {

                    // Create new exception indicating the sheet was not located
                    if (!document.SheetExists(searchItem.SheetName))
                    {
                        return (foundList, new FileNotFoundException($"`{searchItem.SheetName}` does not exists in `{searchItem.FileName}`"));
                    }

                    var stats = document.GetWorksheetStatistics();

                    for (int columnIndex = 1; columnIndex < stats.EndColumnIndex + 1; columnIndex++)
                    {

                        for (int rowIndex = 1; rowIndex < stats.EndRowIndex + 1; rowIndex++)
                        {
                            //SLStyle cellFormat =document.GetCellStyle(rowIndex, columnIndex);
                            //if (cellFormat.FormatCode == "m/d/yyyy")
                            //{
                            //    Debug.WriteLine($"{document.GetCellValueAsDateTime(rowIndex, columnIndex):d} -- {cellFormat.FormatCode}");
                            //}

                            if (document.GetCellValueAsString(rowIndex, columnIndex).Equals(searchItem.Token, searchItem.StringComparison))
                            {
                                foundList.Add(new FoundItem() { RowIndex = rowIndex, ColumnIndex = columnIndex, Column = SLConvert.ToColumnName(columnIndex) });
                            }
                            
                        }
                    }

                }

                return (foundList, null);

            }
            catch (Exception exception)
            {
                return (foundList, exception);
            }

        }
    }
}