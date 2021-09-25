using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Implemented Stack Class
            //SinglyLinkedList();
            ////Implemented Stack Class
            //StackInitialization();
            ////.Net Stack Class
            //StackCheck();

            ////DotNet Queue Implementation
            //DotNetQueueImplementation();

            ////My Queue Impementation
            //MyQueueCreation();

            //Binary Search Method 
            //BinarySerchMethod();

            //StringPalindrom();

            //SudukoSolution sudukoSolution = new SudukoSolution();

            //ReversNumber reversNumber = new ReversNumber();

            //NumberFactorial numberFactorial = new NumberFactorial();

            //TrappingWater trappingWater = new TrappingWater();


            SubSequenceSum subSequenceSum = new SubSequenceSum();


            Console.ReadKey();

        }

        private static void StringPalindrom()
        {
            string inputString = "javedevaj";
            var charArray = inputString.ToLower().ToCharArray();
            Dictionary<char, int> charCountDic = new Dictionary<char, int>();

            Array.ForEach(charArray, x => { 
                
                Console.Write(x);
                int count = 1;
                if (charCountDic.ContainsKey(x))
                {
                    count = charCountDic[x] + 1;
                    charCountDic[x] = count;
                }
                else
                {
                    charCountDic.Add(x, count);
                }
            });

            var noOfPalindromWords = GetPalindromCount(charCountDic);
            var palindromStrings = GetPalindromStrings(charCountDic);
            palindromStrings.ForEach(x => Console.WriteLine(x));


            Console.ReadLine();

        }

        /*  e.g Javedevaj
         *  1 --> javedevaj
         *  2 --> jaevdveaj
         *  3 --> jeavdvaej
         *  4 --> ejavdvaje
         *  5 --> eajvdvjae
         *  6 --> eavjdjvae
         *  7 --> aevjdjvea
         *  8 --> avejdjeva
         *  9 --> vaejdjeav
         *  10--> veajdjaev
         *  11 -->  
         */


        private static List<string> GetPalindromStrings(Dictionary<char, int> charCountDic)
        {
            List<string> palindroms = new List<string>();
            List<char> singleLetters = new List<char>();
            List<char> doubleLetters = new List<char>();

            singleLetters.AddRange(charCountDic.Where(x => x.Value <= 1).Select(x => x.Key));
            doubleLetters.AddRange(charCountDic.Where(x => x.Value == 2).Select(x => x.Key));
            var duobleCharslength = 0;
            while (duobleCharslength < doubleLetters.Count)
            {
                for (int i = 0; i < singleLetters.Count; i++)
                {
                    var singleLetter = singleLetters[i].ToString();
                    //for (int j = 0; j < doubleLetters.Count; j++)
                    //{
                    //    var doubleLetter = doubleLetters[j].ToString();
                    //    if (!palindroms.Contains(doubleLetters[i].ToString()))
                    //        palindroms.Add(CreateWords(singleLetter, doubleLetter));
                    //}


                    var palLength = palindroms.Count;
                    for (int k = 0; k <= palLength; k++)
                    {
                        if (palindroms.Count != 0)
                            singleLetter = palindroms[k];

                        for (int j = 0; j < doubleLetters.Count; j++)
                        {
                            var doubleLetter = doubleLetters[j].ToString();

                            if (!palindroms[k].Contains(doubleLetters[i].ToString()))
                                palindroms.Add(CreateWords(singleLetter, doubleLetter));
                        }
                    }
                    duobleCharslength++;
                }
            }
            return palindroms;

        }

        private static string CreateWords(string singleChar, string doublechar)
        {
            return $"{doublechar}{singleChar}{doublechar}";
        }

        //ABA --> ABA, AA - 1 * 2 = 2
        //AABBC --> ACA,BCB,AA,BB = 1*(2*2)
        //AABBCCD --> 

        private static int GetPalindromCount(Dictionary<char, int> charCountDic)
        {
            int wordCount = 0;
            var singleLetterCount = charCountDic.Where(x => x.Value <= 1).ToList().Count;
            var dubleLetterCount = charCountDic.Where(x => x.Value == 2).ToList().Count;
            
            wordCount = singleLetterCount * (dubleLetterCount * 2);
            
            return wordCount;
        }


        //Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
        //A palindrome is a word or phrase that is the same forwards and backwards.A permutation
        //is a rea rrangement of letters.The palindrome does not need to be limited to just dictionary words.
        //EXAMPLE
        //Input: Tact Coa
        //Output: True (permutations: "taco cat". "atco cta". etc.)


        private static void BinarySerchMethod()
        {
            int searchValue = 23;
            int[] array = new int[] { 12, 34, 45, 56, 77, 87, 23, 65, 67, 43, 41, 46, 79, 8, 21, 44 };
            Array.Sort(array);
            Console.WriteLine("Index of the value in the array is : " + Array.BinarySearch(array, 34));

            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < arrayList.Count; i++)
            {

            }

            List<int> intList = new List<int>();
            Random random = new Random(1);

            for (int i = 0; i < 25; i++)
                intList.Add(random.Next(1, 200));


            var value = BinarySearch(array, searchValue);

            Console.Write(value.ToString());

            Console.WriteLine();

            var value1 = BinarySearch(intList.ToArray(), searchValue);
            Console.Write("The search item is found at index : " + value1.ToString());
            Console.WriteLine();
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString() + " ");
            }
            Console.WriteLine();
        }

        private static int BinarySearch(int[] array, int value)
        {
            //Step 1 : 
            int p = 0; //begining of the range. 
            int r = array.Length - 1; //the end of the range 
            
            //sorting
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString() + " ");
            }
            Console.WriteLine();

            //step 2 : 
            while (p <= r)
            {
                int q = (p + r) / 2; //Finding the mid point

                if (value < array[q])
                    r = q - 1;

                else if (value > array[q])
                    p = q + 1;
                else
                    return q;

            }

            //Step 3: Nothing found
            return -1;
        }
        private static void MyQueueCreation()
        {
            Queue myQueue = new Queue(5);
            myQueue.insert(100);
            myQueue.insert(200);
            myQueue.insert(300);
            myQueue.insert(500);
            myQueue.insert(600);

            myQueue.peekFront();
            myQueue.remove();
            myQueue.View();

        }
        private static void DotNetQueueImplementation()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Item 1");
            queue.Enqueue("Item 2");
            queue.Enqueue("Item 3");
            if (!queue.Contains("Item 3"))
                queue.Enqueue("Item 3");
            queue.Enqueue("Item 4");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
        private static void StackCheck()
        {
            Stack<string> vsStack = new Stack<string>();
            

        }
        private static void StackInitialization()
        {

            Stack stack = new Stack(4);
            stack.push("Star Wars");
            stack.push("Star Wars -1");
            stack.push("Star Wars -2");
            stack.push("Star Wars -3");

            Stack<string> vs = new Stack<string>();
            vs.Push("Star Wars");
            vs.Push("Star Wars -1");
            vs.Push("Star Wars -2");
            vs.Push("Star Wars -3");


            Console.WriteLine(stack.peek());

            while (!stack.isEmpty())
            {
                Console.WriteLine(stack.pop());
            }

            while (vs.Count > 0)
            {
                Console.WriteLine(vs.Pop());
            }

        }
        private static void SinglyLinkedList()
        {
            SinglyLinkedList myList = new SinglyLinkedList();
            myList.insertFirst(1);
            myList.insertFirst(2);
            myList.insertFirst(3);
            myList.insertFirst(4);
            myList.insertFirst(5);
            myList.displayList();
            myList.deleteFirst();
            myList.displayList();
            myList.deleteFirst();
        }
    }


}
