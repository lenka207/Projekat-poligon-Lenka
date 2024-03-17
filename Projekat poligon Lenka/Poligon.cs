using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_poligon_Lenka
{
    internal class poligon
    {
        public int broj_temena;
        public Tacka[] teme;
        public poligon()
        {
            teme = new Tacka[broj_temena];
        }
        public poligon(int n)
        {
            broj_temena = n;
            teme = new Tacka[broj_temena];
        }

        public poligon(Tacka[] temena)
        {
            broj_temena = temena.Length;


            for (int i = 0; i < broj_temena; i++)
            {
                teme[i] = temena[i];
            }
        }
        public Boolean konveksan()
        {
            int plusevi = 0;
            for (int i = 0; i < teme.Length; i++)
            {
                vektor prvi = new vektor(teme[i], teme[(i + 1) % broj_temena]);
                vektor drugi = new vektor(teme[(i + 1) % broj_temena], teme[(i + 2) % broj_temena]);
                if (vektor.VP(prvi, drugi) > 0) plusevi++;
            }
            if ((plusevi == 0) || plusevi == broj_temena) return true;
            else return false;
        }
        public bool Prost()
        {
            for (int i = 0; i < broj_temena; i++)
            {
                vektor trenutni = new vektor(teme[i], teme[(i + 1) % broj_temena]);

                for (int j = i + 2; j < broj_temena; j++)
                {
                    vektor drugi = new vektor(teme[j], teme[(j + 1) % broj_temena]);
                    if (Presek(trenutni, drugi))
                        return false;
                }
            }

            return true;
        }

        private bool Presek(vektor vektor1, vektor vektor2)
        {
            double vp1 = vektor.VP(vektor1, new vektor(vektor1.pocetak, vektor2.pocetak));
            double vp2 = vektor.VP(vektor1, new vektor(vektor1.pocetak, vektor2.kraj));

            double vp3 = vektor.VP(vektor2, new vektor(vektor2.pocetak, vektor1.pocetak));
            double vp4 = vektor.VP(vektor2, new vektor(vektor2.pocetak, vektor1.kraj));

            return (vp1 * vp2 < 0) && (vp3 * vp4 < 0);
        }


        public double Obim()
        {
            double obim = 0;
            for (int i = 0; i < broj_temena; i++)
            {
                int sledeciIndeks = (i + 1) % broj_temena;
                obim += DužinaStranice(teme[i], teme[sledeciIndeks]);
            }
            return obim;
        }
        public static int Orijentacija(Tacka p, Tacka q, Tacka r)
        {
            double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
            if (val == 0)
                return 0;
            return (val > 0) ? 1 : 2; 
        }
        public static Tacka[] KonveksniOmotac(poligon poligon)
        {

            Array.Sort(poligon.teme, (a, b) => a.x.CompareTo(b.x));
            Stack<Tacka> gornjiDeo = new Stack<Tacka>();
            foreach (Tacka t in poligon.teme)
            {
                while (gornjiDeo.Count >= 2 && Orijentacija(gornjiDeo.ElementAt(1), gornjiDeo.Peek(), t) != 2)
                    gornjiDeo.Pop();
                gornjiDeo.Push(t);
            }

            Stack<Tacka> donjiDeo = new Stack<Tacka>();
            foreach (Tacka t in poligon.teme.Reverse())
            {
                while (donjiDeo.Count >= 2 && Orijentacija(donjiDeo.ElementAt(1), donjiDeo.Peek(), t) != 2)
                    donjiDeo.Pop();
                donjiDeo.Push(t);
            }

            Tacka[] konveksniOmotac = new Tacka[gornjiDeo.Count + donjiDeo.Count - 2];
            gornjiDeo.Pop();
            donjiDeo.Pop();
            gornjiDeo.CopyTo(konveksniOmotac, 0);
            donjiDeo.CopyTo(konveksniOmotac, gornjiDeo.Count);
            return konveksniOmotac;
        }

        private double DužinaStranice(Tacka tacka1, Tacka tacka2)
        {
            return Math.Sqrt(Math.Pow(tacka2.x - tacka1.x, 2) + Math.Pow(tacka2.y - tacka1.y, 2));
        }

        public double Povrsina()
        {
            double povrsina = 0;
            Tacka centar = CentarPoligona();

            for (int i = 0; i < broj_temena; i++)
            {
                int sledeciIndeks = (i + 1) % broj_temena;
                Tacka trenutna = teme[i];
                Tacka sledeca = teme[sledeciIndeks];

                povrsina += PovrsinaTrougla(trenutna, sledeca, centar);
            }

            return Math.Abs(povrsina);
        }

        private Tacka CentarPoligona()
        {
            double xSum = 0, ySum = 0;
            foreach (Tacka t in teme)
            {
                xSum += t.x;
                ySum += t.y;
            }
            double xCentar = xSum / broj_temena;
            double yCentar = ySum / broj_temena;
            return new Tacka(xCentar, yCentar);
        }

        private double PovrsinaTrougla(Tacka a, Tacka b, Tacka c)
        {
            double s = (DužinaStranice(a, b) + DužinaStranice(b, c) + DužinaStranice(c, a)) / 2;
            return Math.Sqrt(s * (s - DužinaStranice(a, b)) * (s - DužinaStranice(b, c)) * (s - DužinaStranice(c, a)));
        }

        public void Ispisi()
        {
            Console.WriteLine($"Broj temena: {broj_temena}");

            for (int i = 0; i < broj_temena; i++)
            {
                Console.WriteLine($"Teme {i + 1}: ({teme[i].x}, {teme[i].y})");
            }
        }
    }
}
