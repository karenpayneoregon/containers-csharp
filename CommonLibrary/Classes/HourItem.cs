using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Classes
{
    public class HourItem
    {
        public string Text { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public override string ToString() => Text;

    }
}
