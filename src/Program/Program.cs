using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new Spell());

            Wizard gandalf; 
            gandalf= new Wizard("Gandalf");
            gandalf.AddItem(new Staff());
            gandalf.SpellsBook = book;

            Dwarf gimli = new Dwarf("Gimli");
            gimli.AddItem(new Axe());
            gimli.AddItem(new Helmet());
            gimli.AddItem(new Shield());
            Console.WriteLine(gimli.DefenseValue);
            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        }
    }
}
