namespace RoleplayGame
{
    public class Staff : IItem,IAttackValue,IDefenseValue
    {
        public int AttackValue 
        {
            get
            {
                return 50;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 50;
            }
        }
    }
}