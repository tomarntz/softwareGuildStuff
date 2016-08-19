using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funwitcollections.Collections;

namespace Funwitcollections
{
    class Program
    {
        static void Main(string[] args)
        {
            nongeneric.ShowArrayList();
            nongeneric.ShowHashTable();
            nongeneric.ShowStack();
            nongeneric.ShowQueue();

            generic obj = new generic();
            obj.ShowStack();
            obj.ShowQueue();
            obj.SimpleList();
            obj.PersonDictionary();

            Console.ReadKey();
        }


    }
}
