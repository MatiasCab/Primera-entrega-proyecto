namespace RoleplayGame
{
    public class Axe : IItem,IAttackValue
    {
        public int AttackValue 
        {
            get
            {
                return 25;
            } 
        }
    }
}