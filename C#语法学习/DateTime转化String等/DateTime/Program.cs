using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTime1
{
    class Program
    {
        static void Main(string[] args)
        {
            String a = "2017/9/15 12:00";
            Console.WriteLine("String类型的时间为"+a);

            DateTime aa;
            aa = Convert.ToDateTime(a);
            Console.WriteLine("DateTime类型的时间为" + aa);

            DateTime bb;
            bb = aa.AddDays(-5);
            Console.WriteLine("DateTime减去3天的时间为" + bb);

           

           
            
            Console.ReadLine();
        }
    }
}
