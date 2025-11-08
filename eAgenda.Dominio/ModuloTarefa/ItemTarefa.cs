namespace eAgenda.Dominio.ModuloTarefa
{
    public class ItemTarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool StatusConclusao { get; set; }
        public Tarefa Tarefa { get; set; }

        public ItemTarefa() { }

        public ItemTarefa(string titulo, Tarefa tarefa)
        {
            Titulo = titulo;
            StatusConclusao = false;
            Tarefa = tarefa;
            Id = Guid.NewGuid();
        }

        public void MarcarConcluido()
        {
            StatusConclusao = true;
        }
    }
}
