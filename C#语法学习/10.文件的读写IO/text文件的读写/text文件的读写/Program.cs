using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text文件的读写
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = System.Environment.CurrentDirectory + @"\text保存\";   //获取文件夹路径
            string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            using ( StreamWriter sw = new StreamWriter("names.txt"))
            {
                foreach (string s in names)
                {
                    sw.WriteLine(s);

                }
            }

            // 从文件中读取并显示每行
            string line = "";
            using (StreamReader sr = new StreamReader("names.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
