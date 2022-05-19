using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FnacDarty.JobInterview.Stock
{
    public static class TypesExtensions
    {
        public static int ConvertToFnacDateInteger(this DateTime dat)
        {
            int year = dat.Year;
            int month = dat.Month;
            int day = dat.Day;

            string MonthStr = month < 10 ? "0" + month : month.ToString();
            string DayStr = day < 10 ? "0" + day : day.ToString();

            StringBuilder builder = new StringBuilder();
            builder.Append(year.ToString());
            builder.Append(MonthStr.ToString());
            builder.Append(DayStr.ToString());
            return int.Parse(builder.ToString());
        }

        public static string FormatFnacDateInteger(this int dat)
        {
            string datStr = dat.ToString();
            string year = datStr.Substring(0, 4);
            string month = datStr.Substring(4, 2);
            string day = datStr.Substring(6, 2);

            StringBuilder builder = new StringBuilder();
            builder.Append(day);
            builder.Append("/");
            builder.Append(month);
            builder.Append("/");
            builder.Append(year);

            return builder.ToString();

        }

        public static bool IsValidFnacDateInteger(this int dat)
        {
            //date entre 1 janvier 2000 et 31 décembre 2099
            if (dat < 20000101 || dat > 21000101)
            {
                return false;
            }
            int year = dat / 10000;
            int month = (dat / 100) % 100;
            int day = dat % 100;
            if (day > 31) return false;
            if (month > 12 || month < 1) return false;
            if (day > DateTime.DaysInMonth(year, month)) return false;


            return true;
        }

        public static bool IsValidEAN(this string ean)
        {
            if (ean.Length != 8) return false;
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(ean);
        }
    }
}
