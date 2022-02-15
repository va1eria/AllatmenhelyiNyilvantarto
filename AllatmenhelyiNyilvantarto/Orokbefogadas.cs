using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class Orokbefogadas
    {
        int? id;
        DateTime orokbefogadasDatuma, utoellenorzesDatuma;
        bool sikeresUtoellenorzes;

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

        public DateTime OrokbefogadasDatuma { get => orokbefogadasDatuma; set => orokbefogadasDatuma = value; }
        public DateTime UtoellenorzesDatuma { get => utoellenorzesDatuma; set => utoellenorzesDatuma = value; }
        public bool SikeresUtoellenorzes { get => sikeresUtoellenorzes; set => sikeresUtoellenorzes = value; }

        public Orokbefogadas(DateTime orokbefogadasDatuma, DateTime utoellenorzesDatuma, bool sikeresUtoellenorzes)
        {
            OrokbefogadasDatuma = orokbefogadasDatuma;
            UtoellenorzesDatuma = utoellenorzesDatuma;
            SikeresUtoellenorzes = sikeresUtoellenorzes;
        }

        public Orokbefogadas(int? id, DateTime orokbefogadasDatuma, DateTime utoellenorzesDatuma, bool sikeresUtoellenorzes) : this(orokbefogadasDatuma, utoellenorzesDatuma, sikeresUtoellenorzes)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Örökbefogadva: {orokbefogadasDatuma} - utóellenőrzés: {utoellenorzesDatuma}";
        }
    }
}
