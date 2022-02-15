using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class Macska : Allat
    {
        bool kijaros;

        public bool Kijaros { get => kijaros; set => kijaros = value; }

        public Macska(string nev, string chipszam, string leiras, Szor szor, Nem nem, double suly, DateTime szuletesiDatum, DateTime bekerulesiDatum, bool ivartalanitott, bool macskavalTarthato, bool kutyavalTarthato, bool gyerekkelTarthato, bool kijaros, bool gazdas, Gondozo gondozo) : base(nev, chipszam, leiras, szor, nem, suly, szuletesiDatum, bekerulesiDatum, ivartalanitott, macskavalTarthato, kutyavalTarthato, gyerekkelTarthato, gazdas, gondozo)
        {
            Kijaros = kijaros;
        }

        public override string ToString()
        {
            return "Macska - " + base.ToString();
        }
    }
}
