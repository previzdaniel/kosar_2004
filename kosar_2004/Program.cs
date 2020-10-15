using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar_2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadionok = new Dictionary<string, int>();

        static void Feladat2()
        {
            StreamReader file = new StreamReader("eredmenyek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                string[] adat = file.ReadLine().Split(';');
                meccsek.Add(new Meccs(adat[0], adat[1], int.Parse(adat[2]),
                    int.Parse(adat[3]), adat[4], adat[5]));
            }
            file.Close();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat");
            int hazaiDB = 0;
            int vendégDB = 0;

            for (int i = 0; i < meccsek.Count; i++)
            {
                if (meccsek[i].Hazai == "Real Madrid")
                {
                    hazaiDB++;
                }
                else if (meccsek[i].Idegen == "Real Madrid")
                {
                    vendégDB++;
                }
            }

            Console.WriteLine("3. feladat: Real Madrid: Hazai: {0}, Idegen: {1}",hazaiDB, vendégDB);

            //var hazai = from m in meccsek where m.Hazai == "Real Madrid" select new { Hazai = m.Idegen};
            //int hazaidb = hazai.ToList().Count;

            //var idegen = from m in meccsek where m.Idegen == "Real Madrid" select new { idegen = m.Idegen };
            //int idegendb = hazai.ToList().Count;
        }

        static void Feladat4()
        {
            Console.Write("4. Feladat: Volt döntetlen? ");
            var dontetlen = from m in meccsek where m.HPont == m.IPont select m;
            int dontetlenDb = dontetlen.ToList().Count;
            if (dontetlenDb == 0)
            {
                Console.Write("Nem");
            }
            else
            {
                Console.Write("Igen");
            }
        }

        static void Feladat5()
        {
            var nev = from m in meccsek where m.Hazai.Contains("Barcelona") select m.Hazai;
            string csapat = nev.First();
            Console.WriteLine();
            Console.WriteLine("5. Feladat: A barcelonai csapat neve: {0}",csapat);
        }

        static void Feladat6()
        {
            Console.WriteLine("6. Feladat: ");
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (meccsek[i].Ido == "2004-11-21")
                {
                    Console.WriteLine($"\t {meccsek[i].Hazai} - {meccsek[i].Idegen} ({meccsek[i].HPont}:{meccsek[i].IPont})");
                }
            }

            //var merkozesek = from m in meccsek where m.Ido == "2004-11-21" select new { hazai = m.Hazai, idegen = m.Idegen, hazaiPont = m.HPont, idegenPont = m.IPont };
            //foreach (var n in november)
            //{
            //    Console.WriteLine();
            //}
        }

        static void Feladat7()
        {
            Console.WriteLine("7. Feladat: ");
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (!stadionok.ContainsKey(meccsek[i].Hely))
                {
                    stadionok.Add(meccsek[i].Hely, 0);
                }
            }

            for (int i = 0; i < meccsek.Count; i++)
            {
                stadionok[meccsek[i].Hely]++;
            }

            foreach (var s in stadionok)
            {
                if (s.Value > 20)
                {
                    Console.WriteLine($"\t {s.Key}: {s.Value}");
                }
            }
        }

        static void Feladat8()
        {
            StreamWriter file = new StreamWriter("meccsek.txt");
            foreach (var m in meccsek)
            {
                file.WriteLine(m.Atalakit());
            }
            file.Close();
        }

        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();

            Console.ReadKey();
        }
    }
}
