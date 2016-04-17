namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;


    public class Program
    {
        public static void Main()
        {
            var answer = new HashSet<string>();

            string[] files = { "1.txt", "2.txt", "3.txt" };
            string path = Environment.CurrentDirectory;
            path = path.Substring(0, path.Length - 9);

            for (var k = 0; k < 3; k++)
            {
                var pathF = path + files[k];

                using (var sr = File.OpenText(pathF))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var word = string.Empty;

                        foreach (var char_s in s)
                        {
                            if (char.IsLetterOrDigit(char_s))
                            {
                                word += char.ToLower(char_s);
                            }
                            else
                            {
                                if (word == string.Empty)
                                {
                                    continue;
                                }

                                ans.Add(word);
                                word = string.Empty;
                            }
                        }

                        if (word == string.Empty)
                        {
                            continue;
                        }

                        ans.Add(word);

                        word = string.Empty;
                    }
                }
            }

            Console.WriteLine(ans.Count);
        }
    }
}
