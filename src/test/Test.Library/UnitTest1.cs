using NUnit.Framework;

namespace RoleplayGame
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestKnightAttacValue()
        {
            Knight templario; 
            templario= new Knight("Templario");
            templario.AddItem(new Sword());
            templario.AddItem(new Shield());
            templario.AddItem(new Armor());

            int expected1 = 20;
            int actual1 = templario.AttackValue;
            Assert.AreEqual(expected1,actual1);
        } 

        [Test]
        public void TestKnightDefenseValue()
        {
            Knight templario; 
            templario= new Knight("Templario");
            templario.AddItem(new Sword());
            templario.AddItem(new Shield());
            templario.AddItem(new Armor());

            int expected2 = 39;
            int actual2 = templario.DefenseValue;
            Assert.AreEqual(expected2,actual2);
        } 
        /*Se testea la clase knight para asegurarse que la implementacion de las interfaces no 
        perjudica el comporatemineto esperado del programa, especialmente el comportamiento de los metodos
        de obtencion del ataque y de la defensa, parte esencial del mismo*/


        [Test]
        public void TestReciveAttack()
        {
            Dwarf gimli = new Dwarf("Gimli");
            gimli.AddItem(new Axe());
            gimli.AddItem(new Helmet());
            gimli.AddItem(new Shield());

            Archer legolas = new Archer("Legolas");
            legolas.AddItem(new Bow());
            legolas.AddItem(new Helmet());
            legolas.ReceiveAttack(gimli.AttackValue);
            int expected= 85;
            int actual = legolas.Health;
            Assert.AreEqual(expected,actual);
        }
        /*Se testea el metodo recivir ataque para determinar si el mismo funciona de manera correcta
        , al igual que para saber si el metodo AttackValue funciona de igual manera, luego de haber agregado 
        las interfaces*/

        [Test]
        public void TestDefenseValue()
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new Spell());

            Wizard gandalf; 
            gandalf= new Wizard("Gandalf");
            gandalf.AddItem(new Staff());
            gandalf.SpellsBook = book;

            int expected = 120;
            int actual = gandalf.DefenseValue;
            Assert.AreEqual(expected,actual);
        }
        /*Por la misma razon que la del anterior test, este se hace para detemrinar si la implemnetacion de las
        interfaces acarrean algun error en el programa. En este caso, se testea El valor de defensa del ago, el cual esta
        compuesto por el valor de defensa de su arma y el de su hechixo en el libro de hechizos*/ 
        
        [Test]
        public void TestCharacterCreator()
        {
            ICharacter legolas = new Archer("Legolas");
            int expected= 100;
            int actual = legolas.Health;
            Assert.AreEqual(expected,actual);
        }/* Se testea la la creacion de los personajes con el tipo ICharacter, en este caso, la del arquero. Esto es para ver si la
            implementacion de la interfaz trae problemas no deseados*/

        [Test]
        public void TestEnemiReciveDamage()
        {
            Character e1 = new Enemie("e1",2,100);
            Character p1 = new Archer("p1");
            IItem H = new Helmet();
            IItem B = new Bow();
            IItem S = new Sword();
            e1.AddItem(H);
            e1.AddItem(S);
            p1.AddItem(B);
            e1.ReceiveAttack(p1.AttackValue);
            int expected= 95;
            int actual = e1.Health;
            Assert.AreEqual(expected,actual);
        }
        /* Test para determnar si la nueva clase enemi se omcporat com debe,y se es capaz de recibir daño, a pesar de que su vida no es predeterminada*/
                [Test]
        public void TestVictoryPoints()
        {
            Character e1 = new Enemie("e1",2,5);
            Character p1 = new Knight("p1");
            IItem H = new Helmet();
            IItem B = new Bow();
            IItem S = new Sword();
            e1.AddItem(H);
            e1.AddItem(S);
            p1.AddItem(B);
            e1.ReceiveAttack(p1.AttackValue);
            p1.AddVP(e1.VP);
            int actual = p1.VP;
            int expected =2;
            Assert.AreEqual(expected,actual);
        }
        /*Test para determinar si la adicion de puntos de victoria funciona correctamente*/
    }
}