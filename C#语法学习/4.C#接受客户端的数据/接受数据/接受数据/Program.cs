using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接受数据
{
    class Program
    {
        static void Main(string[] args)
        {
            //c# 控制台输入代码 Console.ReadLine();       接受控制台的数据Console.ReadLine();  
            //这段代码的返回值是string类型，所以需要创建一个string变量接收
            string a = Console.ReadLine();     
            //接收并转换为int类型可使用 int.Parse();或(万能转换器)Convert.ToInt32();
            //以上2种方法只能转换string类型的数字字符串
            //int b = int.Parse(a);//创建int变量接收转换后的值
   
            int b = Convert.ToInt32(a);//创建int变量接收转换后的值
            //最后输出
            Console.WriteLine(b);
            //Crtl+F5调试，从控制台输入数字就可以看到效果了~
            Console.ReadLine();
        }
    }
}
