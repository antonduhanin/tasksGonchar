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
            Int32 choose = 0;


            while(choose!= 5){
                try
                {
                    Console.WriteLine("enter number");
                    choose = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("your choose " + choose);
                }
                catch (Exception)
                {
                Console.WriteLine("incorrect " );
                }
            }
            
        }
    }
}
