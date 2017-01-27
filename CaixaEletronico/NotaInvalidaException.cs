using System;

namespace CaixaEletronico
{
    public class NotaInvalidaException : Exception
    {
        public NotaInvalidaException(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
