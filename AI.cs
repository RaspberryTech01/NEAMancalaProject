using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    public class AI
    {
        public AI()
        {

        }
        public string DoAITurn(int[] UserOne, int[] AIUser, int mode, bool capture)
        {
            string returnNumber = "";
            if (mode == 1)
            {
                returnNumber = EasyMode(AIUser);
            }
            else if(mode == 2)
            {
                returnNumber = MediumModeAI(UserOne, AIUser, capture);
            }
            else if(mode == 3)
            {
                returnNumber = HardMode(UserOne, AIUser, capture);
            }
            return returnNumber;
        }
        private string EasyMode(int[] AI)
        {
            int numRand;
            Random numRandomer = new Random();
            while (true)
            {
                numRand = numRandomer.Next(1, 7);
                if(AI[numRand] != 0)
                {
                    break;
                }
            }
            return numRand.ToString();
        }
        private string MediumModeAI(int[] User, int[] AI, bool Capture)
        {
            if (Capture)
            {
                int weight = 0;
                int possibleMove = 0;

                for (int i = 1; i < AI.Length; i++)
                {
                    int holeNum = i - AI[i];
                    if(holeNum == 0)
                    {
                        if(weight == 0)
                        {
                            weight = 1;
                            possibleMove = i;
                        }
                    }
                    else if(AI[i] == 0)
                    {
                        continue;
                    }
                    else if(holeNum > 0 && holeNum < 8)
                    {
                        if(AI[holeNum] == 0)
                        {
                            if(User[holeNum] > weight)
                            {
                                weight = User[holeNum];
                                possibleMove = i;
                            }
                        }
                    }
                }
                if(weight == 0 || possibleMove == 0)
                {
                    return EasyMode(AI);
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
                for (int i = 1; i < AI.Length; i++)
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
                if (weight == 0 || possibleMove == 0)
                {
                    return EasyMode(AI);
                }
                else
                {
                    return possibleMove.ToString();
                }
            }
        }
        private string MediumModeUser(int[] User, int[] AI, bool Capture)
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
        private string HardMode(int[] User, int[] AI, bool Capture)
        {
            if (Capture)
            {
                int holeNum = int.Parse(MediumModeUser(User, AI, Capture));
                int shellsOne = User[holeNum];
                int moveOne = holeNum + shellsOne;
                int weightOne;
                int possibleMove = 0;

                int currentBest = int.Parse(MediumModeAI(User, AI, Capture));
                int shellsTwo = AI[currentBest];
                int moveTwo = currentBest - shellsTwo;
                int weightTwo;
                //add actual weights
                if(moveOne > 0 && moveOne < 8)
                {
                    if (User[moveOne] == 0)
                    {
                        weightOne = AI[moveOne];
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
                    else if (moveTwo == 0)
                    {
                        weightTwo = 100;
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

                if (weightOne > weightTwo)
                {
                    possibleMove = moveOne;
                }
                else if(weightOne < weightTwo)
                {
                    possibleMove = currentBest;
                }
                else
                {
                    possibleMove = currentBest;
                }
                return possibleMove.ToString();
            }
            else
            {
                return MediumModeAI(User, AI, Capture);
            }
        }
    }
}
