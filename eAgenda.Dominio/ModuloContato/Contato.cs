using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloCompromisso;

namespace eAgenda.Dominio.ModuloContato
{
    public class Contato : EntidadeBase<Contato>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public List<Compromisso> Compromissos { get; set; }

        public Contato() { }

        public Contato(string nome, string telefone, string email, string empresa, string cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }
    }
}
