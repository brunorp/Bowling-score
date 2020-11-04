using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingGame.Tests
{
    public class ScoreTests
    {

        BowlingGame game;

        public ScoreTests()
        {
            game = new BowlingGame();
        }

        [Fact]
        private void CompleteGameFramesScoreTest()
        {
            Spare();
            PlayFrame(3, 1);
            Strike();
            Strike();
            PlayFrame(5, 1);
            Strike();
            PlayFrame(2, 1);
            Spare();
            Spare();
            PlayFrame(6, 1);
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
            PlaySequence(20, 0);
            Assert.Equal(0, game.TotalScore(9));
        }

        [Fact]
        private void NullTest()
        {
            Assert.Equal(0, game.TotalScore(9));
        }

        [Fact]
        private void AllOneTest()
        {
            PlaySequence(20, 1);
            Assert.Equal(20, game.TotalScore(9));
        }

        [Fact]
        private void PerfectGame()
        {
            PlaySequence(12, 10);
            Assert.Equal(300, game.TotalScore(9));
        }

        [Fact]
        private void OnlyOneFrame()
        {
            PlayFrame(5, 1);
            Assert.Equal(6, game.TotalScore(0));
        }

        [Fact]
        private void OnlyOnePlay()
        {
            game.Play(7);
            Assert.Equal(7, game.TotalScore(0));
        }

        [Fact]
        private void StrikeTest()
        {
            Strike();
            PlayFrame(5, 3);
            PlaySequence(17, 0);
            Assert.Equal(26, game.TotalScore(9));
        }

        [Fact]
        private void SpareTest()
        {
            Spare();
            game.Play(3);
            PlaySequence(17, 0);
            Assert.Equal(16, game.TotalScore(9));
        }

        [Fact]
        private void StrikeAndSpareTest()
        {
            Strike();
            Spare();
            PlayFrame(3, 4);
            Assert.Equal(40, game.TotalScore(2));
        }

        [Fact]
        private void CompleteGame()
        {
            Spare();
            PlayFrame(3, 1);
            Strike();
            PlayFrame(7, 1);
            PlayFrame(5, 4);
            Strike();
            PlayFrame(2, 1);
            Spare();
            PlayFrame(5, 2);
            PlayFrame(0, 7);
            Assert.Equal(97, game.TotalScore(9));
        }

        private void PlaySequence(int numberOfPlays, int bowlingPins)
        {
            for (int i = 0; i < numberOfPlays; i++)
            {
                game.Play(bowlingPins);
            }
        }

        private void PlayFrame(int droppedPinsPlay1, int droppedPinsPlay2)
        {
            game.Play(droppedPinsPlay1);
            game.Play(droppedPinsPlay2);
        }

        private void Strike()
        {
            game.Play(10);
        }

        private void Spare()
        {
            game.Play(6);
            game.Play(4);
        }
    }
}

