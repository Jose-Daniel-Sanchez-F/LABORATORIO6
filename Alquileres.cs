using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO6
{
    internal class Alquileres
    {
        public string nit { get; set; }
        public string placa { get; set; }
        public DateTime fechaAlquiler { get; set; }
        public DateTime fechaDevolucion { get; set; }

        public int kilometros { get; set; }
    }
}
