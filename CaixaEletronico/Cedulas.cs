using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Cedulas:Dictionary<int,long>
    {
        public int[] notas { get; set; }

        public Cedulas(int[] notas)
        {
            this.notas = notas;
        }
    }
}
