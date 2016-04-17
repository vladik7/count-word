// невесть откуда взявшиеся пустые строки.

namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    // не использущиеся нэймеспейсы.
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        // Требования заккоментировать заголовки - единственные требования, которые можно смело игнорировать.

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>

        // Вот эти два атрибута (В квадратных скобках, это как раз атрибуты. Т.е. данные, дополнительно описывающие класс) нахрен никому не нужны.
        // Они отменяют предупрежедние об ошибках, которые уже исправлены.
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]

        // не использующийся аргумент метода.
        public static void Main(string[] args)
        {
            // вместо самопальной строки можно например использовать такой метод как char.IsLetterOrDigit().
            const string Delay = ".,:; !?";

            // Сокращения не приветствуются, если они не общепринятые. Не экономь на именах переменных
            var ans = new HashSet<string>();

            // возможность указать имена файлов добавь тогда уж. В отдельную функцию там вынеси что ли.
            for (var k = 1; k <= 3; k++)
            {
                 
                var path = @"d:\" + k + ".txt";

                // маленькие файлы можно загружать в память целиком, с помощью например File.ReadAllText. Хотя канеш построчное чтение универсальнее.
                using (var sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var word = string.Empty;

                        // Охрененно тяжело понять, что же происходит в цикле, не глядя на строки выше.
                        // Однобуквенные имена подходят там и только там, где они уместны по контексту.
                        // Например переменную t какого-нибудь уравнения можно назвать t
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

                        // вообще лишняя строка
                        word = string.Empty;
                    }
                }
            }

            Console.WriteLine(ans.Count);
        }
    }
}
