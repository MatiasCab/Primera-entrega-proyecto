namespace RoleplayGame
{
    public class Enemie : Character,ICharacter
    {

        public Enemie(string name,int vp, int health):base(name)
        {
            this.VP=vp;
            this.Health=health;
        }
    }
}