using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_poligon_Lenka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            poligon poligon = null;
            bool stop = true;

            while (stop)
            {
                Console.WriteLine("\nIzaberite jednu od opcija:");
                Console.WriteLine("1. Unos poligona" );
                Console.WriteLine("2. Snimi");
                Console.WriteLine("3. Ucitaj");
                Console.WriteLine("4. Provera da li je poligon prost");
                Console.WriteLine("5. Provera da li je poligon konveksan");
                Console.WriteLine("6. Izracunavanje obima poligona");
                Console.WriteLine("7. Izracunavanje povrsine poligona");
                Console.WriteLine("8. Izracunavanje konveksnog omotaca");
                Console.WriteLine("9. Provera da li je tacka unutar poligona");
                Console.WriteLine("0. Izlaz\n");

                string opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "0":
                        Console.WriteLine("Hvala na koriscenju mog programa :)");
                        Console.ReadKey();
                        stop = false;
                        break;

                    case "1":
                        poligon = Alati.Unesi();
                        break;

                    case "2":
                        if (poligon != null)
                        {
                            Alati.Snimi(poligon, @"W:\programiranje\Poligon.txt");
                            Console.WriteLine("Poligon je snimljen");
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;

                    case "3":
                        poligon = new poligon();
                        Alati.Ucitaj(poligon, @"W:\programiranje\Poligon.txt");
                        break;

                    case "4":
                        if (poligon != null)
                        {
                            Console.WriteLine(poligon.Prost());
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;

                    case "5":
                        if (poligon != null)
                        {
                            Console.WriteLine(poligon.konveksan());
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;

                    case "6":
                        if (poligon != null)
                        {
                            Console.WriteLine(poligon.Obim());
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;

                    case "7":
                        if (poligon != null)
                        {
                            Console.WriteLine(poligon.Povrsina());
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;

                    case "8":
                        if (poligon != null)
                        {
                            Tacka[] konveksniOmotac = poligon.KonveksniOmotac(poligon);
                            Console.WriteLine("Konveksni omotač:");
                            foreach (Tacka t in konveksniOmotac)
                            {
                                Console.WriteLine($"({t.x}, {t.y})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Molimo unesite poligon");
                        }
                        break;


                    case "9":
                        if (poligon != null)
                        {
                            Tacka tacka = new Tacka();
                            Console.Write("Unesite x koordinatu tacke: ");
                            tacka.x = double.Parse(Console.ReadLine());
                            Console.Write("Unesite y koordinaty tacke: ");
                            tacka.y = double.Parse(Console.ReadLine());
                            Console.WriteLine(Alati.Unutra(poligon, tacka));
                        }
                        else
                        {
                            Console.WriteLine("Greska: Poligon nije unet.");
                        }
                        break;

                    default:
                        Console.WriteLine("Nepoznata opcija");
                        break;
                }
            }
        }
    }
}
