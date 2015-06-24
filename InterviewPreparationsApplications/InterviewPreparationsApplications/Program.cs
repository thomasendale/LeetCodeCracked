using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparationsApplications.LinkedList;
using System.Collections;

namespace InterviewPreparationsApplications
{
    class Program
    {
        private static  string SimpleGenerateAlgo(int length)
        {
            char[] letter=new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            string result = "";
            // No special limits
            bool RepeatCharacters=false;
            for (int i = 0; i < length; i++)
            {   
                int x=new Random().Next(int.MaxValue);
                char newChar = letter[x % 26];
                if (!RepeatCharacters && result.Contains(newChar))
                {
                    do
                    {
                        newChar = letter[new Random().Next(int.MaxValue) % 26];
                    } while (result.Contains(newChar));
                }
                result += newChar;
            }
            return result;
        }
        static void Main(string[] args)
        {
           // Generic.GenericHashTable<object,object> hash = new Generic.GenericHashTable<object,object>(10);

           // hash.Add("Thomas", 34);
           // hash.Add(40, "Adana");
           // hash.Add(100.7, "Mabel");

           //var a= hash.Find(100.7);
           // var b= hash.Find(40);
           // var c= hash.Find("Thomas");


           // while (true)
           // {
           //     string samp = SimpleGenerateAlgo(20);
           //     string samp2= SimpleGenerateAlgo(10);
           //     hash.Add (samp,samp2);

           //     if ( hash.Find(samp)==samp2)
           //         continue;
           //     else
           //         break;
           // }

            

            DynamicProgramming.DynamicImplementation dy = new DynamicProgramming.DynamicImplementation();
           Generic.ArrayImplementation arr = new Generic.ArrayImplementation();
            int[]     sequence = new int[] { 1,2,4,7 };
            dy.MaxProfit(2, sequence);





            int x = 4 >> 1;

            string s = arr.ShortestPalindrome("abcd");
            
            arr.Calculate("(13+5)+9");
            
            
            //char[,] inputA2d = new char[,]  {{"10"}};// {{1,2,3},{1,4,0} ,{5,6,7},{5,0,9}};
           // arr.NumIslands(inputA2d);

            dy.longestSubstringWithoutDuplication("abebebesobela");
            dy.LengthOfIncreasingSequence(sequence);

            
            
            //  int[] arrSeq= new int[] {23,5,4,4,10,11};
            //arr.SumInASequenceVer2(arrSeq, 20);
          //  LinkedList.LinkedListImplementation lImp = new LinkedList.LinkedListImplementation();
          //  LinkedList.LinkedList head=lImp.BuildSampleList();
          //  int count = lImp.Size(head);

            //int[] perm = new int[] { 1, 2, 3 };
            //arr.Permute(perm);

          //  int[] twoSum=new int[] {230,863,916,585,981,404,316,785,88,12,70,435,384,778,887,755,740,337,86,92,325,422,815,650,920,125,277,336,221,847,168,23,677,61,400,136,874,363,394,199,863,997,794,587,124,321,212,957,764,173,314,422,927,783,930,282,306,506,44,926,691,568,68,730,933,737,531,180,414,751,28,546,60,371,493,370,527,387,43,541,13,457,328,227,652,365,430,803,59,858,538,427,583,368,375,173,809,896,370,789};

          ////  arr.TwoSum2(twoSum, 542);
          //  arr.TwoSum(twoSum, 542);

          //  arr.IsHappy(19);

           


          //  int[] dupArr = new int[] { -1, 1 };
          //  bool output = arr.ContainsNearbyAlmostDuplicate(dupArr, 1, 0);
            
          //  lImp.Push(ref head, 10);
          //  lImp.Push(ref head, 20);
          //  lImp.Push(ref head, 30);
          //  lImp.Push(ref head, 10);

          //  lImp.Print(head);

          //  lImp.PushAtTail(ref head, 50);
          //  lImp.Push(ref head, 10);
          //  count = lImp.Size(head);
          //  lImp.Print(head);

          //  arr.Push(-2);
          //  arr.Push(0);
          //  arr.Push(-1);
          //  int i = arr.GetMin();
          //  int x = arr.Top();
          //  arr.Pop();
          //  int m = arr.GetMin();


          //  arr.isIsomorphic("ab", "aa");

          //  Console.WriteLine ("Number Of Times {0} is repeated in a List is : {1} ",10,lImp.CountNumberOfOccurance(head,10) );

          //  Console.WriteLine("the number of Position {0} is {1}", 4, lImp.GetNth(head, 4));
          //  Console.WriteLine("-------------");
          //  lImp.Print(head);
          //  Console.WriteLine("-------------");
          //  Console.WriteLine("Poped element at the head is {0}", lImp.Pop(ref head));
          //  Console.WriteLine("-------------");
          //  lImp.Print(head);
          //  Console.WriteLine("Inserting Node at position {0} with value {1}", 6, 100);
          //  lImp.InsertNth(ref head, 6, 100);
          //  lImp.Print(head);

          //  Console.WriteLine("Inserting Node at position {0} with value {1}", 0, 90);
          //  lImp.InsertNth(ref head, 0, 90);
          //  lImp.Print(head);


          //  Console.WriteLine("sorting a list");
          //  lImp.Print(lImp.InsertedSort(head));

            

          //  lImp.DeleteList(ref head);

          //  Console.WriteLine("Inserting Node at position {0} with value {1}", 0, 90);
          //  lImp.InsertNth(ref head, 0, 90);
          //  lImp.Print(head);

            


          //  lImp.DeleteList(ref head);
            
            
          //  lImp.SortedInsert(ref head, 7);
          //  lImp.SortedInsert(ref head, 5);
          //  lImp.SortedInsert(ref head, 1);





          //  Console.WriteLine("printing sorted inserted list");
          //  lImp.Print(head);

          //  lImp.SortedInsert(ref head, 0);
          //  lImp.Print(head);

          //  lImp.SortedInsert(ref head, 6);
          //  lImp.Print(head);

          //  lImp.SortedInsert(ref head, 9);
          //  lImp.Print(head);
            

          //  lImp.Print(head);

          //  LinkedList.LinkedList headA = null;
          //  LinkedList.LinkedList headB = null;

          //  lImp.Append(ref headA, ref headB);

          //  lImp.Print(headA);
          //  lImp.Print(headB);
          //  lImp.SortedInsert(ref headA, 7);
          //  lImp.SortedInsert(ref headA, 5);
          //  lImp.SortedInsert(ref headA, 1);

          //  lImp.Append(ref headA, ref headB);

          //  lImp.SortedInsert(ref headB, 9);
          //  lImp.Append(ref headA, ref headB);
          //  lImp.Print(headA);
          //  lImp.Print(headB);

          //  LinkedList.LinkedList headC=null;
          //  LinkedList.LinkedList headD=null;;

          //  lImp.SortedInsert(ref headB, 9);
          //  Console.WriteLine("Front back split for even size list");
          //  lImp.FrontBackSplit(headA, ref headC, ref headD);
          //  lImp.Print(headC);
          //  lImp.Print(headD);

        
          //  Console.WriteLine("Front back split for empty list");
          //  lImp.FrontBackSplit(headB, ref headC, ref headD);
          //  lImp.Print(headC);
          //  lImp.Print(headD);


        

          //  lImp.SortedInsert(ref headA, 20);
          //  lImp.SortedInsert(ref headA, 40);
          //  lImp.Print(headA);
          //  Console.WriteLine("Front back split for odd size list");
          //  lImp.FrontBackSplit(headA, ref headC, ref headD);
          //  lImp.Print(headC);
          //  lImp.Print(headD);



          //  headC = headD = null;
          //  lImp.SortedInsert(ref headA, 3);
          //  lImp.Print(headA);
          //  lImp.FrontBackSplitVer2(headA, ref headC, ref headD);
          //  lImp.SortedInsert(ref headA, 4);
          //  lImp.SortedInsert(ref headA, 8);
          //  lImp.Print(headA);
          //  lImp.FrontBackSplitVer2(headA, ref headC, ref headD);
          //  lImp.Print(headC);
          //  lImp.Print (headD);

          //  LinkedList.LinkedList headE = null;

          //  lImp.SortedInsert(ref headE, 1);
          //  lImp.Print(headE);
          //  lImp.RemoveDuplicates(ref headE);
          //  lImp.Print(headE);


          //  lImp.SortedInsert(ref headE, 1);
          //  lImp.Print(headE);
          //  lImp.RemoveDuplicates(ref headE);
          //  lImp.Print(headE);

          // // lImp.SortedInsert(ref headE, 1);
          //  lImp.SortedInsert(ref headE, 2);
          //  //lImp.SortedInsert(ref headE, 3);
          //  //lImp.SortedInsert(ref headE, 3);
          //  //lImp.SortedInsert(ref headE, 4);
          //  //lImp.SortedInsert(ref headE, 4);

          //  lImp.Print(headE);
          //  lImp.DeleteNthNodeFromLast(ref headE, 1);
            
          //  lImp.Print(headE);
          //  lImp.RemoveDuplicates(ref headE);
          //  lImp.Print(headE);


          //  LinkedList.LinkedList headF =null;
          //  LinkedList.LinkedList headG = null; 
            
          //  lImp.MoveNode(ref headF, ref headG);

            
          //  lImp.SortedInsert(ref headF, 1);
          //  lImp.MoveNode(ref headF, ref headG);
          //  lImp.Print(headF);

          
          //  lImp.SortedInsert(ref headG, 1);
          //  lImp.MoveNode(ref headF, ref headG);
          //  lImp.Print(headF);


          //  lImp.SortedInsert(ref headF, 2);
          //  lImp.SortedInsert(ref headF, 3);
          //  lImp.SortedInsert(ref headF, 3);
          //  lImp.SortedInsert(ref headF, 4);
          //  lImp.SortedInsert(ref headF, 4);

          //  lImp.SortedInsert(ref headG, 6);
          //  lImp.SortedInsert(ref headG, 9);
          //  lImp.SortedInsert(ref headG, 9);
          //  lImp.SortedInsert(ref headG, 12);
          //  lImp.SortedInsert(ref headG, 12);
          //  lImp.Print(headF);
          //  lImp.Print(headG);

          //  lImp.MoveNode(ref headF, ref headG);
          //  lImp.Print(headF);
          //  lImp.Print(headG);


          //  LinkedList.LinkedList headH = null;
          //  LinkedList.LinkedList headI = null;
          //  LinkedList.LinkedList headJ = null;
          //  lImp.SortedInsert(ref headH, 2);
          //  lImp.SortedInsert(ref headH, 3);
          //  //lImp.SortedInsert(ref headH, 3);
          //  //lImp.SortedInsert(ref headH, 4);
          //  //lImp.SortedInsert(ref headH, 4);

          //  //lImp.SortedInsert(ref headH, 6);
          //  //lImp.SortedInsert(ref headH, 9);
          //  //lImp.SortedInsert(ref headH, 9);
          //  //lImp.SortedInsert(ref headH, 12);
          //  lImp.Print(headH);
          //  lImp.AlternateSplit(headH, ref headI, ref headJ);
            
          //  lImp.Print(headI);
          //  lImp.Print(headJ);



          //  LinkedList.LinkedList headK = null;
          //  LinkedList.LinkedList headL = null;
          //  LinkedList.LinkedList headM = null;
          //  lImp.SortedInsert(ref headK, 2);
          //  lImp.SortedInsert(ref headK, 3);
          //  lImp.SortedInsert(ref headK, 3);
          //  lImp.SortedInsert(ref headL, 4);
          //  lImp.SortedInsert(ref headL, 4);

          //  //lImp.SortedInsert(ref headH, 6);
          //  //lImp.SortedInsert(ref headH, 9);
          //  //lImp.SortedInsert(ref headH, 9);
          //  //lImp.SortedInsert(ref headH, 12);
          //  lImp.Print(headK);
          //  lImp.Print(headL);

          //  lImp.ShuffelMerge(ref headM, headK, headL);

          //  lImp.Print(headM);


          //  LinkedList.LinkedList headN = null;
          //  LinkedList.LinkedList headO = null;
          //  LinkedList.LinkedList headP = null;
          //  lImp.SortedInsert(ref headN, 2);
          //  lImp.SortedInsert(ref headN, 4);
          //  lImp.SortedInsert(ref headN, 6);
          //  lImp.SortedInsert(ref headO, 1);
          //  lImp.SortedInsert(ref headO, 3);

          //  lImp.SortedInsert(ref headN, 8);
          //  lImp.SortedInsert(ref headO, 5);
          //  //lImp.SortedInsert(ref headH, 9);
          //  //lImp.SortedInsert(ref headH, 12);
          //  lImp.Print(headN);
          //  lImp.Print(headO);

          //  lImp.SortedMerge(ref headP, headO, headN);

          //  lImp.Print(headP);



          //  BinarySearchTree.Node root = null;
          //  var bTree = new BinarySearchTree.BinarySearchTree();

          //  root=bTree.InsertDataToBST(8,root);
          //  root=bTree.InsertDataToBST(3,root);
          //  root=bTree.InsertDataToBST(10,root);
          //  root=bTree.InsertDataToBST(14,root);
          //  root = bTree.InsertDataToBST(13, root);
          //  root = bTree.InsertDataToBST(1, root);
          //  root = bTree.InsertDataToBST(6, root);
          //  root = bTree.InsertDataToBST(4, root);
          //  root = bTree.InsertDataToBST(7, root);


          //  int[] AdX = new int[] { 9, 37, 2, 12, 22, 10, 4 };
          //  arr.QuickSort(ref AdX, 0, AdX.Length-1);


          //  bTree.PrintTreeVerticalOrder(root);

          //  Console.WriteLine("Serialization....");
          //  bTree.InOrderTraversal(root);
          //  Console.WriteLine();
          //  List<int> serializelist=new List<int>();
          //  bTree.SerializeTree(root, ref serializelist);

            
          //  Console.WriteLine("Deserializations");
          //  root=null;
          //  root=bTree.DeSerializeFile(serializelist, 0, root);
          //  bTree.InOrderTraversal(root);

          //  bTree.PrintPaths(root);
          //  bTree.PathSum(root);

          //  root = bTree.Mirror(root);



          //  //array implementation ---- 
           
          //  int[] intArr = new int[] {230,863,916,585,981,404,316,785,88,12,70,435,384,778,887,755,740,337,86,92,325,422,815,650,920,125,277,336,221,847,168,23,677,61,400,136,874,363,394,199,863,997,794,587,124,321,212,957,764,173,314,422,927,783,930,282,306,506,44,926,691,568,68,730,933,737,531,180,414,751,28,546,60,371,493,370,527,387,43,541,13,457,328,227,652,365,430,803,59,858,538,427,583,368,375,173,809,896,370,789 };
          //  //arr.TwoSum(intArr, 45);

          //  //var t=arr.TwoSum2(intArr, 542);

          //  //Tuple<int, int> tt = t;


          //  List<Generic.Meeting> meetingTimes = new List<Generic.Meeting>();
          //  meetingTimes.Add(new Generic.Meeting(2, 5));
          //  meetingTimes.Add(new Generic.Meeting(3, 4));
          //  meetingTimes.Add(new Generic.Meeting(5, 9));
          //  meetingTimes.Add(new Generic.Meeting(2, 3));
          //  meetingTimes.Add(new Generic.Meeting(4, 8));

          //  int numberOfRooms = arr.MinNumberOfRoomsForMeeting(meetingTimes);

          //  int min = int.MinValue;
          //  int max = int.MaxValue;


          //  int[] array = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
          //  arr.FindMinMax(array,ref min, ref max);

          //  arr.PrintStairs(3);

          //  array=new int[] {23,5,4,7,2,11};

          //  arr.SumInASequence(array, 20);

          //  arr.SumInASequenceVer2(array, 20);

          //  if (arr.isItAPalindrome("A#@A"))
          //      Console.WriteLine("it's a plaindrome!!!");
          //  else
          //      Console.WriteLine("it's not a plaindrome!!!");

            Hashtable hT = new Hashtable();
            arr.populateHashTable(ref hT, "ABCD", "", 0);
            Hashtable lst=new Hashtable();
            arr.Permituation(ref lst, "gi", "", 0);

          //  arr.Alegebra(" 2*3*4*5*6+7+8+9");
            
          //  arr.AlgebraV1("3+4*2+3");


            

          //  HashSet<char> input = new HashSet<char>();
          //  input.Add('a');
          //  input.Add('b');
          //  input.Add('c');

          //  arr.SmallestSubString("abbcbcba", input);


          //  int[] intArr4 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
          //  arr.MaxDiff(intArr4);


          //  int [,] inputA2d = new int[,] {{1,2,3},{1,4,0} ,{5,6,7},{5,0,9}};

          //  arr.ApplyZero(ref inputA2d);



          //  arr.MyAtoi("   +0 123");
          //  arr.MyAtoi("  -0012a42");
          //  arr.MyAtoi("123");


            int m = 10;

            int y = 27 % 26;

          Console.WriteLine(arr.ConvertExcelColumnToTitle(28));

          //  Console.WriteLine(arr.ConvertExcelColumnToTitle(705));


          //  arr.ConvertExcelColumnTitleToNumber("AAC");


          //  //2, [1,2,4]

          //  int[] stocks = new int[] { 1, 2, 4,6};
                
          //      //arr.MaxProfit(2, stocks);
          //      int profit = arr.MaxProfitVer2(stocks,3);

          //      Console.WriteLine("Profit : {0}", profit);

          //      int [] sequence=new int[] {1,-2,3,10,-4,7,2,-5};
          //      DynamicProgramming.DynamicImplementation dy = new DynamicProgramming.DynamicImplementation();
          //      dy.MaxSumOfSubArray(sequence);

          //      dy.MaxSubSubArray(sequence);


          //      sequence = new int[] { 7, 2, 3, 1, 5, 8, 9, 6 };
          //      dy.LengthOfIncreasingSequence(sequence);

          //      dy.getEditDistance("saturday", "sunday");

          //      dy.longestSubstringWithoutDuplication("aaabbbccc");
        }
    }
}


