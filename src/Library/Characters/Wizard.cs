using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : Character,ICharacter,IHero
    {

        public SpellsBook spellsBook;

        public SpellsBook SpellsBook
        {
            get
            {
                return this.spellsBook;
            }set
            {
                this.spellsBook = value;
            }
        }
        new public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in items)
                {
                    if (item is IAttackValue)
                    {
                        value += (item as IAttackValue).AttackValue;
                    }
                }
                value += this.SpellsBook.AttackValue;
                return value;
            }
        }

        new public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in items)
                {
                    if (item is IDefenseValue)
                    {
                        value += (item as IDefenseValue).DefenseValue;
                    }
                }
                value += this.SpellsBook.DefenseValue;
                return value;
            }
        }
        public Wizard(string name):base(name)
        {
        }
}
}