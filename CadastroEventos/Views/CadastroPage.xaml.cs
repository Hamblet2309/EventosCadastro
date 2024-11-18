using CadastroEventos.Models;
using CadastroEventos.Views;

namespace CadastroEventos.Views
{
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
            // Define as datas iniciais
            DataInicioPicker.Date = DateTime.Now;
            DataTerminoPicker.Date = DateTime.Now.AddDays(1);
        }

        // Evento para garantir que a Data de T�rmino n�o seja antes da Data de In�cio
        private void OnDataInicioChanged(object sender, DateChangedEventArgs e)
        {
            if (DataTerminoPicker.Date < e.NewDate)
            {
                DataTerminoPicker.Date = e.NewDate;
                DisplayAlert("Aviso", "A data de t�rmino foi ajustada para n�o ser anterior � data de in�cio.", "OK");
            }
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            try
            {
                // Criar o objeto Evento com os dados preenchidos
                var evento = new Evento
                {
                    Nome = NomeEntry.Text,
                    DataInicio = DataInicioPicker.Date,
                    DataTermino = DataTerminoPicker.Date,
                    NumeroParticipantes = int.Parse(NumeroParticipantesEntry.Text),
                    Local = LocalEntry.Text,
                    CustoPorParticipante = decimal.Parse(CustoPorParticipanteEntry.Text)
                };

                // Validar dados
                if (string.IsNullOrWhiteSpace(evento.Nome) || string.IsNullOrWhiteSpace(evento.Local))
                {
                    await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                    return;
                }

                if (evento.DataTermino < evento.DataInicio)
                {
                    await DisplayAlert("Erro", "A data de t�rmino n�o pode ser antes da data de in�cio.", "OK");
                    return;
                }

                // Navegar para a p�gina de resumo com o evento como contexto
                await Navigation.PushAsync(new ResumoPage(evento));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Verifique os dados informados! " + ex.Message, "OK");
            }
        }
    }
}