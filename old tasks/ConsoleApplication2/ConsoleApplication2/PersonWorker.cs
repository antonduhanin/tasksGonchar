using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class PersonWorker
    {
        public List<Person> persons = new List<Person>();
        public void init(){
            persons.Add(new Person("anton", 12));
            persons.Add(new Person("jason", 12));
            persons.Add(new Person("kaney", 45));
        }

        public IEnumerable<Person> PersonOlderThan(int age)
        {
            return from person in persons where person.Age > age select person; 
        }

        public IEnumerable<Person> PersonWithName(string name)
        {
            return from person in persons where person.Name.Equals(name) select person;
        }
       
    }
}
