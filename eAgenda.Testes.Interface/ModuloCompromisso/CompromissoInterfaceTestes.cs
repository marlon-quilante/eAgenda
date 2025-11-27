using eAgenda.Testes.Interface.Compartilhado;
using eAgenda.Testes.Interface.ModuloContato;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace eAgenda.Testes.Interface.ModuloCompromisso
{
    [TestClass]
    [TestCategory("Testes de Interface de Compromisso")]
    public class CompromissoInterfaceTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarCompromisso_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            NavegarPara("compromissos/cadastrar");

            // Ação
            CadastrarCompromisso();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Reunião"));
            webDriverWait?.Until(d => d.PageSource.Contains("22/11/2025"));
            webDriverWait?.Until(d => d.PageSource.Contains("09:00 - 10:00"));
            webDriverWait?.Until(d => d.PageSource.Contains("Presencial"));
            webDriverWait?.Until(d => d.PageSource.Contains("Sala de reunião"));
        }

        [TestMethod]
        public void Deve_CadastrarCompromisso_ComContato_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            ContatoInterfaceTestes.CadastrarContato();

            webDriverWait?.Until(d => d.Title.Contains("Contatos"));
            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q"));

            NavegarPara("compromissos/cadastrar");

            // Ação
            PreencherCamposBasicosDeCompromissos();
            var selectContato = new SelectElement(EsperarPorElemento(By.CssSelector("select[data-se=inputContatoId]")));
            selectContato.SelectByText("Marlon Q");

            EsperarPorElemento(By.CssSelector("button[data-se=btnSalvar]")).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Reunião"));
            webDriverWait?.Until(d => d.PageSource.Contains("22/11/2025"));
            webDriverWait?.Until(d => d.PageSource.Contains("09:00 - 10:00"));
            webDriverWait?.Until(d => d.PageSource.Contains("Presencial"));
            webDriverWait?.Until(d => d.PageSource.Contains("Sala de reunião"));
            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q"));
        }

        [TestMethod]
        public void Deve_EditarCompromisso_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarCompromisso();

            // Ação
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            EsperarPorElemento(By.CssSelector("a[data-se='refEditar']")).Click();

            EsperarPorElemento(By.CssSelector("input[data-se=inputAssunto]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputAssunto]")).SendKeys("Call");

            EsperarPorElemento(By.CssSelector("input[data-se=inputData]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputData]")).SendKeys("22/11/2026");

            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraInicio]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraInicio]")).SendKeys("15:00");

            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraTermino]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraTermino]")).SendKeys("16:00");

            var inputTipo = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

            var selectInputTipo = new SelectElement(EsperarPorElemento(By.CssSelector("select[data-se=inputTipo]")));
            selectInputTipo.SelectByText("Remoto");

            EsperarPorElemento(By.CssSelector("input[data-se=inputLocal]")).Clear();
            EsperarPorElemento(By.CssSelector("input[data-se=inputLink]")).SendKeys("https://meet.google.com/jbv-terg-tjq");

            EsperarPorElemento(By.CssSelector("button[data-se=btnSalvar]")).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Call"));
            webDriverWait?.Until(d => d.PageSource.Contains("22/11/2026"));
            webDriverWait?.Until(d => d.PageSource.Contains("15:00 - 16:00"));
            webDriverWait?.Until(d => d.PageSource.Contains("Remoto"));
            webDriverWait?.Until(d => d.PageSource.Contains("https://meet.google.com/jbv-terg-tjq"));
        }

        [TestMethod]
        public void Deve_ExcluirCompromisso_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarCompromisso();

            // Ação
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            EsperarPorElemento(By.CssSelector("a[data-se='refExcluir']")).Click();
            webDriverWait?.Until(d => d.Title.Contains("Exclusão de Compromisso"));
            EsperarPorElemento(By.CssSelector("button[data-se='btnExcluir']")).Click();

            // Asserção
            webDriverWait?.Until(d => !d.PageSource.Contains("Reunião"));
        }

        private void CadastrarCompromisso()
        {
            ContatoInterfaceTestes.CadastrarContato();
            NavegarPara("compromissos/cadastrar");
            PreencherCamposBasicosDeCompromissos();
            EsperarPorElemento(By.CssSelector("button[data-se=btnSalvar]")).Click();
        }

        private void PreencherCamposBasicosDeCompromissos()
        {
            EsperarPorElemento(By.CssSelector("input[data-se=inputAssunto]")).SendKeys("Reunião");
            EsperarPorElemento(By.CssSelector("input[data-se=inputData]")).SendKeys("22/11/2025");
            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraInicio]")).SendKeys("09:00");
            EsperarPorElemento(By.CssSelector("input[data-se=inputHoraTermino]")).SendKeys("10:00");

            var inputTipo = EsperarPorElemento(By.CssSelector("input[data-se=inputTipo]"));

            var selectInputTipo = new SelectElement(EsperarPorElemento(By.CssSelector("input[data-se=inputTipo]")));
            selectInputTipo.SelectByText("Presencial");

            EsperarPorElemento(By.CssSelector("input[data-se=inputLocal]")).SendKeys("Sala de reunião");
        }
    }
}
