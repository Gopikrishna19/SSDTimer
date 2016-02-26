using System;

namespace SSDTimer
{
    class SystemAge
    {
        public static string getAge()
        {
            DateTime today = DateTime.Now;
            DateTime ssd1 = new DateTime(2013, 10, 26);
            DateTime ssd2 = new DateTime(2014, 11, 17);
            return "OS SSD: " + Math.Ceiling((today - ssd1).TotalDays).ToString() + " Days " + Environment.NewLine
                + "Extra SSD: " + Math.Ceiling((today - ssd2).TotalDays).ToString() + " Days";
        }
    }
}
