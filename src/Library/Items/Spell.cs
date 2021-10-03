namespace RoleplayGame
{
    public class Spell : ISpell,IAttackValue,IDefenseValue
    {
        public int AttackValue
        {
            get
            {
                return 70;
            }
        }

        public int DefenseValue
        {
            get
            {
                return 70;
            }
        }
    }
}