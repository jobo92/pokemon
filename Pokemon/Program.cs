using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();

            List<Move> charmenderMoves = new List<Move>();
            charmenderMoves.Add(new Move("Ember"));
            charmenderMoves.Add(new Move("Fire Blast"));
            roster.Add(new Pokemon("Charmender", 3, 52, 53, 39, Elements.Fire, charmenderMoves));

            List<Move> squirtleMoves = new List<Move>();
            squirtleMoves.Add(new Move("Bubble"));
            squirtleMoves.Add(new Move("Bite"));
            roster.Add(new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, squirtleMoves));

            List<Move> bulbasaurMoves = new List<Move>();
            bulbasaurMoves.Add(new Move("Cut"));
            bulbasaurMoves.Add(new Move("Mega Drain"));
            bulbasaurMoves.Add(new Move("Razor Leaves"));
            roster.Add(new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, bulbasaurMoves));

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        foreach(Pokemon p in roster)
                        {
                            Console.Write(p.Name + " ");
                        }
                        Console.WriteLine();
                        break;

                    case "fight":
                        //print instructions and possible pokemons
                        Console.Write("Choose who should fight(");
                        foreach (Pokemon p in roster)
                        {
                            Console.Write(p.Name + " ");
                        }
                        Console.WriteLine(")");
                        //read input
                        string input = Console.ReadLine();
                        //split the string
                        string[] fighters = input.Split(' ');
                        //if the pokemons are different than 2, something is wrong
                        if (fighters.Length != 2)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                        //let's check if both inserted pokemons are part of the roster
                        Pokemon player = null;
                        Pokemon enemy = null;
                        foreach (Pokemon p in roster)
                        {
                            if (p.Name == fighters[0])
                                player = p;
                            if (p.Name == fighters[1])
                                enemy = p;
                        }
                        //if so let's fight!
                        if (player != null && enemy != null && player != enemy)
                        {
                            //fight!
                            Console.WriteLine("A wild "+ enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //fight loop
                                //print possible moves
                                Console.Write("What move should we use? (");
                                for (int i =0; i< player.Moves.Count; i++)
                                {
                                    Console.Write(player.Moves[i].Name + "[" + i + "], ");
                                }
                                Console.WriteLine(")");
                                //get user answer, checking if it's possible
                                int move;
                                do
                                {
                                    move = int.Parse(Console.ReadLine());
                                } while (move > player.Moves.Count || move < 0) ;
                                //calculate and apply damage
                                int damage = player.Attack(enemy);
                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    Random rand = new Random();
                                    int enemyMove = rand.Next(enemy.Moves.Count);
                                    int enemyDamage = enemy.Attack(player);
                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                }
                            }
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        foreach (Pokemon p in roster)
                            p.Restore();
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
