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
                returnNumber = MediumMode(UserOne, AIUser, capture);
            }
            else if(mode == 3)
            {

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
        private string MediumMode(int[] User, int[] AI, bool Capture)
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
    }
}
