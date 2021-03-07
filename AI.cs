using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    public class AI
    {
        public string DoAITurn(int[] UserOne, int[] AIUser, int mode, bool capture)  //main function which does all the function handling
        {
            string returnNumber = ""; //number which is returned back - the AI decision
            if (mode == 1) //if easy mode
            {
                returnNumber = EasyMode(AIUser);
            }
            else if(mode == 2) //if medium mode
            {
                returnNumber = MediumModeAI(UserOne, AIUser, capture);
            }
            else if(mode == 3) //if hard mode
            {
                returnNumber = HardMode(UserOne, AIUser, capture);
            }
            return returnNumber;
        }
        private string EasyMode(int[] AI) //easy mode basically is a random numbers
        {
            int numRand; 
            Random numRandomer = new Random(); //random instantiation
            while (true)
            {
                numRand = numRandomer.Next(1, 7); //random number between 1 and 7
                if(AI[numRand] != 0)
                {
                    break;
                }
            }
            return numRand.ToString();
        }
        private string MediumModeAI(int[] User, int[] AI, bool Capture) 
        {
            if (Capture) //if capture enabled
            {
                int weight = 0;
                int possibleMove = 0;

                for (int i = 1; i < AI.Length; i++) //tries every combination 
                {
                    int holeNum = i - AI[i];
                    if(holeNum == 0) // see if its possible to get a free turn
                    {
                        if(weight == 0)
                        {
                            weight = 1;
                            possibleMove = i;
                        }
                    }
                    else if(AI[i] == 0) //if no suitable hole found
                    {
                        continue;
                    }
                    else if(holeNum > 0 && holeNum < 8) //see if its possible to capture 
                    {
                        if(AI[holeNum] == 0) //if no shells present
                        {
                            if(User[holeNum] > weight) //if the move is greater than the current weight
                            {
                                weight = User[holeNum]; //set new weight
                                possibleMove = i;
                            }
                        }
                    }
                }
                if(weight == 0 || possibleMove == 0) //if it can't find a free turn, revert back to easy mode
                {
                    return EasyMode(AI);
                }
                else
                {
                    return possibleMove.ToString();
                }
            }
            else //if capture off
            {
                int weight = 0;
                int possibleMove = 0;
                for (int i = 1; i < AI.Length; i++) //check for free turn
                {
                    int holeNum = i - AI[i];
                    if (holeNum == 0)
                    {
                        if (weight == 0)
                        {
                            weight = 1;
                            possibleMove = i;
                        }
                    }
                }
                if (weight == 0 || possibleMove == 0) //revert to easy mode
                {
                    return EasyMode(AI);
                }
                else
                {
                    return possibleMove.ToString();
                }
            }
        }
        private string MediumModeUser(int[] User, int[] AI, bool Capture) //medium mode but a slight variation which is used for possible user move, not AI
        {
            if (Capture)
            {
                int weight = 0;
                int possibleMove = 0;

                for (int i = 1; i < User.Length; i++)
                {
                    int holeNum = i + User[i];
                    if (holeNum == 0)
                    {
                        if (weight == 0)
                        {
                            weight = 1;
                            possibleMove = i;
                        }
                    }
                    else if (User[i] == 0)
                    {
                        continue;
                    }
                    else if (holeNum > 0 && holeNum < 8)
                    {
                        if (User[holeNum] == 0)
                        {
                            if (AI[holeNum] > weight)
                            {
                                weight = AI[holeNum];
                                possibleMove = i;
                            }
                        }
                    }
                }
                if (weight == 0 || possibleMove == 0)
                {
                    return EasyMode(User);
                }
                else
                {
                    return possibleMove.ToString();
                }
            }
            else
            {
                int weight = 0;
                int possibleMove = 0;
                for (int i = 1; i < User.Length; i++)
                {
                    int holeNum = i + User[i];
                    if (holeNum == 0)
                    {
                        if (weight == 0)
                        {
                            weight = 1;
                            possibleMove = i;
                        }
                    }
                }
                if (weight == 0 || possibleMove == 0)
                {
                    return EasyMode(User);
                }
                else
                {
                    return possibleMove.ToString();
                }
            }
        }
        private string HardMode(int[] User, int[] AI, bool Capture) //hardmode
        {
            if (Capture) //if capture is on
            {
                int holeNum = int.Parse(MediumModeUser(User, AI, Capture)); //finds best user move from medium move
                int shellsOne = User[holeNum];
                int moveOne = holeNum + shellsOne; //move clockwise around board
                int weightOne;
                int possibleMove = 0;

                int currentBest = int.Parse(MediumModeAI(User, AI, Capture)); //finds best AI move from medium move
                int shellsTwo = AI[currentBest];
                int moveTwo = currentBest - shellsTwo; //move anticlockwise
                int weightTwo;
                //add actual weights
                if(moveOne > 0 && moveOne < 8) //if it falls in a hole not bank
                {
                    if (User[moveOne] == 0)
                    {
                        weightOne = AI[moveOne]; //if user can capture AI pieces, set weight to move this
                    }
                    else
                    {
                        weightOne = 0;
                    }
                }
                else
                {
                    weightOne = 0;
                }
                if(moveTwo > 0 && moveTwo < 8)
                {
                    if (AI[moveTwo] == 0)
                    {
                        weightTwo = User[moveTwo];
                    }
                    else if (moveTwo == 0) //if free turn
                    {
                        weightTwo = 100; //set weight to high value as we want a free turn
                    }
                    else
                    {
                        weightTwo = 0;
                    }
                }
                else
                {
                    weightTwo = 0;
                }

                if (weightOne > weightTwo) //if the weight of the possible user move > AI move
                {
                    possibleMove = moveOne; //set move to user move
                }
                else if(weightOne < weightTwo) //if AI move is better than user move
                {
                    possibleMove = currentBest; //set AI move to possible move
                }
                else
                {
                    possibleMove = currentBest; //if both AI and user have same weight
                }
                return possibleMove.ToString(); //return move
            }
            else //revert to medium mode if capture off
            {
                return MediumModeAI(User, AI, Capture);
            }
        }
    }
}
