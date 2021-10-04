using System.Collections.Generic;
namespace RoleplayGame
{
    public class Character
    {
        protected int health = 100;
        protected int vp = 0;
        
        protected List<IItem> items = new List<IItem>();

        public Character(string name)
        {
            Name=name;
        }

        public string Name { get; set; }


        public int AttackValue
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
                    return value;
                }
            }

        public int DefenseValue
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
                    return value;
                }
            }
        

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public int VP
        {
            get
            {
                return this.vp;
            }protected set
            {
                this.vp=value;
            }
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= (power - this.DefenseValue);
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public void AddVP(int vp)
        {
            this.VP+=vp;
        }
    }
}
