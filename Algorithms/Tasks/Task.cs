using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.DataStructures;

namespace Algorithms.Tasks
{
    /// <summary>
    /// Provides methods that solves various tasks.
    /// </summary>
    public static class Task
    {
        /// <summary>
        /// Checks whether string has unique char-s or not.
        /// </summary>
        /// <param name="str">Given string.</param>
        /// <returns></returns>
        public static bool HasUniqueCharacter(string str)
        {
            // First way to use HashSet, store there all chars from string and check length.

            //var charSet = new HashSet<char>();
            //foreach (var c in str)
            //{
            //    charSet.Add(c);
            //}

            //return charSet.Count == str.Length;

            // Second way is more interesting

            if (str.Length > 128)
            {
                return false;
            }

            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val])
                {
                    return false;
                }

                charSet[val] = true;
            }

            return true;
        }

        /// <summary>
        /// Checks if one string is permutation of second one.
        /// </summary>
        /// <param name="first">First string.</param>
        /// <param name="second">Second string.</param>
        /// <returns></returns>
        public static bool IsPermutation(string first, string second)
        {
            // First way of resolving a problem

            //if (first.Length != second.Length)
            //{
            //    return false;
            //}

            //for (int i = 1; i < first.Length; i++)
            //{
            //    if (first[i - 1] == second[first.Length - i])
            //    {
            //        continue;
            //    }

            //    return false;
            //}

            //return true;

            // Second way

            if (first.Length != second.Length)
            {
                return false;
            }

            return Sort(first).Equals(Sort(second));
        }

        private static string Sort(string str)
        {
            char[] content = str.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        /// <summary>
        /// Provides a method for urlify string.
        /// </summary>
        /// <param name="url">String that needs to be urlified.</param>
        /// <param name="length">Length of string in result</param>
        /// <returns></returns>
        public static string URLify(string url, int length)
        {
            char[] result = new char[length];

            url = url.Trim();

            char[] urlChars = url.ToCharArray();
            int pointer = 0;

            for (int i = 0; i < urlChars.Length; i++)
            {
                if (urlChars[i] != ' ')
                {
                    result[pointer] = urlChars[i];
                    pointer++;
                }
                else
                {
                    result[pointer] = '%';
                    result[pointer + 1] = '2';
                    result[pointer + 2] = '0';
                    pointer += 3;
                }
            }

            return new string(result);
        }

        /// <summary>
        /// Checks if there is one or zero edition/insertion in string.
        /// </summary>
        /// <param name="fStr">First string.</param>
        /// <param name="sStr">Second string.</param>
        /// <returns>If more than two differences, it will return false.</returns>
        public static bool OneAway(string fStr, string sStr)
        {
            if (Math.Abs(fStr.Length - sStr.Length) > 1)
            {
                return false;
            }

            if (fStr.Length == sStr.Length)
            {
                return IsOneEdit(fStr, sStr);
            }

            if (fStr.Length + 1 == sStr.Length)
            {
                return IsOneInsert(fStr, sStr);
            }

            return IsOneInsert(sStr, fStr);
        }

        private static bool IsOneEdit(string fStr, string sStr)
        {
            bool diff = false;
            for (int i = 0; i < fStr.Length; i++)
            {
                if (fStr[i] != sStr[i])
                {
                    if (diff)
                    {
                        return false;
                    }

                    diff = true;
                }
            }

            return true;
        }

        private static bool IsOneInsert(string fStr, string sStr)
        {
            int index1 = 0;
            int index2 = 0;
            while (index1 < fStr.Length && index2 < sStr.Length)
            {
                if (fStr[index1] != sStr[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }

                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }

            return true;
        }

        /// <summary>
        /// Compress string (for instance, aabbcc -> a2b2c2)
        /// </summary>
        /// <param name="str">Given string.</param>
        /// <returns>Compressed string.</returns>
        public static string Compress(string str)
        {
            StringBuilder compressed = new StringBuilder();

            int count = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(count);
                    count = 0;
                }
                
                count++;
            }

            return str.Length > compressed.Length 
                ? compressed.ToString() 
                : str;
        }

        /// <summary>
        /// Checks whether linked list has a loop.
        /// </summary>
        /// <param name="list">Given linked list.</param>
        /// <returns></returns>
        public static bool LoopDetection(System.Collections.Generic.LinkedList<int> list)
        {
            //if (list.Count <= 1)
            //{
            //    return false;
            //}

            //Stack<int> temp = new Stack<int>();

            //LinkedListNode<int> current = list.First;

            //while (current.Next != null)
            //{
            //    temp.Push(current.Value);
            //    if (temp.Contains(current.Value))
            //    {
            //        return true;
            //    }

            //    current = current.Next;
            //}

            //return false;

            // Floyd's cycle-finding algorithm

            LinkedListNode<int> slow = list.First;
            LinkedListNode<int> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks, is one binary tree is a subtree of another.
        /// </summary>
        /// <param name="tree">Tree.</param>
        /// <param name="subtree">Tree that needs to be checked for subtree.</param>
        /// <returns></returns>
        public static bool IsSubtree(BinaryTree<int, int> tree, BinaryTree<int, int> subtree)
        {
            string fullTree = tree.ToString();
            string sub = subtree.ToString();

            return fullTree.Contains(sub);
        }

        /// <summary>
        /// Provide checking strings to being palindrome.
        /// </summary>
        /// <param name="word">Given string.</param>
        /// <returns></returns>
        public static bool IsPalindrome(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return false;
            }

            for (int i = 0; i < word?.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Writes to console numbers from 1 to 100.
        /// </summary>
        public static void FizzBuzz()
        {
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        /// <summary>
        /// Checks, is it possible to write note with given letters.
        /// </summary>
        /// <param name="note">Given note.</param>
        /// <param name="letters">Given letters.</param>
        /// <returns></returns>
        public static bool CanWriteNote(string note, string letters)
        {
            note = note.Replace(" ", "");

            if (note.Length > letters.Length)
            {
                return false;
            }

            var noteDict = new Dictionary<char, int>();
            var lettersDict = new Dictionary<char, int>();

            for (int i = 0; i < note.Length; i++)
            {
                noteDict[note[i]]++;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                lettersDict[letters[i]]++;
            }

            foreach (var dict in noteDict)
            {
                if (!lettersDict.ContainsKey(dict.Key))
                {
                    return false;
                }

                if (lettersDict[dict.Key] != dict.Value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Provides realization of Sieve of Eratosthenes.
        /// </summary>
        /// <param name="upperbound">Until which element primes have to be returned.</param>
        /// <returns></returns>
        public static ICollection<int> FindPrimes(int upperbound)
        {
            ICollection<int> primes = new List<int>();
            bool[] isComposite = new bool[upperbound];
            int sqrt = (int)Math.Sqrt(upperbound);

            for (int i = 2; i < sqrt; i++)
            {
                if (!isComposite[i])
                {
                    primes.Add(i);

                    for (int j = i * i; j <= upperbound; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            }

            for (int i = sqrt; i < upperbound; i++)
            {
                if (!isComposite[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        /// <summary>
        /// Reversing a text.
        /// </summary>
        /// <param name="text">Given string.</param>
        /// <returns></returns>
        public static string Reverse(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            StringBuilder reversed = new StringBuilder();

            for (int i = text.Length - 1; i > 0; i++)
            {
                reversed.Append(text[i]);
            }

            return reversed.ToString();

            // Second way

            //char[] chars = text.ToCharArray();

            //for (int left = 0, right = text.Length - 1; left < text.Length - 1 && right > 0; left++, right--)
            //{
            //    char temp = chars[left];
            //    chars[left] = chars[right];
            //    chars[right] = temp;
            //}

            //return new string(chars);
        }

        /// <summary>
        /// Reversing a number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <returns></returns>
        public static int Reverse(int number)
        {
            if (number < 0)
            {
                number *= -1;
            }

            int reverse = 0;
            int lastDigit = 0;

            while (number >= 1)
            {
                lastDigit = number % 10;
                reverse = reverse * 10 + lastDigit;
                number /= 10;
            }

            return number < 0 ? number * -1 : number;
        }
    }
}
