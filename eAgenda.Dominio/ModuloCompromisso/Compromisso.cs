using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloContato;

namespace eAgenda.Dominio.ModuloCompromisso
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TipoCompromisso Tipo { get; set; }
        public string? Local { get; set; }
        public string? Link { get; set; }
        public Contato? Contato { get; set; }

        public Compromisso() { }

        public Compromisso(string assunto, DateTime data, TimeSpan horaInicio, TimeSpan horaTermino, TipoCompromisso tipo, string? local, string? link, Contato? contato)
        {
            Assunto = assunto;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Tipo = tipo;
            Local = local;
            Link = link;
            Contato = contato;
            Id = Guid.NewGuid();
        }

        public bool HorarioDisponivel(DateTime data, Guid id, TimeSpan horaInicio, TimeSpan horaTermino)
        {
            if (id != Id && data == Data && ((horaInicio == HoraInicio || horaInicio == HoraTermino || (horaInicio > HoraInicio && horaInicio < HoraTermino))
                || (horaTermino == HoraInicio || horaTermino == HoraTermino || (horaTermino > HoraInicio && horaTermino < HoraTermino))))
                return false;
            return true;
        }
    }
}
