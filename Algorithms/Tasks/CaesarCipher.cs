using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Tasks
{
    /// <summary>
    /// Provide methods for text encryption that consists from uppercase letters.
    /// </summary>
    public class CaesarCipher
    {
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly IDictionary<char, string> _encryptionDict;
        private readonly IDictionary<char, string> _decryptionDict;

        public CaesarCipher()
        {
            _encryptionDict = CreateEncryptionDictionary();
            _decryptionDict = CreateDecryptionDictionary();
        }

        /// <summary>
        /// Encryption of string by Caesar Cipher.
        /// </summary>
        /// <param name="text">Text that needs to be encrypted.</param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            text = text.ToUpper();
            if (!string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            StringBuilder encryptedText = new StringBuilder();

            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    encryptedText.Append(' ');
                }
                else
                {
                    encryptedText.Append(_encryptionDict[letter]);
                }
            }

            return encryptedText.ToString();
        }

        /// <summary>
        /// Encryption of string by Caesar Cipher in more elegant way.
        /// </summary>
        /// <param name="text">Text that needs to be encrypted.</param>
        /// <param name="n">Shift.</param>
        /// <returns></returns>
        public string AdvancedEncryption(string text, int n)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    encryptedText.Append(letter);
                }
                else
                {
                    int x = _alphabet.IndexOf(letter);
                    int value = (x + n) % 26;
                    encryptedText.Append(_alphabet[value]);
                }
            }

            return encryptedText.ToString();
        }

        /// <summary>
        /// Decryption of string by Caesar Cipher.
        /// </summary>
        /// <param name="text">Text that needs to be decrypted.</param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            text = text.ToUpper();
            if (!string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            StringBuilder decryptedText = new StringBuilder();

            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    decryptedText.Append(' ');
                }
                else
                {
                    decryptedText.Append(_decryptionDict[letter]);
                }
            }

            return decryptedText.ToString();
        }

        /// <summary>
        /// Decryption of string by Caesar Cipher in more elegant way.
        /// </summary>
        /// <param name="text">Text that needs to be decrypted.</param>
        /// <param name="n">Shift.</param>
        /// <returns></returns>
        public string AdvancedDecryption(string text, int n)
        {
            StringBuilder decryptedText = new StringBuilder();

            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    decryptedText.Append(letter);
                }
                else
                {
                    int x = _alphabet.IndexOf(letter);
                    int value = (x - n) % 26;

                    if (value < 0)
                    {
                        value += _alphabet.Length;
                    }

                    decryptedText.Append(_alphabet[value]);
                }
            }

            return decryptedText.ToString();
        }

        private IDictionary<char, string> CreateEncryptionDictionary()
        {
            return new Dictionary<char, string>
            {
                ['A'] = "X",
                ['B'] = "Y",
                ['C'] = "Z",
                ['D'] = "A",
                ['E'] = "B",
                ['F'] = "C",
                ['G'] = "D",
                ['H'] = "E",
                ['I'] = "F",
                ['J'] = "G",
                ['K'] = "H",
                ['L'] = "I",
                ['M'] = "J",
                ['N'] = "K",
                ['O'] = "L",
                ['P'] = "M",
                ['Q'] = "N",
                ['R'] = "O",
                ['S'] = "P",
                ['T'] = "Q",
                ['U'] = "R",
                ['V'] = "S",
                ['W'] = "T",
                ['X'] = "U",
                ['Y'] = "V",
                ['Z'] = "W"
            };
        }

        private IDictionary<char, string> CreateDecryptionDictionary()
        {
            return new Dictionary<char, string>
            {
                ['X'] = "A",
                ['Y'] = "B",
                ['Z'] = "C",
                ['A'] = "D",
                ['B'] = "E",
                ['C'] = "F",
                ['D'] = "G",
                ['E'] = "H",
                ['F'] = "I",
                ['G'] = "J",
                ['H'] = "K",
                ['I'] = "L",
                ['J'] = "M",
                ['K'] = "N",
                ['L'] = "O",
                ['M'] = "P",
                ['N'] = "Q",
                ['O'] = "R",
                ['P'] = "S",
                ['Q'] = "T",
                ['R'] = "U",
                ['S'] = "V",
                ['T'] = "W",
                ['U'] = "X",
                ['V'] = "Y",
                ['W'] = "Z",
            };
        }
    }
}
