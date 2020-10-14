using System.Collections.Generic;
using System.Linq;
using TimeSheet.Common.Models;

namespace TimeSheet.Common
{
    public class TimeSheetProcessor
    {
        public static int CalculateTimeForCustomer(List<TimeSheetEntryModel> entries, string customerName)
        {
            int sum = 0;

            foreach (var entry in entries)
            {
                int customerIndex = entry.WorkDone.IndexOf(customerName, System.StringComparison.OrdinalIgnoreCase);
                if (customerIndex > 0)
                //if (entry.WorkDone.Contains(customerName))
                {
                    sum += entry.HoursWorked;
                }
            }

            return sum;
        }
    }
}
