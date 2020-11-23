using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space_Invaders.Code;
using System;

namespace SpaceInvadersTest
{
    [TestClass]
    public class EnemyBulletTests
    {
        [TestMethod]
        public void MoveForwardTest()
        {
            int expectedX = 0;
            int expectedY = 10;

            EnemyBullet enemyBullet = new EnemyBullet
            {
                X = 0,
                Y = 0
            };

            enemyBullet.MoveForward();

            int actualX = enemyBullet.X;
            int actualY = enemyBullet.Y;

            Assert.AreEqual(expectedX, actualX, "Bullet X is not correct");
            Assert.AreEqual(expectedY, actualY, "Bullet Y is not correct");
        }
    }
}
