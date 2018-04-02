using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int num = r.Next(0, 3);//随机生成一个5位整数
            Console.WriteLine(num);
            num = r.Next(0, 3);//随机生成一个5位整数
            Console.WriteLine(num);
            num = r.Next(0, 3);//随机生成一个5位整数
            Console.WriteLine(num);
            num = r.Next(0, 3);//随机生成一个5位整数
            Console.WriteLine(num);
            num = r.Next(0, 3);//随机生成一个5位整数
            Console.WriteLine(num);
            num = r.Next(0, 3);//随机生成一个5位整数
            Console.ReadKey();
        }
    }
}
