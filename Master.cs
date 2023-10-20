using System;

namespace Application
{
    class Master{
        public int AiIndex;
        public int Think(int Pindex){
            Random rand = new Random();
            AiIndex = rand.Next(-1,2);
            int resWin = Proc(Pindex);
            return resWin;
        }
        public int Process_Turns(int Pindex){
            int res = 0;
            /* Mechanics
            Rock = 0
            Paper = -1
            Scissors = 1
            */
            // Rock vs Scissor
            if(Pindex == 1 && AiIndex == 0){
                res = 1;
            }else if(Pindex == 0 && AiIndex == 1){
                res = 2;
            }
            // Rock vs Paper
            if(Pindex == 0 && AiIndex == -1){
                res = 1;
            }else if(Pindex == -1 && AiIndex == 0){
                res = 2;
            }
            // Paper vs Scissor
            if(Pindex == -1 && AiIndex == 1){
                res = 1;
            }else if(Pindex == 1 && AiIndex == -1){
                res = 2;
            }
            // Draw
            if(Pindex == AiIndex){res = 0;}
            // Return Results: 0 - Draw, 1 - Player, 2 - Ai
            return res;
        }
        
        // Misc
        public string Turn(int a){
            // Return this string in the Game
            string retB = "";
            switch (a){
                case -1:
                    retB = "chose Rock!";
                break;
                case 0:
                    retB = "chose Paper!";
                break;
                case 1:
                    retB = "chose Scissors!";
                break;
            }
            return retB;
        }
    }
}