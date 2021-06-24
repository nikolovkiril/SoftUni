﻿using System;
//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorsWorkCorrectly()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethod_ShouldThrowInvalidOperationException_IfWarriorNameExist()
        {
            var warior = new Warrior("Bocko",10,1);
            arena.Enroll(warior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warior));
        }
        [Test]
        public void EnrollMethod_ShouldThrowInvalidOperationException_IfWarriorNameIsInvalid()
        {
            var warrior = new Warrior("Bocko", 10, 1);
            var warrior1 = new Warrior("Bocko", 10, 1);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior1));
        }
        [Test]
        public void EnrollMethodWorkCorrectly()
        {
            var warrior = new Warrior("Bocko", 10, 1);
            arena.Enroll(warrior);
            Assert.That(arena.Warriors, Has.Member(warrior));
        }
        [Test]
        public void CountWorkCorrectly()
        {
            var warrior = new Warrior("Bocko", 10, 1);
            arena.Enroll(warrior);
            int expectedCount = 1;
            int actualCount = this.arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestFight_Attacker_WithMissingAttacker()
        {
            var defenderWarrior = new Warrior("Gosho", 5, 50);
            var attackerWarrior = new Warrior("Pesho", 5, 50);
            arena.Enroll(defenderWarrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerWarrior.Name, defenderWarrior.Name));
        }
        [Test]
        public void TestFight_Defender_WithMissingDefender()
        {
            var defenderWarrior = new Warrior("Gosho", 5, 50);
            var attackerWarrior = new Warrior("Pesho", 5, 50);
            arena.Enroll(attackerWarrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerWarrior.Name, defenderWarrior.Name));
        }

        [Test]
        public void FightMethodWorkCorrectly()
        {
            var defenderWarrior = new Warrior("Gosho", 5, 50);
            var attackerWarrior = new Warrior("Pesho", 5, 50);

            arena.Enroll(defenderWarrior);
            arena.Enroll(attackerWarrior);

            var expectedAttackerHP = attackerWarrior.HP - defenderWarrior.Damage;
            var expectedDefendererHP = defenderWarrior.HP - attackerWarrior.Damage;

            arena.Fight(attackerWarrior.Name, defenderWarrior.Name);
            Assert.AreEqual(expectedAttackerHP, attackerWarrior.HP);
            Assert.AreEqual(expectedDefendererHP, defenderWarrior.HP);
        }
    }
}
