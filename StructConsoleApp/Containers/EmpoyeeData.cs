using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructConsoleApp.Containers
{
    public class EmployeeData
    {
        public int Id { get; init; }
        public EmployeeData(int employeeId)
        {
            Id = employeeId;
        }
    }
}
