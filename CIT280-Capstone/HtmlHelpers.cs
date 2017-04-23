using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CIT280_Capstone
{
    public static class HtmlHelpers
    {
        public static string DisplayForPhone(string phone)
        {
            if (phone == null)
                return phone;
            
            string formated = phone;

            if (phone.Length == 10)
                formated = string.Format("({0}) {1}-{2}", phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6, 4));
            
            else if (phone.Length == 7)
                formated = string.Format("{0}-{1}", phone.Substring(0, 3), phone.Substring(3, 4));
            
            string s = string.Format("<a href='tel:{0}'>{1}</a>", phone, formated);
            return formated;
        }
    }
}
