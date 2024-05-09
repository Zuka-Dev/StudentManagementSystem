using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Helpers
{
    public static class GenerateRegNumber
    {
        public static string GetRegNumber(DateTime dateTime)
        {
            var date = dateTime.ToString("yyyy/MM/dd/hh/mm");
            date = date.Replace("/", "");
            return date;
        }
    }
}
