

namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        public static void Main(string[] args)
        {
            const string Delay = ".,:; !?";
            var ans = new HashSet<string>();
            for (var k = 1; k <= 3; k++)
            {
                var path = @"d:\" + k + ".txt";

                using (var sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var word = string.Empty;
                        foreach (var t in s)
                        {
                            if (Delay.IndexOf(t) < 0)
                            {
                                word += char.ToLower(t);
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
