using System;
class SingingContest{

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int numFinalistsMale = 0;
        int numFinalistsFemale = 0;

        int numSupervisedMale = 0;
        int numSupervisedFemale = 0;

        int[] finalistsMale = new int[K];
        int[] finalistsFemale = new int[K];

        for (int i = 1; i <= N; i++)
        {
            string[] contestantInfo = Console.ReadLine().Split();
            int gender = int.Parse(contestantInfo[0]);
            int score1 = int.Parse(contestantInfo[1]);
            int score2 = int.Parse(contestantInfo[2]);

            if (score1 >= 9 || score2 >= 9)
            {
                if (score1 >= 9 && score2 >= 9 && numFinalistsMale < K && numFinalistsFemale < K)
                {
                    if (numSupervisedMale < K && numSupervisedFemale < K)
                    {
                        if (gender == 1)
                        {
                            finalistsMale[numFinalistsMale] = i;
                            numFinalistsMale++;
                            numSupervisedMale++;
                        }
                        else
                        {
                            finalistsFemale[numFinalistsFemale] = i;
                            numFinalistsFemale++;
                            numSupervisedFemale++;
                    }
                }
                else
                {
                    continue;
                }
            }
            else if (numFinalistsMale < K && score1 >= 9)
            {
                finalistsMale[numFinalistsMale] = i;
                numFinalistsMale++;
                numSupervisedMale++;
            }
            else if (numFinalistsFemale < K && score2 >= 9)
            {
                finalistsFemale[numFinalistsFemale] = i;
                numFinalistsFemale++;
                numSupervisedFemale++;
            }
            else
            {
                continue;
            }
        }
    }
    int[] allFinalists = new int[numFinalistsMale + numFinalistsFemale];
    for (int i = 0; i < numFinalistsMale; i++)
    {
        allFinalists[i] = finalistsMale[i];
    }
    for (int i = 0; i < numFinalistsFemale; i++)
    {
        allFinalists[numFinalistsMale + i] = finalistsFemale[i];
    }
    Array.Sort(allFinalists);

    for (int i = 0; i < allFinalists.Length; i++)
    {
        int finalist = allFinalists[i];
        if (Array.IndexOf(finalistsMale, finalist) != -1)
        {
            Console.WriteLine("{0} {1}", finalist, 1);
        }
        else
        {
            Console.WriteLine("{0} {1}", finalist, 2);
        }
        }
    }
}