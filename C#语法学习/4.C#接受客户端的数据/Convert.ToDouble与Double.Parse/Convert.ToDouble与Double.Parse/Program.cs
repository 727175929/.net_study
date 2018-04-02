using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Convert.ToDouble与Double.Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string a = "0.2";
                //string a = null;
                string a = "";
                try
                {
                    double d1 = Double.Parse(a);
                }
                catch (Exception err)
                {
                    Console.WriteLine("d1转换出错:" + err.Message);
                }

                try
                {
                    double d2 = Convert(a);
                }
                catch (Exception err)
                {
                    Console.WriteLine("d2转换出错:" + err.Message);

                }
                try
                {
                    double d3;
                    Double.TryParse(a, out d3);
                }
                catch (Exception err)
                {
                    Console.WriteLine("d3转换出错:" + err.Message);
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
