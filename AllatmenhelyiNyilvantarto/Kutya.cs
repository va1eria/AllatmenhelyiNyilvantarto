using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class Kutya : Allat
    {
        bool szobatiszta, lakasbanTarthato, egyedulHagyhato;
        public bool Szobatiszta { get => szobatiszta; set => szobatiszta = value; }
        public bool LakasbanTarthato { get => lakasbanTarthato; set => lakasbanTarthato = value; }
        public bool EgyedulHagyhato { get => egyedulHagyhato; set => egyedulHagyhato = value; }

        public Kutya(string nev, string chipszam, string leiras, Szor szor, Nem nem, double suly, DateTime szuletesiDatum, DateTime bekerulesiDatum, bool ivartalanitott, bool macskavalTarthato, bool kutyavalTarthato, bool gyerekkelTarthato, bool szobatiszta, bool lakasbanTarthato, bool egyedulHagyhato, bool gazdas, Gondozo gondozo) : base(nev, chipszam, leiras, szor, nem, suly, szuletesiDatum, bekerulesiDatum, ivartalanitott, macskavalTarthato, kutyavalTarthato, gyerekkelTarthato, gazdas, gondozo)
        {
            Szobatiszta = szobatiszta;
            LakasbanTarthato = lakasbanTarthato;
            EgyedulHagyhato = egyedulHagyhato;
        }

        public override string ToString()
        {
            return "Kutya - " + base.ToString();
        }
    }
}
