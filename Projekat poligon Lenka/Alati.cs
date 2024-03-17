using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_poligon_Lenka
{
    internal class Alati
    {
        public static poligon Unesi()
        {
            Console.Write("Unesite broj temena: ");
            int brojTemena = int.Parse(Console.ReadLine());

            poligon noviPoligon = new poligon(brojTemena);

            for (int i = 0; i < brojTemena; i++)
            {
                Console.WriteLine($"Unesite koordinate temena {i + 1}:");

                Console.Write("x = ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("y = ");
                double y = double.Parse(Console.ReadLine());

                noviPoligon.teme[i] = new Tacka(x, y);
            }

            return noviPoligon;
        }

        public static void Snimi(poligon poligon, string Datoteka)
        {
            using (StreamWriter datoteka = new StreamWriter(Datoteka))
            {
                datoteka.WriteLine(poligon.broj_temena);

                for (int i = 0; i < poligon.broj_temena; i++)
                {
                    datoteka.WriteLine($"{poligon.teme[i].x} {poligon.teme[i].y}");
                }
            }

        }

        public static void Ucitaj(poligon poligon, string Datoteka)
        {
            try
            {
                using (StreamReader datoteka = new StreamReader(Datoteka))
                {
                    poligon.broj_temena = Convert.ToInt32(datoteka.ReadLine());
                    poligon.teme = new Tacka[poligon.broj_temena];

                    for (int i = 0; i < poligon.broj_temena; i++)
                    {
                        string red = datoteka.ReadLine();
                        string[] podaci = red.Split();

                        double x, y;

                        if (podaci.Length >= 2 && double.TryParse(podaci[0], out x) && double.TryParse(podaci[1], out y))
                        {
                            poligon.teme[i] = new Tacka(x, y);
                        }
                        else
                        {
                            Console.WriteLine($"Greska pri konverziji: {red}");
                        }
                    }
                }

                Console.WriteLine($"Poligon je uspešno učitan iz datoteke {Datoteka}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greska prilikom citanja fajla: {ex.Message}");
            }
        }
        
        public static bool Unutra(poligon poligon, Tacka p)
        {
            bool unutra = false;
            int brojTemena = poligon.broj_temena;

            for (int i = 0; i < brojTemena; i++)
            {
                if (poligon.teme[i].x == p.x && poligon.teme[i].y == p.y)
                {
                    return true;
                }
            }
            for (int i = 0, j = brojTemena - 1; i < brojTemena; j = i++)
            {
                if ((poligon.teme[i].y > p.y) != (poligon.teme[j].y > p.y) &&
                    p.x < (poligon.teme[j].x - poligon.teme[i].x) * (p.y - poligon.teme[i].y) / (poligon.teme[j].y - poligon.teme[i].y) + poligon.teme[i].x)
                {
                    unutra = !unutra;
                }
            }

            return unutra;
        }
    }
}
