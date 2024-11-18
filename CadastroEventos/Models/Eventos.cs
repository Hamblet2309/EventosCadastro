namespace CadastroEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Local { get; set; }
        public decimal CustoPorParticipante { get; set; }

        // Propriedade calculada: Duração do evento
        public int DuracaoEmDias => (DataTermino - DataInicio).Days + 1;

        // Propriedade calculada: Custo total do evento
        public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;
    }
}
