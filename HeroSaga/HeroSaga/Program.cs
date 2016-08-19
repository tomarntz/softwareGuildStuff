using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroSaga.Data;
using HeroSaga.Models;

namespace HeroSaga
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HeroContex context = new HeroContex())
            {
                Monster monster = new Monster();
                monster.Name = "DBA";
                context.Monsters.Add(monster);
                context.SaveChanges();

                //Characters myCharacter = context.Characters.Find(1);
                //Console.WriteLine(myCharacter.Name);
                //Console.WriteLine(myCharacter.Discription);
                //Console.WriteLine(myCharacter.Age);
                //Console.WriteLine(myCharacter.Alignment);

                //myCharacter.Alignment = Alignment.Lawful;

                //context.Characters.AddOrUpdate(myCharacter);
                //context.SaveChanges();

                //Characters character = new Characters();
                //character.Name = "Bob The Great EF Wizard";
                //character.Age = 5;
                //character.Discription = "Does black magic,  frightens all the DBA's";
                //character.Alignment = Alignment.Chaotic;
                //character.Race = new Race()
                //{
                //    Name = "Human"
                //};
                //context.Characters.Add(character);

                //context.SaveChanges();
            }
            Console.ReadLine();

        }
    }
}
