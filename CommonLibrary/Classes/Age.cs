using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Classes
{
    public class Age
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        /// <summary>
        /// Date to calculate off of a later date
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Date to calculate off a earlier date
        /// </summary>
        public DateTime To { get; set; }

        #region for wrapping results

        public string YearsMonthsDays => $"{Years} years {Months} months {Days} days";
        public string YearsMonths => $"{Years} years {Months} months";

        #endregion


    }
}
