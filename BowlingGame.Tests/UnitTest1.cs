using System;
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

