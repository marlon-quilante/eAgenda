using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;

namespace eAgenda.Testes.Interface.ModuloAutenticacao
{
    [TestClass]
    [TestCategory("Testes de Interface de Autenticação")]
    public sealed class AutenticacaoInterfaceTestes : TestFixture
    {
        [TestMethod]
        public void Deve_RegistrarUsuario_ComSucesso()
        {
            // Arranjo
            NavegarPara("/autenticacao/registro");

            // Ação
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");
            EsperarPorElemento(By.CssSelector("input[data-se=inputSenhaConfirmada]")).SendKeys("MarlonQuilante@123");
            EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Página Inicial"));
        }

        [TestMethod]
        public void Deve_AutenticarUsuario_ComSucesso()
        {
            // Arranjo
            NavegarPara("/autenticacao/registro");

            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");
            EsperarPorElemento(By.CssSelector("input[data-se=inputSenhaConfirmada]")).SendKeys("MarlonQuilante@123");
            EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();

            EsperarPorElemento(By.CssSelector("button[data-se=btnSair]")).Click();

            // Ação
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");

            EsperarPorElemento(By.CssSelector("button[data-se=btnEntrar]")).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Página Inicial"));
        }
    }
}
