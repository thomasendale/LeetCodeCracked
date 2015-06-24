using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.DynamicProgramming
{
   public class DynamicImplementation
    {
       public DynamicImplementation() { }


// Question: A sub-array has one number of some continuous numbers. Given an integer array with positive numbers and negative numbers, 
//  get the maximum sum of all sub-arrays. Time complexity should be O(n).
//For example, in the array {1, -2, 3, 10, -4, 7, 2, -5}, its sub-array {3, 10, -4, 7, 2} has the maximum sum 18.
//Analysis: During interviews, many candidates can solve it by enumerating all of sub-arrays and calculate their sum. An array with n elements has n(n+1)/2 
//sub-arrays. It costs O(n2) time at least to calculate their sum. Usually the intuitive and forceful solution is not the most optimized one. 
//Interviewers will tell us that there are better solutions.
    
   public int MaxSumOfSubArray(int[] Sequence)
   {
       if (Sequence.Length == 0) return 0;
       else if (Sequence.Length == 1) return Sequence[0];
       
       int accumulatedSum = 0;
       int maxSum = int.MinValue;

       for (int i=0;i<Sequence.Length;i++)
       {
           accumulatedSum += Sequence[i];
           if (Sequence[i] > accumulatedSum)
               accumulatedSum = Sequence[i];
           if (accumulatedSum > maxSum)
               maxSum = accumulatedSum;
       }
       return maxSum;
   }
    public List<int> MaxSubSubArray(int[] Sequence)
   {
       List<int> subArray = new List<int>();
       if (Sequence == null || Sequence.Length == 0) return null;
       else if (Sequence.Length == 1)
       {
           subArray.Add(Sequence[0]);
           return subArray;
       }

       int accumulatedSum = 0;
       int maxSum = int.MinValue;
    
       for (int i = 0; i < Sequence.Length; i++)
       {
           accumulatedSum += Sequence[i];
           if (Sequence[i] > accumulatedSum)
           {
               accumulatedSum = Sequence[i];
               subArray = new List<int>();
           }
           if (accumulatedSum > maxSum)
           {
               maxSum = accumulatedSum;
               subArray.Add(Sequence[i]);
           }
           //if (accumulatedSum==maxSum && )
       }
       return subArray;
   }

        //No. 16 - Maximal Length of Incremental Subsequences
        //Problem: Given an unsorted array, find the max length of subsequence in which the numbers are in incremental order.
        //For example: If the input array is {7, 2, 3, 1, 5, 8, 9, 6}, a subsequence with the most numbers in incremental order is {2, 3, 5, 8, 9} and the expected output is 5.
        //Analysis: We try to get the maximum length of all increasing subsequences ending with each element in the array.
       public int LengthOfIncreasingSequence ( int[] Sequence)
        {
            if (Sequence == null || Sequence.Length == 0) return 0;
            if (Sequence.Length == 1) return 1;
            int accumulatedSequence=0;
            int[] LongestSequence = new int[Sequence.Length];
            int maxSequenceLength = int.MinValue;
            LongestSequence[0]=1;
            
               for ( int i=1; i<Sequence.Length;i++)
               {
                   accumulatedSequence = 0;
                   for ( int j=0; j<i;j++)
                   {
                       if (Sequence[j] < Sequence[i] && LongestSequence[j] > accumulatedSequence)
                           accumulatedSequence = LongestSequence[j];
                   }

                   LongestSequence[i] = accumulatedSequence + 1;
                   if (maxSequenceLength < accumulatedSequence + 1)
                       maxSequenceLength = accumulatedSequence + 1;
               }
             
             return maxSequenceLength;
        }
       
        
       //
       public int getEditDistance(string word1, string word2)
       {
           if (string.IsNullOrEmpty(word1)) return word2.Length;
           else if (string.IsNullOrEmpty(word2)) return word1.Length;
           int len1 = word1.Length;
           int len2 = word2.Length;
           
           char[] charWord1 = word1.ToCharArray();
           char[] charWord2 = word2.ToCharArray();
           int [,] minDistance=new int[len2+1,len1+1];

           for (int k=0;k<len2+1;k++)
               minDistance[k,0]=k;
           for (int l=0;l<len1+1;l++)
               minDistance[0,l]=l;


           for (int i=1;i<len2+1;i++)
           {
               for (int j=1;j<len1+1;j++)
               {
                   if (charWord1[j-1]==charWord2[i-1])
                       minDistance[i,j]=minDistance[i-1,j-1];
                   else 
                       minDistance[i,j]=this.GetMin(minDistance[i,j-1],minDistance[i-1,j], minDistance[i-1,j-1])+1;
               }
           }
           return minDistance[len2,len1];
       }
       public int GetMin (int number1, int number2, int number3)
       {
           int output = Math.Min(number1, number2);
           return Math.Min(output, number3);
       }

         //No. 44 - Dynamic Programming on Stolen Values
        //Problem: There are n houses built in a line, each of which contains some value in it. A thief is going to steal the maximal value in these houses, 
       //but he cannot steal in two adjacent houses because the owner of a stolen house will tell his two neighbors on the left and right side. What is the maximal stolen value?
        //For example, if there are four houses with values {6, 1, 2, 7}, the maximal stolen value is 13 when the first and fourth houses are stolen.
        //Analysis: A function f(i) is defined to denote the maximal stolen value from the first house to the ith house, 
       //and the value contained in the ith house is denoted as vi. 
       //When the thief reaches the ith house, he has two choices: to steal or not. 
       //Therefore, f(i) can be defined with the following equation:
        //It would be much more efficient to calculate in bottom-up order than to calculate recursively. 
       //It looks like a 1D array with size n is needed, but actually it is only necessary to cache two values 
       //for f(i-1) and f(i-2) to calculate f(i).

       public int GetMaxStolenValues ( int[] Values)
       {
           if ( Values==null || Values.Length==0) return 0;
           int length = Values.Length;
           int totalValue=0,value1=0, value2=0;

           value1=Values[0];
           if (length == 1) 
              return value1;
           value2= Math.Max(Values[0],Values[1]);
           if (length==2 ) 
                return value2; 
           for ( int i =2 ; i<length; i++)
           {
              totalValue=Math.Max(value2, value1+Values[i]);
              value1=value2;
              value2=totalValue;
           }
           return totalValue;
       }
        //No. 49 - Longest Substring without Duplication
        //Problem: Given a string, please get the length of the longest substring which does not have duplicated characters. Supposing all characters in the string are in the range from ‘a’ to ‘z’.
        //Analysis: It’s not difficult to get all substrings of a string, and to check whether a substring has duplicated characters. The only concern about this brute-force strategy is performance. A string with n characters has O(n2) substrings, and it costs O(n) time to check whether a substring has duplication. Therefore, the overall cost is O(n3).
        //We may improve the efficiency with dynamic programming. Let’s denote the length of longest substring ending with the ith character by L(i).
        //We scan the string one character after another. When the ith character is scanned, L(i-1) is already know. If the ith character has not appeared before, L(i) should be L(i-1)+1. It’s more complex when the ith character is duplicated. Firstly we get the distance between the ith character and its previous occurrence. If the distance is greater than L(i-1), the character is not in longest substring without duplication ending with the (i-1)th character, so L(i) should also be L(i-1)+1. If the distance is less than L(i-1), L(i) is the distance, and it means between the two occurrence of the ith character there are no other duplicated characters.
        //This solution can be implemented in Java as the following code:
    public int longestSubstringWithoutDuplication(string input)
    {
        if (string.IsNullOrEmpty(input)) return 0;

        char[] inputArr=input.ToCharArray();
        int curLength = 0;
        int maxLength = 0;
        int[] letter = new int[26];
        for (int i = 0; i < letter.Length; i++)
            letter[i] = -1;
        for (int j=0;j<inputArr.Count();j++)
        {
            int prevIndex = letter[inputArr[j] - 'a'];

            if (prevIndex < 0 || j - prevIndex > curLength)
                curLength++;
            else
            {
                if (curLength > maxLength)
                    maxLength = curLength;
                curLength = j - prevIndex;
            }
            letter[inputArr[j] - 'a'] = j;
        }
        if (curLength > maxLength)
            maxLength = curLength;

        return maxLength;
    }
    public int MaxProfit(int k, int[] prices) {
    int len = prices.Length;
    if (len < 2) return 0;

    int maxProfit = 0;

    //simple case where we just need to find the maximum climb in prices among all the pairs
    //since K is greater than half of the list size, the most transaction we could do is len/2 so there is no limit to bound it by K
    //0 is used in comparision to avoid -ve/losses during computation of profit.
    if (k >= len / 2)
    {
        for (int i = 1; i < len; i++)
        {
            maxProfit += Math.Max(0, prices[i] - prices[i-1]);
        }
        return maxProfit;
    }

    //Dynamic Programming case where we need to maximize our profit
    //keeps track of maximum profit so far at each index. On any index 'i' the value is max profit that we gained
    //by dealing stock that came before 'i'. After any 'm' iterations, this array holds max profit on index 'i' if we had
    //only 'i' stock values and 'm' possible deals.
    int[] maxProfitSoFar = new int[len+1]; 

    //calculates the difference between the very current and previous stock price
    int currentProfit = 0;

    //keeps track of our current balance.
    int runningProfit = 0;

    //it backs up the value of max profit after doing 'm-1' deals until index 'i' before updating it to 
    //the value of doing 'm' deals until index i.
    int prevMaxProfit = 0;

    //k iterations for k deals - after each round mapxProfitSoFar holds the max profit for 'j' possible deals
    for (int j = 0; j < 2; j++)
    {
        //resetting our balance for new iteration
        runningProfit = 0;

        //initializing with the last max profit we are going to start the next iteration with indexes after this.
        prevMaxProfit = maxProfitSoFar[j]; 

        //we don't need to start from the beginning eveytime since we would face "the simple case" (above) and the profit 
        //is already calculated. It means that number of deals is greater than the 'len'
        for (int i = j+1; i < len; i++)
        {
            //what is the immediate different of the current two prices.
            currentProfit = prices[i] - prices[i-1];
            //is it better to do this deal? or should we stick to what we did with one less deal and see what future holds!
            runningProfit = Math.Max(runningProfit + currentProfit, prevMaxProfit); 
            //backing up max value with one less deal to compare in the next round
            prevMaxProfit = maxProfitSoFar[i]; 
            //updating max profit so far by asking if we gained more profit with last deal or we didn't gain anything more
            maxProfitSoFar[i] = Math.Max(runningProfit, maxProfitSoFar[i-1]); 
        }
    }

    //well the last item in the MaxProfitSoFar after k iterations holds max profit of 'k' deals of 'len' items.
    return maxProfitSoFar[len-1];
        }
   }
}
