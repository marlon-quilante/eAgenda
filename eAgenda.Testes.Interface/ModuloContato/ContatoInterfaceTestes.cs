using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;

namespace eAgenda.Testes.Interface.ModuloContato
{
    [TestClass]
    [TestCategory("Testes de Interface de Contato")]
    public class ContatoInterfaceTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarContato_ComSucesso()
        {
            // Arranjo
            this.RegistrarEAutenticarUsuario();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refContatos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCadastrar']"))).Click();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Marlon Q");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 99999-9999");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("marlonq@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("Softecsul Tecnologia");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Software Tester");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Quilante"));
            webDriverWait?.Until(d => d.PageSource.Contains("(49) 99999-9999"));
            webDriverWait?.Until(d => d.PageSource.Contains("marlonq@gmail.com"));
            webDriverWait?.Until(d => d.PageSource.Contains("Softecsul Tecnologia"));
            webDriverWait?.Until(d => d.PageSource.Contains("Software Tester"));
        }

        [TestMethod]
        public void Deve_EditarContato_ComSucesso()
        {
            // Arranjo
            this.RegistrarEAutenticarUsuario();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refContatos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCadastrar']"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Marlon Q");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 99999-9999");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("marlonq@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("Softecsul Tecnologia");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Software Tester");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refEditar']"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Marlon Q Editado");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 99999-1111");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("marlonqeditado@gmail.com");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("Softecsul Tecnologia Editado");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Software Tester Editado");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q Editado"));
            webDriverWait?.Until(d => d.PageSource.Contains("(49) 99999-1111"));
            webDriverWait?.Until(d => d.PageSource.Contains("marlonqeditado@gmail.com"));
            webDriverWait?.Until(d => d.PageSource.Contains("Softecsul Tecnologia Editado"));
            webDriverWait?.Until(d => d.PageSource.Contains("Software Tester Editado"));
        }

        [TestMethod]
        public void Deve_ExcluirContato_ComSucesso()
        {
            // Arranjo
            this.RegistrarEAutenticarUsuario();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refContatos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCadastrar']"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Marlon Q");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 99999-9999");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("marlonq@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("Softecsul Tecnologia");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Software Tester");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refExcluir']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Exclusão de Contato"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnExcluir]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => !d.PageSource.Contains("Marlon Q Editado"));
        }
    }
}
