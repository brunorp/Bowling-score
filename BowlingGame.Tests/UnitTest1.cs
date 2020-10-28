using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingGame.Tests
{
    public class ScoreTests
    {
        [Fact]
        public void AllTests()
        {
            AllZeroTest();
            StrikeTest();
            SpareTest();
            CompleteGame();
            PerfectGame();
            StrikeAndSpareTest();
            testtt();
        }

        private void testtt()
        {
            var game = new BowlingGame();
            game.Play(6);
            game.Play(4);
            game.Play(3);
            game.Play(1);
            game.Play(10);
            game.Play(10);
            game.Play(1);
            game.Play(5);
            game.Play(10);
            game.Play(1);
            game.Play(2);
            game.Play(4);
            game.Play(6);
            game.Play(6);
            game.Play(4);
            game.Play(6);
            game.Play(1);
            Assert.Equal(13, game.TotalScore(0));
            Assert.Equal(17, game.TotalScore(1));
            Assert.Equal(38, game.TotalScore(2));
            Assert.Equal(54, game.TotalScore(3));
            Assert.Equal(60, game.TotalScore(4));
            Assert.Equal(73, game.TotalScore(5));
            Assert.Equal(76, game.TotalScore(6));
            Assert.Equal(92, game.TotalScore(7));
            Assert.Equal(108, game.TotalScore(8));
            Assert.Equal(115, game.TotalScore(9));
        }

        private void AllZeroTest()
        {
            var game = new BowlingGame();
            PlaySequence(20, 0, game);
            Assert.Equal(0, game.TotalScore());
        }

        private void PerfectGame()
        {
            var game = new BowlingGame();
            PlaySequence(12, 10, game);
            Assert.Equal(300, game.TotalScore());
        }

        private void StrikeTest()
        {
            var game = new BowlingGame();
            game.Play(10);
            game.Play(5);
            game.Play(3);
            PlaySequence(17, 0, game);
            Assert.Equal(26, game.TotalScore());
        }

        private void SpareTest()
        {
            var game = new BowlingGame();
            game.Play(6);
            game.Play(4);
            game.Play(3);
            PlaySequence(17, 0, game);
            Assert.Equal(16, game.TotalScore());
        }

        private void StrikeAndSpareTest()
        {
            var game = new BowlingGame();
            game.Play(10);
            game.Play(4);
            game.Play(6); 
            game.Play(3);
            game.Play(0);
            PlaySequence(15, 0, game);
            Assert.Equal(36, game.TotalScore());
        }

        private void CompleteGame()
        {
            var game = new BowlingGame();
            game.Play(6);
            game.Play(4);
            game.Play(3);
            game.Play(1);
            game.Play(10);
            game.Play(7);
            game.Play(1);
            game.Play(5);
            game.Play(4);
            game.Play(10);
            game.Play(1);
            game.Play(2);
            game.Play(4);
            game.Play(6);
            game.Play(5);
            game.Play(2);
            game.Play(0);
            game.Play(7);
            Assert.Equal(97, game.TotalScore());
        }

        private void PlaySequence(int numberOfPlays, int bowlingPins, BowlingGame game)
        {
            for(int i = 0; i < numberOfPlays; i++)
            {
                game.Play(bowlingPins);
            }
        }
    }
}

