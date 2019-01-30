using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class StringArray
    {
        private string[] array = new string[0];
        public void addString(string inputString)
        {
            string[] temp = new String[array.Length+1];
            Array.Copy(array, temp, array.Length);
            temp[temp.Length - 1] = inputString;
            array = temp;
        }

        public void deleteString(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                string[] temp = new String[array.Length + 1];
                int j =0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i != index)
                    {
                        temp[j] = array[i];
                        j++;
                    }
                }
                array = temp;


            }
        }

        public void modifyString(int index,string newValue)
        {
            if (index >= 0 && index < array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == index)
                    {
                        array[index] = newValue;
                    }
                }


            }
        }

        public string[] getArray(){
            return array;
        }

        public string toString()
        {
            string result = "";
            foreach(string s in array){
                result += s + "\n";
            }
            return result;
        }
    }
}
