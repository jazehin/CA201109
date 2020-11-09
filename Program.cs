using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA201109
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            //F15(Beker());
            //F16(Beker());
            //F17(Beker(), Beker());
            //F18();
            //F20(Beker());
            //F22(Beker());
            //---
            //F23(Beker());
            //F19();
            //F21();
            //F24(Beker());
            Console.ReadKey();
        }

        private static void F24(string szoveg)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine(szoveg);
            int[] p = new int[szoveg.Length];
            for (int i = 0; i < p.Length; i++) { p[i] = 0; }
            do
            {
                int i;
                do
                {
                    i = rnd.Next(szoveg.Length);
                } while (!(p[i] < Console.WindowHeight - 1));
                Console.SetCursorPosition(i, p[i]);
                Console.Write(" ");
                p[i]++;
                Console.SetCursorPosition(i, p[i]);
                Console.Write(szoveg[i]);
                Thread.Sleep(rnd.Next(11) * 5);
            } while (p.Sum() < p.Length*(Console.WindowHeight-1));
        }

        private static void F21()
        {
            Console.CursorVisible = false;
            var szavak = new string[]{ "lyuk", "joghurt", "akadály", "bólya", "fúj", "bújik", "folyó", "hely", "súly", "papagáj", "lakáj" };
            int pontok = 0;
            szavak = RandomSort(szavak);
            for (int i = 0; i < szavak.Length; i++)
            {
                Console.WriteLine($"A(z) {i+1}. szó: {szavak[i].Replace("j", "_").Replace("ly", "_")}");
                Console.WriteLine("Nyomd meg az 1-et ha j, vagy a 2-t ha ly");
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                } while (key.KeyChar != '1' && key.KeyChar != '2');
                string valasz = key.KeyChar == '1' ? "j" : "ly";
                if(szavak[i].Contains(valasz))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Helyes");
                    pontok++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hibás");
                }
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"EREDMÉNY: {pontok}/{szavak.Length} - {(double)pontok/szavak.Length*100}%");
        }

        private static string[] RandomSort(string[] szavak)
        {
            for (int i = 0; i < szavak.Length; i++)
            {
                int rndIndex;
                do
                {
                    rndIndex = rnd.Next(szavak.Length);
                } while (rndIndex == i);
                string temp = szavak[i];
                szavak[i] = szavak[rndIndex];
                szavak[rndIndex] = temp;
            }
            return szavak;
        }

        private static void F19()
        {
            //Kérjük be a felhasználó vezeték- és keresztnevét, majd ajánljunk felhasználónevet a következő szabályok szerint:
            Console.Write("Vezetéknév: ");
            string vnev = Console.ReadLine();
            Console.Write("Keresztnév: ");
            string knev = Console.ReadLine();
            //a. a vezetéknév első két betűje + a keresztnév első két betűje
            Console.WriteLine($"{vnev.Substring(0, 2) + knev.Substring(0, 2)}");
            //b. a vezetéknév első két betűje + a keresztnév utolsó két betűje
            Console.WriteLine($"{vnev.Substring(0, 2) + knev.Substring(knev.Length-2)}");
            //c. a vezetéknév első 3 betűje + egy véletlenszerűen választott háromjegyű szám
            Console.WriteLine($"{vnev.Substring(0, 2) + rnd.Next(100, 1000)}");
        }

        private static void F23(string szo)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < szo.Length; i++)
            {
                Console.Clear();
                Thread.Sleep(100);
                Console.Write(szo[i]);
                Thread.Sleep(500);
            }
            Console.CursorVisible = true;
        }

        private static void F22(string szoveg)
        {
            var dic = new Dictionary<char, int>();

            foreach (var c in szoveg)
            {
                if (!dic.ContainsKey(c)) dic.Add(c, 1);
                else dic[c]++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} db");
            }

        }

        private static void F20(string isz)
        {
            Console.WriteLine($"az az isz a {isz.Substring(1, 2)} kerülete");
        }

        private static void F18()
        {
            var karakterek = "abcdefgh1234567890_";
            string jelszo = "";
            for (int i = 0; i < 8; i++)
            {
                jelszo += karakterek[rnd.Next(0, karakterek.Length)];
            }
            Console.WriteLine(jelszo);
        }

        private static void F17(string elso, string masodik)
        {
            var ujElso = elso.ToLower().ToCharArray();
            var ujMasodik = masodik.ToLower().ToCharArray();
            Array.Sort(ujElso);
            Array.Sort(ujMasodik);
            Console.WriteLine(new string(ujElso) == new string(ujMasodik) ? "anagramma" : "nem anagramma");
                
        }

        private static void F16(string szoveg)
        {
            var ct = szoveg.ToLower().ToCharArray();
            Array.Sort(ct);
            Console.WriteLine(new string(ct));
        }

        private static string Beker()
        {
            Console.Write("Írjon be egy szöveget: ");
            return Console.ReadLine();
        }

        private static void F15(string szoveg)
        {
            Console.WriteLine(szoveg.Replace(' ', '\n'));
        }
    }
}
