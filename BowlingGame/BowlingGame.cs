using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class BowlingGame
    {
        public List<int> plays = new List<int>();

        private int currentIndex = 0;
        private int totalScore = 0;

        public BowlingGame()
        {
        }

        public void Play(int bowlingPins)
        {            
            plays.Insert(currentIndex, bowlingPins);
            currentIndex += 1;
            totalScore += bowlingPins;
        }

        public int TotalScore(List<int> plays)
        {
            if (plays.Count == 0)
                return 0;

            int total = 0;
            foreach(int play in plays)
                total += play;
            
            return total;
        }
    }
}
