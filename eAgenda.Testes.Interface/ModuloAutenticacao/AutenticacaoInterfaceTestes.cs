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
            webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("teste@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]"))).SendKeys("MarlonQuilante@123");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenhaConfirmada]"))).SendKeys("MarlonQuilante@123");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.PageSource.Contains("Página Inicial"));
        }

        [TestMethod]
        public void Deve_AutenticarUsuario_ComSucesso()
        {
            // Arranjo
            webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("teste@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]"))).SendKeys("MarlonQuilante@123");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenhaConfirmada]"))).SendKeys("MarlonQuilante@123");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSair]"))).Click();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("teste@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]"))).SendKeys("MarlonQuilante@123");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnEntrar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.PageSource.Contains("Página Inicial"));
        }
    }
}
