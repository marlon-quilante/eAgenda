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
            RegistrarEAutenticarUsuario();

            // Ação
            CadastrarContato();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q"));
            webDriverWait?.Until(d => d.PageSource.Contains("(49) 99999-9999"));
            webDriverWait?.Until(d => d.PageSource.Contains("marlonq@gmail.com"));
            webDriverWait?.Until(d => d.PageSource.Contains("Softecsul Tecnologia"));
            webDriverWait?.Until(d => d.PageSource.Contains("Software Tester"));
        }

        [TestMethod]
        public void Deve_EditarContato_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarContato();

            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            // Ação
            EsperarPorElemento(By.CssSelector("a[data-se='refEditar']")).Click();
            webDriverWait?.Until(d => d.Title.Contains("Edição de Contato"));

            EsperarPorElemento(By.CssSelector("input[data-se=inputNome]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputNome]")).SendKeys("Marlon Q Editado");

            EsperarPorElemento(By.CssSelector("input[data-se=inputTelefone]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputTelefone]")).SendKeys("(49) 99999-1111");

            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).SendKeys("marlonqeditado@gmail.com");

            EsperarPorElemento(By.CssSelector("input[data-se=inputEmpresa]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmpresa]")).SendKeys("Softecsul Tecnologia Editado");

            EsperarPorElemento(By.CssSelector("input[data-se=inputCargo]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputCargo]")).SendKeys("Software Tester Editado");

            EsperarPorElemento(By.CssSelector("button[data-se=btnSalvar]")).Click();

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
            RegistrarEAutenticarUsuario();

            CadastrarContato();

            webDriverWait?.Until(d => d.Title.Contains("Contatos"));

            // Ação
            EsperarPorElemento(By.CssSelector("a[data-se='refExcluir']")).Click();
            webDriverWait?.Until(d => d.Title.Contains("Exclusão de Contato"));
            EsperarPorElemento(By.CssSelector("button[data-se=btnExcluir]")).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => !d.PageSource.Contains("Marlon Q Editado"));
        }

        public static void CadastrarContato()
        {
            NavegarPara("/contatos/cadastrar");

            EsperarPorElemento(By.CssSelector("input[data-se=inputNome]")).SendKeys("Marlon Q");
            EsperarPorElemento(By.CssSelector("input[data-se=inputTelefone]")).SendKeys("(49) 99999-9999");
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]")).SendKeys("marlonq@gmail.com");
            EsperarPorElemento(By.CssSelector("input[data-se=inputEmpresa]")).SendKeys("Softecsul Tecnologia");
            EsperarPorElemento(By.CssSelector("input[data-se=inputCargo]")).SendKeys("Software Tester");

            EsperarPorElemento(By.CssSelector("button[data-se=btnSalvar]")).Click();
        }
    }
}
