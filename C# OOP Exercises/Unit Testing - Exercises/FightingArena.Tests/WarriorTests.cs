using System;
//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Bocko",10,100);
        }

        [Test]
        public void ConstructorWorkCorrectly()
        {
            Assert.AreEqual("Bocko",warrior.Name);
            Assert.AreEqual(10,warrior.Damage);
            Assert.AreEqual(100,warrior.HP);
        }

        [Test]
        public void ConstructorThrowExceptionWithNullReference()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Bocko", 0, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Bocko", -10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Bocko", 10, -100));
        }
        [Test]
        public void AttackMethodWorkCorrectly()
        {
            var attackWarrior = new Warrior("ivan", 5, 50);
            warrior.Attack(attackWarrior);
            int expectionAttackWarriorHp = 40;
            int expectionWarriorHp = 95;
            Assert.AreEqual(expectionWarriorHp, warrior.HP);
            Assert.AreEqual(expectionAttackWarriorHp, attackWarrior.HP);
        }

        [Test]
        public void AttackWarriorWithSmallHP()
        {
            warrior = new Warrior("Gosho", 50, 200);
            var attackWarrior = new Warrior("ivan", 2, 31);
            warrior.Attack(attackWarrior);
            int expectionAttackWarriorHp = 0;
            int expectionWarriorHp = 198;
            Assert.AreEqual(expectionWarriorHp, warrior.HP);
            Assert.AreEqual(expectionAttackWarriorHp, attackWarrior.HP);
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackMethod_ShouldThrowExeption_ForMinAttackerHP(int attackerHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;

            string defenderName = "gosho";
            int defenderHP = 40;
            int defenderDmg = 10;

            var attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            var defender = new Warrior(defenderName, defenderDmg, defenderHP);
            Assert.Throws<InvalidOperationException>((() => attacker.Attack(defender)));
        }
        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackMethod_ShouldThrowExeption_ForMinDefenderHP(int defenderHP)
        {
            string attackerName = "Gosho";
            int attackerDmg = 10;
            int attackerHP = 40;

            string defenderName = "Pesho";
            int defenderDmg = 10;

            var attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            var defender = new Warrior(defenderName, defenderDmg, defenderHP);
            Assert.Throws<InvalidOperationException>((() => attacker.Attack(defender)));
        }
        [Test]
        public void AttackingStrongerEnemyThrowException()
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 35;

            string defenderName = "gosho";
            int defenderDmg = 40;
            int defenderHP = 100;

            var attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            var defender = new Warrior(defenderName, defenderDmg, defenderHP);
            Assert.Throws<InvalidOperationException>((() => attacker.Attack(defender)));
        }
    }
}