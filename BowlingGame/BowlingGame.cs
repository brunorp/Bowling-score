using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class BowlingGame
    {
        private List<int> plays = new List<int>();

        private int currentPlay = 0;

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

        public int TotalScore()
        {
            if (plays.Count == 0)
                return 0;

            int total = 0;
            int index = 0;

            for(int i = 0; i < 10; i++)
            {
                if (plays[index] == 10)
                {
                    if(plays[index+2] == 10)
                        total += (10 + plays[index + 2] + plays[index + 4]);
                    else
                        total += (10 + plays[index + 2] + plays[index + 3]);
                }
                else if (plays[index] + plays[index + 1] == 10)
                    total += (10 + plays[index + 2]);
                else
                    total += plays[index] + plays[index + 1];
                
                index += 2;
            }
            
            return total;
        }
    }
}
