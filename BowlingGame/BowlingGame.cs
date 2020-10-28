using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class BowlingGame
    {
        private List<int> plays = new List<int>();
       
        private int currentPlay = 0;

        //Make the moves by entering the number of bowling pins that have been dropped in a list
        public void Play(int bowlingPins)
        {   
            if (bowlingPins == 10)
            {
                plays.Insert(currentPlay, bowlingPins);
                plays.Insert(currentPlay + 1, 0);
                currentPlay += 2;
            }
            else
            {
                plays.Insert(currentPlay, bowlingPins);
                currentPlay += 1;
            }            
        }

        //Calculates the total score
        public int TotalScore()
        {
            if (plays.Count == 0)
                return 0;

            int totalOfPoints = 0;
            int index = 0; //index of moves

            for(int i = 0; i < 10; i++)
            {
                if(VerifyScoreType(index) == "multiple strike")  
                    totalOfPoints += (10 + plays[index + 2] + plays[index + 4]);
                else if(VerifyScoreType(index) == "strike")
                    totalOfPoints += (10 + plays[index + 2] + plays[index + 3]);
                else if (VerifyScoreType(index) == "spare")
                    totalOfPoints += (10 + plays[index + 2]);
                else
                    totalOfPoints += plays[index] + plays[index + 1];
                
                index += 2;
            }
            
            return totalOfPoints;
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
    }
}
