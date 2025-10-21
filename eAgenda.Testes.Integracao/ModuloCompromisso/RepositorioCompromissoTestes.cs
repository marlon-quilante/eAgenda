using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Testes.Integracao.Compartilhado;
using FizzWare.NBuilder;

namespace eAgenda.Testes.Integracao.ModuloCompromisso
{
    [TestClass]
    [TestCategory("Testes de Integração de Compromisso")]
    public class RepositorioCompromissoTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_SemContato_ComSucesso()
        {
            // Arrange - Arranjo
            TimeSpan horaInicio = DateTime.Now.TimeOfDay;
            TimeSpan horaTermino = horaInicio.Add(TimeSpan.FromHours(2));

            Compromisso compromisso = new Compromisso("Assunto Teste", DateTime.Now, horaInicio, horaTermino, TipoCompromisso.Presencial, "Local teste", null, null);
            compromisso.Id = Guid.NewGuid();

            // Act - Ação
            repositorioCompromisso?.Cadastrar(compromisso);

            // Assert - Asserção
            Compromisso? compromissoSelecionado = repositorioCompromisso?.SelecionarRegistroPorId(compromisso.Id);

            Assert.AreEqual(compromisso, compromissoSelecionado);
        }

        [TestMethod]
        public void Deve_CadastrarRegistro_ComContato_ComSucesso()
        {
            // Arrange - Arranjo
            Contato contato = Builder<Contato>.CreateNew().With(c => c.Id = Guid.NewGuid()).Build();

            TimeSpan horaInicio = DateTime.Now.TimeOfDay;
            TimeSpan horaTermino = horaInicio.Add(TimeSpan.FromHours(2));

            Compromisso compromisso = new Compromisso("Assunto Teste", DateTime.Now, horaInicio, horaTermino, TipoCompromisso.Presencial, "Local teste", null, contato);
            compromisso.Id = Guid.NewGuid();

            // Act - Ação
            repositorioCompromisso?.Cadastrar(compromisso);

            // Assert - Asserção
            Compromisso? compromissoSelecionado = repositorioCompromisso?.SelecionarRegistroPorId(compromisso.Id);

            Assert.AreEqual(compromisso, compromissoSelecionado);
        }
    }
}
