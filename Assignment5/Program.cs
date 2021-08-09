using System;
using System.IO;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the raw text
            string text = File.ReadAllText("Assign5.html");

            // Print raw text
            //Console.WriteLine("Raw text:");
            //Console.WriteLine(text);
            Console.WriteLine();

            // Formatted text
            bool inTag = false;
            int tagStart = -1;
            int tagEnd = -1;
            string word = " ";

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '\r':
                    case '\n':
                    case '<':
                        inTag = true;
                        tagStart = i;

                        // Print the words now
                        if (tagEnd != -1)
                        {
                            word = text.Substring(tagEnd + 1, i - (tagEnd + 1));
                            Console.WriteLine(word);
                        }
                        tagEnd = -1;

                        break;
                    case '>':
                        inTag = false;
                        tagEnd = i;

                        // Print the tag now
                        word = text.Substring(tagStart, (i + 1 - tagStart));
                        Console.WriteLine(word);

                        break;
                    default:
                        // Wasn't entirely sure what to do here
                        if (!inTag)
                        {
                            
                        }

                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
