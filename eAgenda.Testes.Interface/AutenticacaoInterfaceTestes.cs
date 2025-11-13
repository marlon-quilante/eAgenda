using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace eAgenda.Testes.Interface
{
    [TestClass]
    [TestCategory("Testes de Interface de Autenticação")]
    public sealed class AutenticacaoInterfaceTestes
    {
        private static WebDriver webDriver;
        private string enderecoBase = "https://localhost:9001";

        [AssemblyCleanup]
        public static void LimparAmbiente()
        {
            if (webDriver == null)
                return;

            webDriver.Quit();
            webDriver.Dispose();
        }

        [TestMethod]
        public void Deve_RegistrarUsuario_ComSucesso()
        {
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "Autenticacao", "Registro"));

            webDriver.FindElement(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenha]")).SendKeys("Teste@123");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenhaConfirmada]")).SendKeys("Teste@123");

            webDriver.FindElement(By.CssSelector("button[data-se=btnConfirmar]")).Click();
        }

        [TestMethod]
        public void Deve_AutenticarUsuario_ComSucesso()
        {
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "Autenticacao", "Login"));

            webDriver.FindElement(By.CssSelector("input[data-se=inputEmail]")).SendKeys("teste@gmail.com");
            webDriver.FindElement(By.CssSelector("input[data-se=inputSenha]")).SendKeys("Teste@123");

            webDriver.FindElement(By.CssSelector("button[data-se=btnEntrar]")).Click();
        }
    }
}
