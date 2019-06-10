using System;
using System.Text;

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
    }
}
