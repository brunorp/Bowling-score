using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingGame.Tests
{
    public class ScoreTests
    {
        [Fact]
        private void CompleteGameFramesScoreTest()
        {
            var game = new BowlingGame();
            Spare(game);
            PlayFrame(3, 1, game);
            Strike(game);
            Strike(game);
            PlayFrame(5, 1, game);
            Strike(game);
            PlayFrame(2, 1, game);
            Spare(game);
            Spare(game);
            PlayFrame(6, 1, game);
            Assert.Equal(13, game.TotalScore(0));
            Assert.Equal(17, game.TotalScore(1));
            Assert.Equal(42, game.TotalScore(2));
            Assert.Equal(58, game.TotalScore(3));
            Assert.Equal(64, game.TotalScore(4));
            Assert.Equal(77, game.TotalScore(5));
            Assert.Equal(80, game.TotalScore(6));
            Assert.Equal(96, game.TotalScore(7));
            Assert.Equal(112, game.TotalScore(8));
            Assert.Equal(119, game.TotalScore(9));
        }

        [Fact]
        private void AllZeroTest()
        {
            var game = new BowlingGame();
            PlaySequence(20, 0, game);
            Assert.Equal(0, game.TotalScore(9));
        }

        [Fact]
        private void NullTest()
        {
            var game = new BowlingGame();
            Assert.Equal(0, game.TotalScore(9));
        }

        [Fact]
        private void AllOneTest()
        {
            var game = new BowlingGame();
            PlaySequence(20, 1, game);
            Assert.Equal(20, game.TotalScore(9));
        }

        [Fact]
        private void PerfectGame()
        {
            var game = new BowlingGame();
            PlaySequence(12, 10, game);
            Assert.Equal(300, game.TotalScore(9));
        }

        [Fact]
        private void OnlyOneFrame()
        {
            var game = new BowlingGame();
            PlayFrame(5, 1, game);
            Assert.Equal(6, game.TotalScore(0));
        }

        [Fact]
        private void OnlyOnePlay()
        {
            var game = new BowlingGame();
            game.Play(7);
            Assert.Equal(7, game.TotalScore(0));
        }

        [Fact]
        private void StrikeTest()
        {
            var game = new BowlingGame();
            Strike(game);
            PlayFrame(5, 3, game);
            PlaySequence(17, 0, game);
            Assert.Equal(26, game.TotalScore(9));
        }

        [Fact]
        private void SpareTest()
        {
            var game = new BowlingGame();
            Spare(game);
            game.Play(3);
            PlaySequence(17, 0, game);
            Assert.Equal(16, game.TotalScore(9));
        }

        [Fact]
        private void StrikeAndSpareTest()
        {
            var game = new BowlingGame();
            Strike(game);
            Spare(game);
            PlayFrame(3, 4, game);
            Assert.Equal(40, game.TotalScore(2));
        }

        [Fact]
        private void CompleteGame()
        {
            var game = new BowlingGame();
            Spare(game);
            PlayFrame(3, 1, game);
            Strike(game);
            PlayFrame(7, 1, game);
            PlayFrame(5, 4, game);
            Strike(game);
            PlayFrame(2, 1, game);
            Spare(game);
            PlayFrame(5, 2, game);
            PlayFrame(0, 7, game);
            Assert.Equal(97, game.TotalScore(9));
        }

        private void PlaySequence(int numberOfPlays, int bowlingPins, BowlingGame game)
        {
            for (int i = 0; i < numberOfPlays; i++)
            {
                game.Play(bowlingPins);
            }
        }

        private void PlayFrame(int droppedPinsPlay1, int droppedPinsPlay2, BowlingGame game)
        {
            game.Play(droppedPinsPlay1);
            game.Play(droppedPinsPlay2);
        }

        private void Strike(BowlingGame game)
        {
            game.Play(10);
        }

        private void Spare(BowlingGame game)
        {
            game.Play(6);
            game.Play(4);
        }
    }
}

