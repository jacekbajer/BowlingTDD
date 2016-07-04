using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BowlingTDD.Tests
{
    public class GameTests
    {
        [Test]
        public void When_Less_Than_10_Pins_In_Every_Frame_Result_Is_Sum_Of_All_Rolls()
        {
            var game = new Game();

            var rollList = new List<int> { 2,2,
                                           3,4,
                                           5,1,
                                           7,1,
                                           9,0,
                                           5,3,
                                           4,0,
                                           4,0,
                                           2,6,
                                           4,2 };

            rollList.ForEach(x => game.Roll(x));

            Assert.That(game.Score(), Is.EqualTo(rollList.Sum()));
        }

        [Test]
        public void When_Maximum_In_One_Frame_Then_Next_Roll_Is_Added_To_Score()
        {
            var game = new Game();

            var rollList = new List<int> { 2,8,
                                           3,7,
                                           5,1,
                                           7,1,
                                           9,1,
                                           8,2,
                                           7,3,
                                           1,0,
                                           0,4,
                                           8,2
            };

            rollList.ForEach(x => game.Roll(x));

            Assert.That(game.Score(), Is.EqualTo(13 + 15 + 6 + 8 + 18 + 17 + 11 + 1 + 4 + 10));
        }
    }

    public class Game
    {
        private int _score;

        public void Roll(int pins)
        {
            _score = _score + pins;
        }

        public object Score()
        {
            return _score;
        }
    }
}
