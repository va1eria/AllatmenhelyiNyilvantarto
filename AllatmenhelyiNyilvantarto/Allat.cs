using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    enum Szor
    {
        rövid,
        közepes,
        hosszú
    }
    enum Nem
    {
        hím,
        nőstény
    }
    abstract class Allat
    {
        string nev, chipszam, leiras;
        Szor szor;
        Nem nem;
        double suly;
        DateTime szuletesiDatum, bekerulesiDatum;
        bool ivartalanitott, macskavalTarthato, kutyavalTarthato, gyerekkelTarthato, gazdas;
        Gondozo gondozo;

        public string Nev 
        { 
            get => nev;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 64)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A megnevezés nem lehet üres es maximum 64 karakter lehet!");
                }
            }
        }
        public string Chipszam 
        { 
            get => chipszam;
            set
            {
                if (value.Length <= 16)
                {
                    chipszam = value;
                }
                else
                {
                    throw new ArgumentException("A chipszám maximum 16 karakter lehet!");
                }
            }
        }
        public string Leiras 
        { 
            get => leiras;
            set
            {
                if (value.Length <= 1000)
                {
                    leiras = value;
                }
                else
                {
                    throw new ArgumentException("A leírás maximum 1000 karakter lehet!");
                }
            }
        }
        internal Szor Szor { get => szor; set => szor = value; }
        internal Nem Nem { get => nem; private set => nem = value; }
        public double Suly { get => suly; set => suly = value; }
        public DateTime SzuletesiDatum 
        { 
            get => szuletesiDatum;
            private set
            {
                if (value <= DateTime.Now)
                {
                    szuletesiDatum = value;
                }
                else
                {
                    throw new ArgumentException("A születési dátum nem lehet a jövőben!");
                }
            }
        } 
        public DateTime BekerulesiDatum 
        { 
            get => bekerulesiDatum;
            private set
            {
                if (value <= DateTime.Now)
                {
                    bekerulesiDatum = value;
                }
                else
                {
                    throw new ArgumentException("A bekerülési dátum nem lehet a jövőben!");
                }
            }
        }
        public bool Ivartalanitott { get => ivartalanitott; set => ivartalanitott = value; }
        public bool MacskavalTarthato { get => macskavalTarthato; set => macskavalTarthato = value; }
        public bool KutyavalTarthato { get => kutyavalTarthato; set => kutyavalTarthato = value; }
        public bool GyerekkelTarthato { get => gyerekkelTarthato; set => gyerekkelTarthato = value; }
        public bool Gazdas { get => gazdas; set => gazdas = value; }
        internal Gondozo Gondozo { get => gondozo; set => gondozo = value; }

        protected Allat(string nev, string chipszam, string leiras, Szor szor, Nem nem, double suly, DateTime szuletesiDatum, DateTime bekerulesiDatum, bool ivartalanitott, bool macskavalTarthato, bool kutyavalTarthato, bool gyerekkelTarthato, bool gazdas, Gondozo gondozo)
        {
            Nev = nev;
            Chipszam = chipszam;
            Leiras = leiras;
            Szor = szor;
            Nem = nem;
            Suly = suly;
            SzuletesiDatum = szuletesiDatum;
            BekerulesiDatum = bekerulesiDatum;
            Ivartalanitott = ivartalanitott;
            MacskavalTarthato = macskavalTarthato;
            KutyavalTarthato = kutyavalTarthato;
            GyerekkelTarthato = gyerekkelTarthato;
            Gazdas = gazdas;
            Gondozo = gondozo;
        }

        public override string ToString()
        {
            return $"{nev} - bekerült: {bekerulesiDatum.ToShortDateString()}";
        }
    }
}
