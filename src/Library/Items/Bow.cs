namespace RoleplayGame
{
    public class Bow : IItem,IAttackValue
    {
        public int AttackValue 
        {
            get
            {
                return 15;
            } 
        }
    }
}