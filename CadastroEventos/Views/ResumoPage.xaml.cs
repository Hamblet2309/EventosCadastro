using CadastroEventos.Models;

namespace CadastroEventos.Views
{
    public partial class ResumoPage : ContentPage
    {
        public ResumoPage(Evento evento)
        {
            InitializeComponent();
            BindingContext = evento; // Define o evento como contexto de dados
        }
    }
}
