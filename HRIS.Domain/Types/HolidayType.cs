using System.Collections.Generic;
using System.Linq;

namespace HRIS.Domain.Types
{
    public class HolidayType
    {
        private HolidayType(string value, string display) { Value = value; Display = display; }
        public string Value { get; set; }
        public string Display { get; set; }
        public static HolidayType Regular { get { return new HolidayType("RegularHoliday", "Regular Holiday"); } }
        public static HolidayType SpecialNonWorking { get { return new HolidayType("SpecialNonWorkingHoliday", "Special Non-Working Holiday"); } }
        public static HolidayType SpecialWorking { get { return new HolidayType("SpecialWorkingHoliday", "Special Working Holiday"); } }
        public static string GetValue(string key) {
            if(key == Regular.Value) return Regular.Display;
            else if (key == SpecialNonWorking.Value) return SpecialNonWorking.Display;
            else if (key == SpecialWorking.Value) return SpecialWorking.Display;

            return string.Empty;
        }
    }
}
