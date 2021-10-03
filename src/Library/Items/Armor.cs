namespace RoleplayGame
{
    public class Armor : IItem,IDefenseValue
    {
        public int DefenseValue
        {
            get
            {
                return 25;
            }
        }
    }
}