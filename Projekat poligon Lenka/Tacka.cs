using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_poligon_Lenka
{

        public class Tacka
        {
            public double x, y;
            public Tacka(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public Tacka() { }

            public double get_r()
            {
                double r = Math.Sqrt(x * x + y * y);
                return r;
            }

        }
}
