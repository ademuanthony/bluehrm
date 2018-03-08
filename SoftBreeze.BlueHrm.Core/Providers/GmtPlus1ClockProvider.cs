using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Timing;

namespace SoftBreeze.BlueHrm.Providers
{
    public class GmtPlus1ClockProvider: IClockProvider
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow.AddHours(1); }
        }

        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return dateTime;
        }
    }
}
