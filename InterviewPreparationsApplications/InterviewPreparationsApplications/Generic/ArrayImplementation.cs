using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace InterviewPreparationsApplications.Generic
{
    public class Meeting:IComparable<Meeting>
    { 
        
        public Meeting(int starttime, int endtime)
        {
            this.StartTime = starttime;
            this.EndTime = endtime;
        }
        
        public int StartTime { get; set;  }
        public int EndTime { get; set; }
        public int CompareTo(Meeting other)
        {
           return this.StartTime.CompareTo(other.StartTime);
        }        
    }
    public class ArrayImplementation
    {
        
        public int[] TwoSum(int[] nums, int target)
        {
            int[] output = new int[2];
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for (int i = 0; i < nums.Count(); i++)
            {
                int diff = target - nums[i];
                if (hash.ContainsKey(nums[i]))
                {
                    output[0] = hash[nums[i]];
                    output[1] = i + 1;
                    return output;
                }
                else
                {
                    if(!hash.ContainsKey(diff))
                     hash.Add(diff, i);
                }
            }
            return output;
        }
/*Given a collection of numbers, return all possible permutations.
For example,
[1,2,3] have the following permutations:
[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].*/
        public IList<IList<int>> Permute(int[] nums)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            List<IList<int>> output = new List<IList<int>>();
            PermuteInt(ref nums, 0, nums.Count() - 1,ref output);
            return output;
        }
        private void PermuteInt(ref int[] nums, int l, int e, ref List<IList<int>> output)
        {
            if (l == e)
            {
                
                output.Add(nums.ToList());
            }
            for (int i = l; i <= e; i++)
            {
                SwapArr(ref nums, l, i);
                PermuteInt(ref nums, l + 1, e, ref output);
                SwapArr(ref nums, l, i);
            }
        }
        private void SwapArr(ref int[] nums, int begin, int end)
        {
            int temp = nums[begin];
            nums[begin] = nums[end];
            nums[end] = temp;
        }
        public bool IsHappy(int n)
        {
            int sum = n;
            while (sum!=1)
            {
                sum = IsHappyInt(sum);
            }
            if (sum == 1)
                return true;
            else
                return false;
        }
        private int IsHappyInt(int n) {
            int sum = 0;
        while ( n>=1)
        {
            int mod;
            if ( n>=10)
            {
                mod=(n%10);
                n=n/10;
                sum+=mod*mod;
            }
            else
            {
                mod=n;
                sum+=mod*mod;
                n = n / 10;
            }
        }
        return sum;
    }
        


        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            int len = nums.Count();
            int l = 0;
            SortedSet<int> window = new SortedSet<int>();
            if (len < 2 || k < 1) return false;
            window.Add(nums[0]);
            for (int i = 0; i < len; i++)
            {
                if (window.Count() > k)
                    window.Remove(nums[i - k]);
                var it = LowerBound(window, nums[i] - t);
                if ( window.Count()>0 && it != window.Last() && it <= nums[i] + t) 
                    return true;
                window.Add(nums[i]);
            }
            return false;
        }
        private int LowerBound(SortedSet<int> set, int num)
        {
            int output = int.MaxValue;
            foreach (int i in set)
            {
                if (i == num) return i;
                else if (i > num && i < output)
                    output = i;
                else
                    continue;
            }
            if (output == int.MaxValue) output = 0;
            return output;
        }
        public Tuple<int,int> TwoSum2(int[] numbers, int target)
        {
            Hashtable hashmap = new Hashtable();
            for (int i=0;i<numbers.Length;i++)
            {
                try
                {
                    if (!hashmap.ContainsKey(numbers[i]))
                    {
                        hashmap.Add(target - numbers[i], i);
                    }
                    else
                    {
                        return new Tuple<int, int>((int)hashmap[numbers[i]], i);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return new Tuple<int, int>(-1, -1);
                }
               
            }
            return new Tuple<int, int>(-1, -1);
        }

        //given meeting times (start,endtime) of various meetings, write a function to determine the minimum number of rooms 
        //required to accomdate the schedules.

        public int MinNumberOfRoomsForMeeting(List<Meeting> meetingtimes)
        {
            int countRoom = 1;
            if (meetingtimes == null || meetingtimes.Count == 0) return 0;
            meetingtimes.Sort();
            Stack s = new Stack();
            for (int i = 0; i < meetingtimes.Count-1; i++)
            {
                int j = i + 1;
                if (meetingtimes[j].StartTime >= meetingtimes[i].EndTime)
                    continue;
                else
                {
                    if(s.Count>0 && ((Meeting)s.Peek()).EndTime<=meetingtimes[j].StartTime)
                            s.Pop();
                    else
                    {
                        countRoom++;
                        s.Push(meetingtimes[i]);

                    }
                }
            }
            return countRoom;
        }
    
    //Given an array such that every next element differs from the previous by +/- 1. (i.e. a[i+1] = a[i] +/-1 ) 
    //Find the local max OR min in O(1) time. The interviewer mentioned one more condition that the min or max should be non-edge elements of the array 
    //Example: 1 2 3 4 5 4 3 2 1 -> Local max is 5 
    //1 2 3 4 5 -> No local max or min exists 
    //5 4 3 2 1 -> No local max or min exists
        public void FindMinMax (int [] array, ref int min, ref int max)
        {


            if (array.Length == 0)
            {
                min = int.MinValue;
                max = int.MaxValue;
            }
            else
            {
                int beginEdge = array[0];
                int endEdge = array[array.Length - 1];
                max = array[0] + (array[array.Length - 1] + array.Length - array[0]) / 2;
                min = array[0] - (array[array.Length - 1] + array.Length - array[0]) / 2;

                if (max <= endEdge || max <= beginEdge)
                {
                    max = int.MaxValue;
                }
                if (min >= endEdge || min >= beginEdge)
                {
                    min = int.MinValue;
                }
            }

          //    //hold the edges so we could check if the are max/min
              
          //    Stack s = new Stack();
          //    for (int i =1; i<array.Length-1;i++)
          //    {
          //        if (array[i]>beginEdge && array[i]>endEdge)
          //        {
          //            if (s.Count>0)
          //            {
          //                if (((int)s.Peek()) < array[i])
          //                {
          //                    s.Pop();
          //                    s.Push(array[i]);
          //                }
          //            }
          //            else 
          //            {
          //                s.Push(array[i]);
          //            }
          //        }
          //    }
          //    max=(int)s.Pop();
          //}
        }
        public bool DetectMeetingConflict (List <Meeting> meetingtimes)
        {
            if (meetingtimes.Count <= 0) return false;
            Stack s =new Stack();
            meetingtimes.Sort();
            int conflict = 1;
            bool bconflict=false;
            for (int i=1;i<meetingtimes.Count-1;i++)
            {
                int j = i + 1;
                if (meetingtimes[j].StartTime >= meetingtimes[i].EndTime)
                    continue;
                else
                {
                    if ( s.Count<=0 && ((Meeting)s.Peek()).EndTime<=meetingtimes[j].StartTime)
                    {
                        s.Pop();
                    }
                    else
                    {
                        bconflict=true;
                        conflict++;
                        s.Push(meetingtimes[i].EndTime);
                    }
                }
            }
            return bconflict;
        }
            //Implement stairs(N) that (collect the solutions in a list) prints all the ways to climb up a N-step-stairs 
            //where one can either take a single step or double step. 
            //We'll use 1 to represent a single step, and 2 to represent a double step. 
            //stairs(3) 
            //111 
            //12 
            //21
            public void PrintStairs (int N)
            {
                string path = string.Empty;
                PrintAllPaths(N, path);
            }
            public void PrintAllPaths ( int N, string path)
            {
                if ( N>=0)
                {
                    if (N>0)
                    {
                        PrintAllPaths(N - 1, path + "1");
                        PrintAllPaths(N - 2, path + "2");
                    }
                    else if (N==0)
                    {
                        Console.WriteLine(path);
                    }
                }
            }
            //Question: Given a sequence of positive integers A and an integer T, return whether there is a 
            //continuous sequence of A that sums up to exactly T 
            //Example 
            //[23, 5, 4, 7, 2, 11], 20. Return True because 7 + 2 + 11 = 20 
            //[1, 3, 5, 23, 2], 8. Return True because 3 + 5 = 8 
            //[1, 3, 5, 23, 2], 7 Return False because no sequence in this array adds up to 7
            public bool SumInASequence ( int[] arr,int sum)
            {
                int numberOfiterations = 0 ;
                int temp = 0;
                if (arr.Length <= 0) return false;
                for (int i = 0; i < arr.Length; i++ )
                {
                    temp = sum;
                    for (int j =i; j<arr.Length; j++)
                    {
                        numberOfiterations++;
                        temp -= arr[j];
                        if (temp < 0)
                            break;
                        else if (temp == 0)
                        {
                            Console.WriteLine("Number Of Iterations : {0}", numberOfiterations);
                            return true;
                        }
                    }
                }
                Console.WriteLine("Number Of Iterations : {0}", numberOfiterations);
                return false;
            }
        //solutin #2 alerternative;
        public bool SumInASequenceVer2 (int [] arr, int sum)
        {
            if (arr.Length <= 0 && sum > 0) return false;
            int wr = 0, wl = 0, tempsum = arr[0], itc = 0; ;
            while (wr<arr.Length)
            {
                if (tempsum < sum && wr < arr.Length - 1)
                {
                    tempsum += arr[++wr];
                }
                else if (sum == tempsum)
                {
                    return true;
                }
                else if (tempsum>sum)
                {
                    tempsum -= arr[wl];
                    wl++;
                }
            }
            return false;
        }

        //Given a string containing letter, digit, and other characters, write a function to check palindrome for only letter 
        //and digit. The implementation need to be in-place, no extra memory is allowed to create another string or array. 
        //For example: 
        //"ABA" is palindrome 
        //"A!#A" is palindrome 
        //"A man, a plan, a canal, Panama!" is palindrome
        public bool isItAPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;

            char[] charArr = input.ToCharArray();
            int head = 0;
            int tail = charArr.Length - 1;
            while (tail>head)
            {
               while ( !char.IsLetterOrDigit (charArr[head]) && head<tail)
                    head++;
                while (!char.IsLetterOrDigit (charArr[tail]) && head<tail)
                    tail--;
                if (charArr[head].ToString().ToLower() == charArr[tail].ToString().ToLower())
                {
                    head++;
                    tail--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public void populateHashTable(ref Hashtable h, string original, string edited, int currentCharIndex) 
        {
	    if (currentCharIndex >= original.Length) {
		    h.Add(edited, true);
		    return;
	        }
	        populateHashTable(ref h, original, edited + original[currentCharIndex], currentCharIndex + 1);
	        populateHashTable(ref h, original, edited + "*", currentCharIndex + 1);
        }

        public void Permituation (ref Hashtable ls, string word,string possible, int index)
        {
            char[] ch = word.ToCharArray();
            if ( index>=word.Length)
            {
                if(!ls.ContainsKey(possible))
                    ls.Add(possible,index);
                return;
            }
            Permituation(ref ls, word, possible + word[index], index + 1);
            foreach (char c in getNearbyChars(word[index]))
            {
                Permituation(ref ls, word, possible + c, index+1);
            }

        }
        private static List<char> getNearbyChars(char character)
        {
        List<char> characters = new List<char>();
        if (character == 'g') {
            characters.Add('g');
            characters.Add('h');
            characters.Add('f');
        } else {
            characters.Add('i');
            characters.Add('o');
            characters.Add('k');
        }
        return characters;
    }

        static bool isword(string word)
        {
            return word.Equals("go") || word.Equals("hi");
        }
       public int Alegebra(string input)
        {
            if (string.IsNullOrEmpty(input)) return int.MinValue;
            char[] chInput = input.ToCharArray();
            int result=0;
            char prevoperator=' ';
            string temp=string.Empty;
           for (int i=0;i<chInput.Length;i++)
           {
               if (chInput[i]-'0'>=0 && chInput[i]-'0'<=9)
               {
                   temp+=chInput[i];
               }
               if ( chInput[i]=='+' || chInput[i]=='*' || i==chInput.Length-1)
               {
                   if ( prevoperator==' ' )
                   {
                       prevoperator = chInput[i];
                       result = int.Parse(temp);
                       temp = string.Empty;
                   }
                   else if (prevoperator=='*')
                   {
                       result*=int.Parse(temp);
                       temp=string.Empty;
                   }
                   else if (prevoperator=='+')
                   {
                       result += int.Parse(temp);
                       temp = string.Empty;
                   }
                   prevoperator = chInput[i];
               }

           }
           return result;
        }

       public int MyAtoi(string str)
       {
           if (string.IsNullOrEmpty(str)) return 0;
           char[] chArray = str.ToCharArray();
           int i = 0;
           int startindex = int.MinValue;
           int endIndex = int.MaxValue;
           bool nsign = false;
           bool psign = false;
           int sum = 0;
           int mult = 1;
           while (chArray.Length > i)
           {
               if (chArray[i] - '0' < 0 || chArray[i] - '0' > 9)
               {
                   if (chArray[i] != '-' && chArray[i] != '+' && chArray[i] != ' ')
                   {
                       if (startindex != int.MinValue && endIndex == int.MaxValue)
                       {
                           endIndex = i;
                           break;
                       }
                       else
                           return 0;
                   }
               }
               else if (chArray[i] - '0' >= 0 && chArray[i] - '0' <= 9 && startindex == int.MinValue)
                   startindex = i;

               if (chArray[i] == '-') nsign = true;
               if (chArray[i] == '+') psign = true;
               if (nsign && psign) return 0;
               i++;// start index
           }
           if (endIndex == int.MaxValue) endIndex = i;
           for (int j = endIndex - 1; endIndex <= chArray.Length && j >= startindex; j--)
           {
               if (sum > int.MaxValue) return int.MaxValue;
               if (sum < int.MinValue) return int.MinValue;
               sum += (chArray[j] - '0') * mult;
               mult *= 10;
           }
           if (nsign)
               sum *= -1;
           return sum;
       }
       public int StringToInt(char[] number)
       {
           int sum = 0;
           int mult=1;
           for (int i =number.Length-1; i>=0;i--)
           {
               sum += (number[i]-'0') * mult;
               mult *= 10;
           }
           return sum;
       }

        public int AlgebraV1 (string input)
       {
           if (string.IsNullOrEmpty(input)) return int.MinValue;
           Stack operators = new Stack();
           Stack operand = new Stack();
           int result = 0;
           char[] chInput = input.ToCharArray();
           string temp=string.Empty;
           for (int i = 0; i < chInput.Length; i++)
           {
               if (chInput[i] - '0' >= 0 && chInput[i] - '0' <= 9)
               {
                   temp+=chInput[i];
               }
               if(chInput[i] == '+' || chInput[i] == '*'  || i==chInput.Length-1)
               {
                   
                   operand.Push(this.StringToInt(temp.ToCharArray()));

                   if (chInput.Length-1 == i) break;
                   temp = string.Empty;
                   if (operators.Count>0 && (char)operators.Peek()=='*' && chInput[i]=='+')
                   {
                       result = (int)operand.Pop() * (int)operand.Pop();
                       operators.Pop();
                       operators.Push(chInput[i]);
                       operand.Push(result);
                   }
                   else
                       operators.Push(chInput[i]);
               }
               
           }
           while ( operators.Count>0)
           {
               result = (int)operand.Pop() + (int)operand.Pop();
               operand.Push(result);
               operators.Pop();
           }
           return result;
       }
        //You are given a set of unique characters and a string. 
        //Find the smallest substring of the string containing all the characters in the set. 
        //ex: 
        //Set : [a, b, c] 
        //String : "abbcbcba" 
        //Result: "cba"
        public string SmallestSubString( string input, HashSet<char> unique)
        {
            if (string.IsNullOrEmpty(input) && unique != null) return string.Empty;
            Hashtable Ht = new Hashtable();
            //int c=0;
            int count=0;
            int tail=0, minlen=int.MaxValue;
            string result=string.Empty;
            char[] chInput = input.ToCharArray();
            for (int i =0; i<chInput.Length;i++)
            {
                if(unique.Contains(chInput[i]))
                {
                    int c = Ht.ContainsKey(chInput[i]) ? (int)Ht[chInput[i]] + 1 : 1;
                    if (c == 1) count++;
                    if (c == 1 && !Ht.ContainsKey(chInput[i]))
                        Ht.Add(chInput[i], c);
                    else
                        Ht[chInput[i]] = c;
                }
                while (count == unique.Count)
                {
                    if (unique.Contains(chInput[tail]))
                    {
                        int v = (int)Ht[chInput[tail]];
                        if (v - 1 == 0) count--;
                        Ht[chInput[tail]] = v - 1;
                    }
                    if (i - tail + 1 < minlen)
                    {
                        minlen = i - tail + 1;
                        result = input.Substring(tail, i + 1-tail);
                    }
                    tail++;
                }
            }
            return result;
        }
       
        //Given an array, find the maximum difference between two array elements given the second element comes after the first. 
        //For example. 
        //array = [1,2,3,4,5,6,7] 
        //We can take the difference between 2 and 1 (2-1), but not the different between 1 and 2 (1-2). 
        //This question is super easy, I solved it within minutes of getting of the phone. I came up with an O(n^2) solution over the phone. My improved solution was O(n).

        public int MaxDiff(int[] intarr)
        {
            int maxDiff = 0;
            int minValue = int.MinValue;
            if (intarr != null && intarr.Length < 2)
            {
                maxDiff = intarr[0];
            }
            else if (intarr.Length == 2)
            {
                
                maxDiff = intarr[1] - intarr[0];
            }
            else
            {
                maxDiff = intarr[1] - intarr[0];
                minValue = intarr[0];
                for (int i = 1; i < intarr.Length; i++)
                {
                    if (intarr[i] < minValue)
                        minValue = intarr[i];
                    if (intarr[i] - minValue > maxDiff)
                        maxDiff = intarr[i] - minValue;

                }
            }
                return maxDiff;
            
        }
    //You are at latest version of committed code.  assume one branch of code. Code version is in sorted order. 
    //It is corrupted with bug. You have fun isBug(VerNumber) which returns True or False. Find the version in which bug was introduced?
    //This can be solved with linearly checking each version or modified binary search. Person asked to write test cases? This is where i struggled. 
    //how do you write test case for this question? Do you guys use framework syntax or something else?
    
        //public int FindBuggyVersion (int[] versions)
        //{

        //}
        //public int findVersionBinary(int[] versions, int start, int end)
        //{
        //    if (start == end || end - start == 1) return versions[end];
        //    int mid = start + end / 2;

        //    if (isBug(versions[mid])) return findVersionBinary(versions, start, mid);
        //    else return findVersionBinary(versions, mid + 1, end);

        //}
        
        /// <summary>
        /// count number of islands
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int NumIslands(char[,] grid)
        {

            int count = 0;
            int cols = grid.GetUpperBound(1);
            int rows = grid.GetUpperBound(0);
            if (rows == 0 && cols == 0 && grid[0,0] == '1') return 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        if ((i == 0 || grid[i - 1, j] == '0') && (j == 0 || grid[i,j - 1] == '0'))
                            count++;
                    }
                }
            }
            return count;
        }
        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                int ch = s[i];
                if (ch == '(' || ch == '+' || ch == '-') stack.Push(ch);
                else if (ch == ')')
                {
                    int tmp = stack.Pop();
                    int oper;
                    stack.Pop();
                    if( stack.Count!=0)
                    {
                        if (stack.Pop() == '+') oper = 1; else oper = -1;
                        tmp+=tmp*oper+stack.Pop();
                        stack.Push(tmp);
                    }
                    else
                        stack.Push(tmp);
                 }
                else if (ch >= '0' && ch <= '9')
                {
                    int tmpNum = 0;
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                        tmpNum = (s[i++] - '0') + 10 * tmpNum;
                    i--;
                    stack.Push(stack.Count == 0 || stack.Peek() == '(' ? tmpNum : (stack.Pop() == '+' ? 1 : -1) * tmpNum + stack.Pop());
                }
                

            }
            return stack.Pop();
        }
        public string ShortestPalindrome(string s)
        {
            char[] a = s.ToArray();
            Array.Reverse(a);
            string r = new string(a);
            for (int i = 0; i < s.Length; i++)
                if (s.StartsWith(r.Substring(i)))
                    return r.Substring(0, i) + s;
            return s;
        }
        public void rotate(int[] nums, int k)
        {

            if (k > nums.Length)
            {
                k = k % nums.Length;
            }
            int end = nums.Length;

            nums = reverse(nums, 0, end - k - 1);
            nums = reverse(nums, end - k, end - 1);
            nums = reverse(nums, 0, end - 1);
        }

        private int[] reverse(int[] nums, int start, int end)
        {

            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++; end--;
            }
            return nums;
        }
        public int Calculate2(string expression)
        {
            var _stack = new Stack<string>();
            int len = expression.Length;
            for ( int i=0;i<len ; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '(')
                    _stack.Push(expression[i].ToString());
                else if ( expression[i]==')')
                {
                    int op1=int.Parse(_stack.Pop());
                    string op=_stack.Pop();
                    int op2 =int.Parse( _stack.Pop());
                    int temp= op=="+"? op1+op2:op1-op2;
                    
                    _stack.Push(temp.ToString());

                }
                else if (expression[i]-'0'>=0 && expression[i]-'0'<='9')
                {
                    string temp=string.Empty;
                    while (i < len && expression[i] - '0' >= 0 && expression[i] - '0' <= 9)
                        temp+=expression[i++];
                    i--;
                    int tmpNum=int.Parse(temp);
                 //  _stack.Push(_stack.Count == 0 || _stack.Peek() == "(" ? tmpNum : _stack.Pop() == "+" ? 1 : -1) * tmpNum + int.Parse(_stack.Pop()));
                }

            }
            return int.Parse(_stack.Pop());

        }



        private bool ContainsX (List<Point> pts,int x)
        {
            foreach (Point p in pts)
            {
                if (p.X == x) return true;
            }
            return false;
        }
        private bool ContainsY(List<Point> pts, int y)
        {
            foreach (Point p in pts)
            {
                if (p.Y == y) return true;
            }
            return false;
        }
        public void ApplyZero (ref int[,] input)
        {
            List<Point> pts=new List<Point>();
            int cols = input.GetUpperBound(0);
            int rows=input.GetUpperBound(1);
            for (int i=0; (i<=cols && !this.ContainsX(pts,i));i++ )
            {
                for (int j=0; (j<=rows && !this.ContainsY(pts,j));j++ )
                {
                    if (input[i,j]==0 )
                        pts.Add(new Point(i,j)); 
                }
            }
           /// for each indices in the list update corresponding rows/columns --
           foreach ( Point p in pts)
           {
                for (int a=0; a<=cols;a++)
                    input[a,p.Y]=0;
                for (int b=0; b<rows;b++)
                    input[p.X,b]=0;
          }
        }

        ///Given a positive integer, return its corresponding column title as appear in an Excel sheet.
        ///1 -> A
        //2 -> B
        //3 -> C
        //...
        //26 -> Z
        //27 -> AA
        //28 -> AB 
    
        //52->AZ
        //53->BA
        //78->BZ
        //79->CA

        public string ConvertExcelColumnToTitle(int n)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] alphArray = alphabet.ToCharArray();
            string output = string.Empty;
            while (n>0)
            {
                int rem = n % 26;

                if ( rem==0)
                {
                    output = string.Concat( "Z",output);
                    n =(n/26)-1;
                }
                else
                {
                    output = string.Concat(alphabet[rem-1],output);
                    n=n/26;
                }
            }
            return output;
        }
        public int ConvertExcelColumnTitleToNumber(string s)
        {
            char[] sArray = s.ToCharArray();
            int multi = 1;
            int sum = 0;
            if (string.IsNullOrEmpty(s)) return sum;

            for (int i=sArray.Length-1;i>=0;i--)
            {
                int rem = sArray[i] - 'A'+1;
                sum += rem * multi;
                multi *= 26;
            }
            return sum;
        }
        
       
        //Say you have an array for which the ith element is the price of a given stock on day i.
        //Design an algorithm to find the maximum profit. You may complete at most k transactions.
        //You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

        public class temp
        {
            int profit;
            int min;
            int max;

            public temp ( int profit, int min, int max)
            {
                this.profit = profit;
                this.min = min;
                this.max = max;
            }
        }
        public int MaxProfit(int k, int[] prices)
        {
            if (prices.Length <= 1) return 0;
            int maxprofit = 0 ;
            List<temp> profit = new List<temp>();
            for (int i = prices.Length - 1; i >= 0;i-- )
            {
                for (int j=0; j<=i-1;j++)
                {
                    
                    //if (maxprofit <= prices[i] - prices[j])
                     maxprofit = prices[i] - prices[j];
                     if (maxprofit > 0)
                     {
                         temp t = new temp(maxprofit, j, i);
                         profit.Add(t);
                     }
                }
                //if (profit.Count<k)
                //{
                //    profit.Add(maxprofit);
                //    maxprofit = 0;
                    
                //}
                //else
                //{
                //    for ( int m=0; m<profit.Count; m++)
                //    {
                //        if (profit[m] < maxprofit)
                //        {
                //            profit[m] = maxprofit;
                //            break;
                //        }
                //    }
                //}
            }
            //maxprofit=0;
            //foreach (int pro in profit)
            //    maxprofit+=pro;
            
            return maxprofit;
        }
        public int MaxProfitVer2(int [] prices, int k)
        {
            List<int> a = new List<int>();
            
            if (prices.Length <= 1) return 0;
            if (k > prices.Length - 1) return 0;
            int[] hold = new int[k];
            int[] release = new int[k];
            for (int i=0;i<k;i++)
            {
                hold[i] = int.MinValue;
                release[i] = 0;
            }
            foreach ( int p in prices)
            {
                for ( int j=k-1; j>=0 ; j--)
                {
                    release[j] = Math.Max(release[j], hold[j] + p);
                    hold[j] = Math.Max(hold[j], (j - 1 >= 0 ? release[j - 1] : 0) - p);
                }
            }
            return release[k - 1];

        }
        public bool isIsomorphic(String s, String t)
        {
            if (s.Length != t.Length) return false;
            if (s.Equals(t)) return true;
            char[] ch1 = s.ToCharArray();
            char[] ch2 = t.ToCharArray();
            Hashtable map = new Hashtable();
            for (int i = 0; i < s.Length; i++)
            {
                char a = ch1[i];
                char b = ch2[i];
                if (map.ContainsKey(a))
                {
                    if (map[a].Equals(b))
                        continue;
                    else
                        return false;
                }
                else
                {
                    if (!map.ContainsValue(b))
                        map.Add(a, b);
                    else return false;

                }
            }
            return true;
        }
        
        public void QuickSort ( ref int[] Arr, int sIndex, int eIndex)
        {
            int pi;
            if (Arr == null || Arr.Length <= 0) return;
            if (eIndex>sIndex)
            {
                pi = PartitionIndex(ref Arr, sIndex, eIndex);
                QuickSort(ref Arr, sIndex, pi - 1);
                QuickSort(ref Arr, pi + 1, eIndex);
            }
        
        }
        private int PartitionIndex (ref int []A,int sIndex, int eIndex)
        {
            int x = A[eIndex];
            int i = sIndex - 1;
            for ( int j=sIndex; j<eIndex ; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    Swap(ref A, i, j);
                }
            }
            Swap(ref A, i + 1, eIndex);
            return i + 1;
        }
        private void Swap(ref int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
