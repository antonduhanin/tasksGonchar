using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonWorker worker = new PersonWorker();
            int i = 0;



            while (i != -1)
            {
                try
                {
                    Console.WriteLine("1 init collection");
                    Console.WriteLine("2 older than");
                    Console.WriteLine("3 select persons with name");
                    Console.WriteLine("4 group by age");
                    Console.WriteLine("5 show all");
                    Console.WriteLine("-1 exit");
                    string choose = Console.ReadLine();
                    i = Int32.Parse(choose);
                    switch (i)
                    {
                        case 1:
                            {
                                worker.init();
                                Console.WriteLine("init success: ");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("print age: ");
                                int age = Int32.Parse(Console.ReadLine());
                                foreach (Person person in worker.PersonOlderThan(age))
                                {
                                    Console.WriteLine(person.Name);
                                    Console.WriteLine(person.Age);
                                }
                                break;
                            }

                        case 3:
                            {
                                Console.WriteLine("print name: ");
                                string name = Console.ReadLine();
                                foreach (Person person in worker.PersonWithName(name))
                                {
                                    Console.WriteLine(person.Name);
                                    Console.WriteLine(person.Age);
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("group by age: ");
                                var ageList = from person in worker.persons group person by person.Age into g select g;
                                foreach (var age in ageList)
                                {
                                    Console.WriteLine(age.Key);
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("show all: ");
                                foreach (Person person in worker.persons)
                                {
                                    Console.WriteLine(person.Name);
                                    Console.WriteLine(person.Age);
                                }
                                break;
                            }

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("error" + e.Message);
                }
            }
                }
        }
    }

