using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            StringArray array = new StringArray();
            array.addString("0 asda");
            array.addString("1 sadss");
            array.addString("2 sad");
            array.deleteString(2);
            array.modifyString(0,"0 modify");


            Console.WriteLine(array.toString());
            Console.ReadLine();
        }
    }
}
