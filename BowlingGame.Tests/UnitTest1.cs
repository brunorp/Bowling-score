using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class ScoreTests
    {
        [Fact]
        public void Test1()
        {
            var test1 = new BowlingGame();
            for (int i = 0; i < 20; i++)
            {
                test1.Play(1);
            }

            Assert.Equal(20, test1.TotalScore(test1.plays));
        }
    }
}
