using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CaixaEletronico.Tests
{
    [TestClass()]
    public class CaixaEletronicoTeste
    {
        CaixaEletronico caixaEletronico;

        [TestInitialize]
        public void Inicializador()
        {
            caixaEletronico = new CaixaEletronico();
        }

        [TestMethod]
        public void SaqueValido_para_200()
        {
            var saque = caixaEletronico.Sacar(200);
            Assert.AreEqual("2x cédula(s) de R$100,00 ", saque);
        }
        [TestMethod]
        public void SaqueValido_para_90()
        {
            var saque = caixaEletronico.Sacar(90);
            Assert.AreEqual("1x cédula(s) de R$50,00 2x cédula(s) de R$20,00 ", saque);
        }
        [TestMethod]
        public void SaqueValido_para_80()
        {
            var saque = caixaEletronico.Sacar(80);
            Assert.AreEqual("1x cédula(s) de R$50,00 1x cédula(s) de R$20,00 1x cédula(s) de R$10,00 ", saque);
        }

        [TestMethod]
        public void SaqueValido_para_2960()
        {
            var saque = caixaEletronico.Sacar(2960);
            Assert.AreEqual("29x cédula(s) de R$100,00 1x cédula(s) de R$50,00 1x cédula(s) de R$10,00 ", saque);
        }

        [TestMethod]
        public void SaqueValido_para_valorImenso()
        {
            var saque = caixaEletronico.Sacar(23412231411112340);
            Assert.AreEqual("234122314111123x cédula(s) de R$100,00 2x cédula(s) de R$20,00 ", saque);
        }

        [TestMethod]
        [ExpectedException(typeof(NotaInvalidaException))]
        public void SaqueInvalido_para_0()
        {
            var saque = caixaEletronico.Sacar(0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotaInvalidaException))]
        public void SaqueInvalido_para_negativo()
        {
            var saque = caixaEletronico.Sacar(-32);
        }

        [TestMethod]
        [ExpectedException(typeof(NotaInvalidaException))]
        public void SaqueInvalido_para_cedulasIndisponivel()
        {
            var saque = caixaEletronico.Sacar(131);
        }


    }

}