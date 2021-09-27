namespace RoleplayGame
{
    public class Dwarf
    {
        private int health = 100;
        

        public Dwarf(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Axe Axe { get; set; }

        public Shield Shield { get; set; }

        public Helmet Helmet { get; set; }

        public int AttackValue
        {
            get
            {
                if (Axe != null)
                {
                    return Axe.AttackValue;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DefenseValue
        {
            get
            {
                if (Helmet != null && Shield != null)
                {
                    return Shield.DefenseValue + Helmet.DefenseValue;
                }
                if (Helmet != null)
                {
                    return Helmet.DefenseValue;
                }
                if (Shield != null)
                {
                    return Shield.DefenseValue;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }
    }
}