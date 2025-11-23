using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace eAgenda.Testes.Interface.ModuloCompromisso
{
    [TestClass]
    [TestCategory("Testes de Interface de Compromisso")]
    public class CompromissoInterfaceTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarCompromissoPresencial_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarContato();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCompromissos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCadastrar']"))).Click();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/11/2025");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");
            
            var inputTipo = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

            var selectInputTipo = new SelectElement(inputTipo!);
            selectInputTipo.SelectByText("Presencial");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).SendKeys("Sala de reunião");

            var inputContatoId = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputContatoId]")));

            var selectInputContatoId = new SelectElement(inputContatoId!);
            selectInputContatoId.SelectByText("Marlon Q");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

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
        public void Deve_CadastrarCompromissoRemoto_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarContato();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCompromissos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCadastrar']"))).Click();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/11/2025");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");

            var inputTipo = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

            var selectInputTipo = new SelectElement(inputTipo!);
            selectInputTipo.SelectByText("Remoto");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputLink]"))).SendKeys("https://meet.google.com/jbv-terg-tjq");

            var inputContatoId = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputContatoId]")));

            var selectInputContatoId = new SelectElement(inputContatoId!);
            selectInputContatoId.SelectByText("Marlon Q");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Reunião"));
            webDriverWait?.Until(d => d.PageSource.Contains("22/11/2025"));
            webDriverWait?.Until(d => d.PageSource.Contains("09:00 - 10:00"));
            webDriverWait?.Until(d => d.PageSource.Contains("Remoto"));
            webDriverWait?.Until(d => d.PageSource.Contains("https://meet.google.com/jbv-terg-tjq"));
            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q"));
        }

        [TestMethod]
        public void Deve_EditarCompromisso_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarCompromisso();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCompromissos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refEditar']"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Call");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/11/2026");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("15:00");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("16:00");

            var inputTipo = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

            var selectInputTipo = new SelectElement(inputTipo!);
            selectInputTipo.SelectByText("Remoto");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).Clear();
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputLink]"))).SendKeys("https://meet.google.com/jbv-terg-tjq");

            var inputContatoId = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputContatoId]")));

            var selectInputContatoId = new SelectElement(inputContatoId!);
            selectInputContatoId.SelectByText("Marlon Q");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();

            // Asserção
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));

            webDriverWait?.Until(d => d.PageSource.Contains("Call"));
            webDriverWait?.Until(d => d.PageSource.Contains("22/11/2026"));
            webDriverWait?.Until(d => d.PageSource.Contains("15:00 - 16:00"));
            webDriverWait?.Until(d => d.PageSource.Contains("Remoto"));
            webDriverWait?.Until(d => d.PageSource.Contains("https://meet.google.com/jbv-terg-tjq"));
            webDriverWait?.Until(d => d.PageSource.Contains("Marlon Q"));
        }

        [TestMethod]
        public void Deve_ExcluirCompromisso_ComSucesso()
        {
            // Arranjo
            RegistrarEAutenticarUsuario();

            CadastrarCompromisso();

            // Ação
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refCompromissos']"))).Click();
            webDriverWait?.Until(d => d.Title.Contains("Compromissos"));
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("a[data-se='refExcluir']"))).Click();

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se='btnExcluir']"))).Click();

            // Asserção
            webDriverWait?.Until(d => !d.PageSource.Contains("Reunião"));
        }

        private void CadastrarContato()
        {
            webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "contatos", "cadastrar"));

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Marlon Q");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 99999-9999");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("marlonq@gmail.com");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("Softecsul Tecnologia");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Software Tester");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();
        }

        private void CadastrarCompromisso()
        {
            CadastrarContato();

            webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "compromissos", "cadastrar"));

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/11/2025");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");
            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");

            var inputTipo = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

            var selectInputTipo = new SelectElement(inputTipo!);
            selectInputTipo.SelectByText("Presencial");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).SendKeys("Sala de reunião");

            var inputContatoId = webDriverWait?.Until(d => d.FindElement(By.CssSelector("select[data-se=inputContatoId]")));

            var selectInputContatoId = new SelectElement(inputContatoId!);
            selectInputContatoId.SelectByText("Marlon Q");

            webDriverWait?.Until(d => d.FindElement(By.CssSelector("button[data-se=btnSalvar]"))).Click();
        }
    }
}
