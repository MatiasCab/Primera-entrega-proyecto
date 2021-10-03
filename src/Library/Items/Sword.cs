namespace RoleplayGame
{
    public class Sword : IItem,IAttackValue
    {
        public int AttackValue 
        {
            get
            {
                return 20;
            } 
        }
    }
}