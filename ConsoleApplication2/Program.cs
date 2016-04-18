namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;


    public class Program
    {
        

        public static HashSet<string> CountUniqueWord(string pathF)
        {
                var answer = new HashSet<string>();
                using (var sr = File.OpenText(pathF))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var word = string.Empty;

                        foreach (var charS in s)
                        {
                            if (char.IsLetterOrDigit(charS))
                            {
                                word += char.ToLower(charS);
                            }
                            else
                            {
                                if (word == string.Empty)
                                {
                                    continue;
                                }

                                answer.Add(word);
                                word = string.Empty;
                            }
                        }

                        if (word == string.Empty)
                        {
                            continue;
                        }

                        answer.Add(word);

                        word = string.Empty;
                    }
                }

            return answer;
        }

        public static void Main()
        {
            string[] files = { "1.txt", "2.txt", "3.txt" };
            const string Path = "../../../Data/";
            var answer = new HashSet<string>();
            for (var k = 0; k < 3; k++)
            {
                var pathF = Path + files[k];
                answer.UnionWith(CountUniqueWord(pathF));
            }

            Console.WriteLine(answer.Count);
        }
    }
}
