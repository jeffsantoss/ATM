using System;
using System.Linq;

namespace CaixaEletronico
{
    public class CaixaEletronico
    {
        Cedulas cedulas;

        public CaixaEletronico()
        {
            cedulas = new Cedulas(new int[] { 100, 50, 20, 10 });
        }


        public string Sacar(long valor)
        {
            if (valor <= 0)
                throw new NotaInvalidaException("Valor de saque inválido");

            var saida = "";

            foreach(var nota in this.cedulas.notas)
            {
                cedulas[nota] = valor / nota;

                var qtdNota = cedulas[nota];

                valor -= qtdNota * nota;
            }

            if(valor != 0)
                throw new NotaInvalidaException("Não contém cédulas para completar a operação");

            var cedulasAsacar = cedulas.Where(cedula => cedula.Value > 0);

            foreach (var cedula in cedulasAsacar)
                saida += cedula.Value + "x cédula(s) de R$" + cedula.Key + ",00 ";

            return saida;

        }

        public static void Main(String[] args)
        {
            var valor = Console.ReadLine();
            try
            {
                Console.WriteLine(new CaixaEletronico().Sacar(Convert.ToInt64(valor)));
            }
            catch { }

            Console.Read();
        }
        
    }
}
