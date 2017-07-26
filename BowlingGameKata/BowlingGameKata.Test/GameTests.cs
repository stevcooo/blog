using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Test
{
    [TestClass]
    public class GameTests
    {
        private Game g;

        [TestInitialize]
        public void Init()
        {
            g = new Game();
        }

        [TestCleanup]
        public void CleanUP()
        {
            g = null;
        }

        [TestMethod]
        public void TestGame()
        {
        }

        [TestMethod]
        public void TestRoll()
        {
            g.Roll(0);
        }

        [TestMethod]
        public void TestScore()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestSpare()
        {
            RollSpare();            
            g.Roll(2);
            RollMany(17, 0);
            Assert.AreEqual(14, g.Score());
        }

        [TestMethod]
        public void TestStrike()
        {
            RollStrike();            
            g.Roll(3); // 20
            g.Roll(4); //24
            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }       

        private void RollMany(int turns, int value)
        {
            for(int i = 0; i < turns; i++)
            {
                g.Roll(value);
            }
        }
        private void RollSpare()
        {
            g.Roll(4);
            g.Roll(6);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
    }
}
