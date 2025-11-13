using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace eAgenda.Testes.Interface
{
    [TestClass]
    [TestCategory("Testes de Interface de Autenticação")]
    public sealed class AutenticacaoInterfaceTestes : TestFixture
    {
        [TestMethod]
        public void Deve_RegistrarUsuario_ComSucesso()
        {
            webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "Autenticacao", "Registro"));

            webDriver.FindElement(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenhaConfirmada]")).SendKeys("MarlonQuilante@123");

            webDriver.FindElement(By.CssSelector("button[data-se=btnConfirmar]")).Click();

            Assert.IsTrue(webDriver.PageSource.Contains("Página Inicial"));
        }

        [TestMethod]
        public void Deve_AutenticarUsuario_ComSucesso()
        {
            // Arranjo
            webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "Autenticacao", "Registro"));

            webDriver.FindElement(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenhaConfirmada]")).SendKeys("MarlonQuilante@123");

            webDriver.FindElement(By.CssSelector("button[data-se=btnConfirmar]")).Click();

            webDriver.FindElement(By.CssSelector("button[data-se=btnSair]")).Click();

            // Ação
            webDriver.FindElement(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenha]")).SendKeys("MarlonQuilante@123");

            webDriver.FindElement(By.CssSelector("button[data-se=btnEntrar]")).Click();

            // Asserção
            Assert.IsTrue(webDriver.PageSource.Contains("Página Inicial"));
        }
    }
}
