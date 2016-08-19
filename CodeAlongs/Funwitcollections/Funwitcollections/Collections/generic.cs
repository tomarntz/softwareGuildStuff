using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funwitcollections.Collections
{
    public class generic
    {
        public void ShowStack()
        {
            Console.WriteLine("<= generic show stack");

            Stack<person> people = new Stack<person>();

            people.Push(new person() {FirstName = "homer", LastName = "Simson"});
            people.Push(new person() { FirstName = "bart", LastName = "Simson" });
            people.Push(new person() { FirstName = "Lisa", LastName = "Simson" });

            int count = people.Count;
            person simpson;
            for (int i = 0; i < count; i++)
            {
                simpson = people.Pop();

                Console.WriteLine($"{simpson.FirstName}{simpson.LastName}");
            }
        }

        public void ShowQueue()
        {
            Console.WriteLine("<= generic show stack");

            Queue<person> people = new Queue<person>();

            people.Enqueue(new person() {FirstName = "homer", LastName = "Simson"});
            people.Enqueue(new person() {FirstName = "bart", LastName = "Simson"});
            people.Enqueue(new person() {FirstName = "Lisa", LastName = "Simson"});

            int count = people.Count;
            person simpson;
            for (int i = 0; i < count; i++)
            {
                simpson = people.Dequeue();

                Console.WriteLine($"{simpson.FirstName}{simpson.LastName}");
            }
        }

        public void SimpleList()
        {
            Console.WriteLine("<= Simple List");

            List<int> numbers =  new List<int>();

            //1
            numbers.Add(1);
            //1,5,4,3,2
            numbers.AddRange(new int[] {5,4,3,2});
            //1,5,4,100,2
            numbers.Insert(2,100);

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            //1,5,100,3,2
            numbers.Remove(4);
            //100,3,2
            numbers.RemoveRange(0,2);
            //3,2
            numbers.RemoveAt(0);

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
        }

        public void PersonDictionary()
        {

            Console.WriteLine("<= Person Dictionary");

            Dictionary<string, person> people = new Dictionary<string, person>();

            person kyrie = new person() {FirstName = "kyrie",LastName = "Irving"};
            person bart = new person() { FirstName = "bart", LastName = "simpson" };
            person jason = new person() { FirstName = "jason", LastName = "kipnis" };

            people.Add(kyrie.LastName,kyrie);
            people.Add(bart.LastName,bart);
            people.Add(jason.LastName,jason);

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Value.FirstName}{person.Key}");
            }

            Console.WriteLine($"{people["kipnis"].FirstName}");

        }
    }
}
