namespace RoleplayGame
{
    public class Helmet : IItem,IDefenseValue
    {
        public int DefenseValue
        {
            get
            {
                return 18;
            }
        }
    }
}