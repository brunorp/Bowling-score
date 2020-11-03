using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class BowlingGame
    {
        private int[] plays = new int[24];

        private int currentPlay = 0;

        //Make the moves by entering the number of bowling pins that have been dropped in a list
        public void Play(int bowlingPins)
        {
            plays[currentPlay] = bowlingPins;

            if (bowlingPins == 10)
            {
                plays[currentPlay + 1] = 0;
                currentPlay += 2;
            }
            else
                currentPlay += 1;
        }

        //Calculates the total score
        public int TotalScore(int frame)
        {
            if (plays.Length == 0)
                return 0;

            List<int> score = new List<int>();
            int totalOfPoints = 0;
            int index = 0; //index of moves

            for (int i = 0; i < 10; i++)
            {
                if (VerifyScoreType(index) == "multiple strike")
                    totalOfPoints += MultipleStrikeBonus(index);
                else if (VerifyScoreType(index) == "strike")
                    totalOfPoints += StrikeBonus(index);
                else if (VerifyScoreType(index) == "spare")
                    totalOfPoints += SpareBonus(index);
                else
                    totalOfPoints += SumOfPinsInFrame(index);

                score.Add(totalOfPoints);
                index += 2;
            }

            return score[frame];
        }

        //check for strikes and spares and return the type of score
        private string VerifyScoreType(int index)
        {
            if (plays[index] == 10)
            {
                if (plays[index + 2] == 10)
                    return "multiple strike";
                else
                    return "strike";
            }
            else if (plays[index] + plays[index + 1] == 10)
                return "spare";
            else
                return "normal";
        }

        private int MultipleStrikeBonus(int index)
        {
            return 10 + plays[index + 2] + plays[index + 4];
        }

        private int StrikeBonus(int index)
        {
            return 10 + plays[index + 2] + plays[index + 3];
        }

        private int SpareBonus(int index)
        {
            return 10 + plays[index + 2];
        }

        private int SumOfPinsInFrame(int index)
        {
            return plays[index] + plays[index + 1];
        }
    }
}
