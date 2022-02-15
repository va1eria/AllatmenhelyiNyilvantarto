using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class Orokbefogado
    {
        int? id;
        string nev, lakcim, email;
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
                    throw new ArgumentException("A megnevezés nem lehet üres es maximum 64 karakter lehet!");
                }
            }
        }
        public string Lakcim
        {
            get => lakcim;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 255)
                {
                    lakcim = value;
                }
                else
                {
                    throw new ArgumentException("A lakcím nem lehet üres es maximum 255 karakter lehet!");
                }
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 64)
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Az email nem lehet üres es maximum 64 karakter lehet!");
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
                    throw new ArgumentException("Örökbefogadó csak 18 év feletti lehet!");
                }
            }
        }

        public Orokbefogado(string nev, string lakcim, string email, DateTime szuletesiDatum)
        {
            Nev = nev;
            Lakcim = lakcim;
            Email = email;
            SzuletesiDatum = szuletesiDatum;
        }

        public Orokbefogado(int? id, string nev, string lakcim, string email, DateTime szuletesiDatum) : this(nev, lakcim, email, szuletesiDatum)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"{nev} - {szuletesiDatum.ToLongDateString()}";
        }
    }
}
