using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据转换
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 5673.74;
            int i;

            // 强制转换 double 为 int
            i = (int)d;
            Console.WriteLine(i);

            int i2 = 75;
            float f = 53.005f;
            double d2 = 2345.7652;
            bool b = true;
            //转化为字符串输出
            Console.WriteLine(i2.ToString());
            Console.WriteLine(f.ToString());
            Console.WriteLine(d2.ToString());
            Console.WriteLine(b.ToString());
            Console.ReadKey();
        }
    }
}
