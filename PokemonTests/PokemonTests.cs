using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Tests
{
    [TestClass()]
    public class PokemonTests
    {

        [TestMethod()]
        public void AttackTest()
        {
            List<Move> charmenderMoves = new List<Move>();
            charmenderMoves.Add(new Move("Ember"));
            charmenderMoves.Add(new Move("Fire Blast"));
            Pokemon charmender = new Pokemon("Charmender", 3, 52, 53, 39, Elements.Fire, charmenderMoves);

            List<Move> squirtleMoves = new List<Move>();
            squirtleMoves.Add(new Move("Bubble"));
            squirtleMoves.Add(new Move("Bite"));
            Pokemon squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, squirtleMoves);

            int d1 = charmender.Attack(squirtle);
            int d2 = squirtle.Attack(charmender);

            Assert.AreEqual(d1, 0);
            Assert.AreEqual(d2, 33);
        }

        [DataTestMethod]
        [DataRow(Elements.Water, 10, 5)]
        [DataRow(Elements.Fire, 10, 10)]
        [DataRow(Elements.Grass, 10, 20)]
        public void CalculateElementalEffectsTest(Elements element, int damage, int result)
        {
            List<Move> charmenderMoves = new List<Move>();
            charmenderMoves.Add(new Move("Ember"));
            charmenderMoves.Add(new Move("Fire Blast"));
            Pokemon charmender = new Pokemon("Charmender", 3, 52, 53, 39, Elements.Fire, charmenderMoves);

            int res = charmender.CalculateElementalEffects(damage, element);
            Assert.AreEqual<int>(res, result);
        }

        
    }
}