using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class Gondozo
    {
        int? id;
        string nev;
        DateTime szuletesiDatum;
        public int? Id

        {
            get => id;
            set
            {
                if (id == null)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidOperationException("Az ID csak egyszer kaphat értéket!");
                }
            }
        }
        public string Nev
        {
            get => nev;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 64)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A megnevezés nem lehet üres és maximum 64 karakter lehet!");
                }
            }
        }
        public DateTime SzuletesiDatum
        {
            get => szuletesiDatum;
            set
            {
                if (value.Year < (DateTime.Now.Year - 18))
                {
                    szuletesiDatum = value;
                }
                else
                {
                    throw new ArgumentException("Gondozó csak 18 év feletti lehet!");
                }
            }
        }

        public Gondozo(string nev, DateTime szuletesiDatum)
        {
            Nev = nev;
            SzuletesiDatum = szuletesiDatum;
        }

        public Gondozo(int? id, string nev, DateTime szuletesiDatum) : this(nev, szuletesiDatum)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"{nev} - {szuletesiDatum.ToLongDateString()}";
        }
    }
}
