using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

namespace DictionaryConsoleApp.Classes
{
    public class EmployeeData
    {
        public long SequenceId { get; set; }
        public int YearId { get; set; }
        public int Rec { get; set; }
        public int Country { get; set; }
        public string BaseAddress { get; set; }

        public string FinalAddress()
        {

            var queryArguments = new Dictionary<string, string>()
            {
                {"SequenceId", $"{SequenceId}" },
                {"YearId", $"{YearId}" },
                {"Rec",$"{Rec}" },
                {"country",$"{Country}"}

            };

            return QueryHelpers.AddQueryString(BaseAddress, queryArguments);
        }

    }
}
