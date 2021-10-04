using System;
using System.Collections.Generic;
using System.Threading;
using RoleplayGame;

//-*------------------------------------------------------------------------------------------------------------------
namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program.DoEncounter();
        }
        private static void DoEncounter()
        {
            Random numero = new Random();
            //listas para guardar los perosnajes y enemigos
            List<Character> personajes = new List<Character>();
            List<Enemie> enemigos = new List<Enemie>();
            Console.WriteLine("Elija la cantidad de personajes");
            int cantidadHeroes = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(1500);
            for (int number = 0;number<cantidadHeroes;number++)
            {
                bool hasta = true;
                while (hasta)
                {
                Console.WriteLine("Elija entre las razas actuales permitidas:\n1-Wizard\n2-Archer\n3-Dwarf\n4-Knight");
                int raza = Convert.ToInt32(Console.ReadLine());
                Thread.Sleep(500);
                Console.WriteLine("Elija el nombre para este personaje");//se crean los personajes
                string name = Console.ReadLine();
                switch(raza)
                {
                    case 1:
                        personajes.Add(new Wizard(name));
                        hasta = false;
                        break;
                    case 2:
                        personajes.Add(new Archer(name));
                        hasta = false;
                        break;
                    case 3:
                        personajes.Add(new Dwarf(name));
                        hasta = false;
                        break;
                    case 4:
                        personajes.Add(new Knight(name));
                        hasta = false;
                        break;
                    default:
                        Console.WriteLine("Raza invalida");
                        break;
                }
                }
                int itemspermitidos = 2;
                if (Convert.ToString(personajes[personajes.Count-1].GetType()) == "RoleplayGame.Wizard")//se toma en cuenta si la raza elegida es mago para colocarle ellibro de hechizos
                {
                Wizard personaje = (personajes[personajes.Count-1] as Wizard);
                SpellsBook book = new SpellsBook();
                book.AddSpell(new Spell());
                personaje.SpellsBook = book;
                itemspermitidos = 1;
                }
                Thread.Sleep(600);
                for (int repeticiones=0;repeticiones<itemspermitidos;repeticiones++)//se equipan lo heroes
                {
                    bool correctItem = false;
                    int item = -1;
                    while(!correctItem)
                    {
                        Console.WriteLine("Elija el equipamiento de su perosnaje(Maximo 2).\n\n1-Armor\n2-Helmet\n3-Shield\n4-Axe\n5-Bow\n6-Staff\n7-Sword\n\nEn el caso del mago, este ya tiene un item predefinido, el 'SepellBook' el cual tiene (por ahora)una cantidad predefinida de hechizos.");
                        item = Convert.ToInt32(Console.ReadLine());
                        if (item == 1 | item == 2 | item == 3 | item == 4 | item == 5 | item == 6 | item == 7)
                        {
                            correctItem = true;
                        }else
                        {
                            Console.WriteLine("Item invalido");
                        }
                    }
                    Program.SelectItem(personajes[personajes.Count-1], item);
                    Thread.Sleep(500);
                }
                Thread.Sleep(1000);
            }
            Console.WriteLine("Elija la cantidad de enemigos");
            int cantidadEnemigos = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(500);
            for (int number = 0;number<cantidadEnemigos;number++)//se crean los enemigos
            {
                Console.WriteLine("Ingrese el nombre del enemigo, la vida, y la cantidad de puntos de veictoria que posee (los items se generan aleatoriamente");
                Console.Write("Nombre:");
                string name = Console.ReadLine();
                Console.Write("Vida:");
                int vida = Convert.ToInt32(Console.ReadLine());
                Console.Write("VP:");
                int vp = Convert.ToInt32(Console.ReadLine());
                enemigos.Add(new Enemie(name,vp,vida));
                int item;
                for (var vueltas=1;vueltas<=2;vueltas++)//se equipan los enemigos
                {
                    if (vueltas%2!=0)
                    {
                        item = numero.Next(1,4);
                    }else
                    {
                        item = numero.Next(5,8);
                    }
                    Program.SelectItem(enemigos[enemigos.Count-1], item);
                    
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("Game start");
            Thread.Sleep(600);
            Console.WriteLine("En un dia de trabajo normal en el cual escoltabas un caruaje, tienes cierto escalofrio repentino...Prestas espcial atencion a tu alrededor y te das cuentas de que...¡Te adentraste en una trampa! ¡DEFIENDE LA CARGA!");
            Thread.Sleep(2000);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            bool battle = true;
            int multipleAtaque = 0;
            int restPersonajes = 1;
            bool murio = false;
            int contador = 0;
            while (battle)// A partir de aqui empieza toda la logica del juego, tomo en cuenta todos los aspectos indicados de la letra
            {
                bool oneHero = false;
                bool moreEnemies = false;
                List<Character> heroesRestantes = new List<Character>(); 
                List<Enemie> enemigosRestantes = new List<Enemie>(); 
                //los if a continuacioncomparan la coantidad de enemigos y heroes, esto es para saber que comportamiento teien que tener la batalla
                if (personajes.Count == 1)
                {
                    oneHero = true;
                }if (personajes.Count < enemigos.Count && personajes.Count != 1)
                {
                    multipleAtaque = cantidadEnemigos-cantidadHeroes;
                    restPersonajes = 1;
                    moreEnemies = true;
                }
                for (var enemigo=0;enemigo<enemigos.Count;enemigo++)// en este for los eneigos atacan a los heroes, su manera de astacar cambia dependiendo de la cantidad de heroes
                {   
                    if (oneHero)
                    {
                        personajes[0].ReceiveAttack(enemigos[enemigo].AttackValue);
                        Console.WriteLine($"{personajes[0].Name} fue atacado por {enemigos[enemigo].Name}");
                        Thread.Sleep(600);
                        if (personajes[0].Health <= 0 && enemigos.Count-1 == enemigo)
                        {
                            Console.WriteLine($"{personajes[0].Name} murio a manos de {enemigos[enemigo].Name}");
                            murio = true;
                            battle = false;
                            Thread.Sleep(600);
                        }if (!murio && enemigos.Count-1 == enemigo)
                        {  
                            heroesRestantes.Add(personajes[0]);
                        }
                    }if (moreEnemies)
                    {
                        if (multipleAtaque >= 0)
                        {
                            personajes[0].ReceiveAttack(enemigos[enemigo].AttackValue);
                            Console.WriteLine($"{personajes[0].Name} fue atacado por {enemigos[enemigo].Name}");
                            Thread.Sleep(600);
                            if (personajes[0].Health > 0 && multipleAtaque<=0)
                            {
                                heroesRestantes.Add(personajes[0]);
                            }if (personajes[0].Health <= 0 && multipleAtaque<=0)
                            {
                                Console.WriteLine($"{personajes[0].Name} murio por mutiples enemigos");
                                Thread.Sleep(600);
                            }
                            multipleAtaque -= 1;
                        }else
                        {
                            personajes[restPersonajes].ReceiveAttack(enemigos[enemigo].AttackValue);
                            Console.WriteLine($"{personajes[restPersonajes].Name} fue atacado por {enemigos[enemigo].Name}");
                            Thread.Sleep(600);
                            if (personajes[restPersonajes].Health > 0)
                            {
                                heroesRestantes.Add(personajes[restPersonajes]);
                            }else
                            {
                                Console.WriteLine($"{personajes[restPersonajes].Name} murio a manos de {enemigos[enemigo].Name}");
                                Thread.Sleep(600);
                            }
                            restPersonajes++;
                        }
                    } if (!oneHero && !moreEnemies)
                    {
                        personajes[enemigo].ReceiveAttack(enemigos[enemigo].AttackValue);
                        Console.WriteLine($"{personajes[enemigo].Name} fue atacado por {enemigos[enemigo].Name}");
                        Thread.Sleep(600);
                        if (personajes[enemigo].Health > 0)
                        {
                            heroesRestantes.Add(personajes[enemigo]);
                        }else
                        {
                            Console.WriteLine($"{personajes[enemigo].Name} murio a manos de {enemigos[enemigo].Name}");
                            Thread.Sleep(600);
                        }
                    }
                }
                if (heroesRestantes.Count <= 0)//este if es para saber si murieron todos los heores
                {
                    battle = false;
                    Console.WriteLine("Moriste defendiendo la carga valientemente.\nGAME OVER");
                }else
                {
                    personajes = heroesRestantes;
                }
                if (battle)
                {
                    foreach (Enemie enemigo in enemigos)// en este for los heroes atacan a los enemigos, todos los herores atacan a cada uno de los enemigos 1 vez
                    {
                        murio = false;
                        foreach (Character personaje in personajes)
                        {
                            enemigo.ReceiveAttack(personaje.AttackValue);
                            if (enemigo.Health <= 0 && !murio)
                            {
                                murio = true;
                                personaje.AddVP(enemigo.VP);
                                Console.Write($"{personaje.Name} mato a {enemigo.Name} y recivio {enemigo.VP} puntos de victoria");
                                if (enemigo.VP >= 5)
                                {
                                    personaje.Cure();
                                    Console.Write(" recuperando su vida");
                                }
                                Console.WriteLine();
                            }
                        }
                        if (enemigo.Health > 0)
                        {
                            enemigosRestantes.Add(enemigo);
                        }
                    }
                    if (enemigosRestantes.Count <= 0)//este if es para saber si quedan enemigos vivos
                    {
                        battle = false;
                        Console.WriteLine("Felicidades, defendiste la carga con exito.\nGAME OVER");
                    }else
                    {
                        Console.WriteLine("Atacaste a los enemigos");
                        Thread.Sleep(600);
                        enemigos = enemigosRestantes;
                    }
                }
            if (contador == 8)//este if es para un caso especial...descubrelo
            {
                Console.WriteLine("PUM...giro dramatico");
                Thread.Sleep(1000);
                int opcion = numero.Next(1,3);
                if (opcion == 1)
                {
                    Console.WriteLine("Los ladrones se resignaron en robar la carga, pudiste salvaguardar la mercancia ¡Felicidades!\nGAME OVER");
                }else
                {
                Console.WriteLine("Huiste de la batlla...¡Cobarde!\nGAME OVER");
                }
                battle = false;
            }
            contador++;
            }
        }
            private static void SelectItem(Character personaje, int item)//metodo para selecionar items(tener este metdod ahora el repetir codigo)
            {
                switch(item)
                {
                    case 1:
                        personaje.AddItem(new Armor());
                        break;
                    case 4:
                        personaje.AddItem(new Axe());
                        break;
                    case 5:
                        personaje.AddItem(new Bow());
                        break;
                    case 2:
                        personaje.AddItem(new Helmet());
                        break;
                    case 3:
                        personaje.AddItem(new Shield());
                        break;
                    case 6:
                        personaje.AddItem(new Staff());
                        break;
                    case 7:
                        personaje.AddItem(new Sword());
                        break;
                    default:
                        Console.WriteLine("Item invalido");
                        break;
                }
            }
    }
}