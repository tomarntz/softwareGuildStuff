using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Funwitcollections.Collections
{
    public class nongeneric
    {
        public static void ShowArrayList()
        {
            Console.WriteLine("<= show ArrayList");

            ArrayList arrayList = new ArrayList();

            arrayList.Add("Hello");
            arrayList.Add(17);

            person p = new person();
            p.FirstName = "Tom";
            p.LastName = "Arntz";

            arrayList.Add(p);

            foreach (object o in arrayList)
            {
                Console.WriteLine(o);
            }
        }

        public static void ShowHashTable()
        {
            Console.WriteLine("<= show hash tale");

            Hashtable map = new Hashtable();

            map.Add(1,"hello");
            map.Add("world",2);
            map.Add(true, 123.456);

            person bart = new person();
            bart.FirstName = "Bart";
            bart.LastName = "Simpson";
      
            map.Add(bart.LastName,bart);

            foreach (var Key in map.Keys)
            {
                Console.WriteLine($"{Key} = {map[Key]}");
            }
            {
                
            }
        }

        public static void ShowStack()
        {
            Console.WriteLine("show Stack");

            Stack myStack = new Stack();

            myStack.Push("hello");
            myStack.Push(123);

            person kyrie = new person();
            kyrie.FirstName = "kyrie";
            kyrie.LastName = "Irving";

            myStack.Push(kyrie);

            int count = myStack.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(myStack.Pop());
            }
        }

        public static void ShowQueue()
        {
            Console.WriteLine("show Stack");

            Queue myqueue = new Queue();

            myqueue.Enqueue("hello");
            myqueue.Enqueue(123);

            person kyrie = new person();
            kyrie.FirstName = "kyrie";
            kyrie.LastName = "Irving";

            myqueue.Enqueue(kyrie);

            int count = myqueue.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(myqueue.Dequeue());
            }
        }
    }
}
