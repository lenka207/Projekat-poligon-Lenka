using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_poligon_Lenka
{
    internal class vektor
    {
        public Tacka pocetak, kraj;
        public vektor()
        {

        }
        public vektor(Tacka pocetak, Tacka kraj)
        {
            this.pocetak = pocetak;
            this.kraj = kraj;
        }
        public static Tacka centriraj(vektor A)
        {
            Tacka nova = new Tacka();
            nova.x = A.kraj.x - A.pocetak.x;
            nova.y = A.kraj.y - A.pocetak.y;
            return nova;
        }
        public static double skalarni(vektor A, vektor B)
        {
            Tacka A_c = centriraj(A);
            Tacka B_c = centriraj(B);
            double skalarni = A_c.x * B_c.x + A_c.y * B_c.y;
            return skalarni;
        }
        public static double VP(vektor A, vektor B)
        {
            Tacka A_c = centriraj(A);
            Tacka B_c = centriraj(B);
            return A_c.x * B_c.y - A_c.y * B_c.x;
        }
        public static double ugao(vektor A, vektor B)
        {
            Tacka Ac = centriraj(A);
            Tacka Bc = centriraj(B);
            double ugaoA = Math.Atan2(Ac.y, Ac.x) * 180 / Math.PI;
            double ugaoB = Math.Atan2(Bc.y, Bc.x) * 180 / Math.PI;
            Console.WriteLine("ugao a={0}", ugaoA);
            Console.WriteLine("ugao b={0}", ugaoB);
            if (ugaoB - ugaoA < 0)
            {
                return ugaoB - ugaoA + 360;
            }
            return ugaoB - ugaoA;

        }
    }
}
